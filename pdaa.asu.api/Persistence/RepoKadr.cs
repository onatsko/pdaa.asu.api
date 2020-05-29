using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Dapper;
using pdaa.asu.api.Persistence.DataModels;
using pdaa.asu.api.Services;


namespace pdaa.asu.api.Persistence
{
    public class RepoKadr : IRepoKadr
    {
        string connectionString = null;
        public RepoKadr(string conn)
        {
            connectionString = conn;
        }
        public List<Kadr> GetKadrs()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Kadr>("exec dbo.usp_Kadry_Kadr_list @ShowDel = 0, @U = @u", 3).ToList();
            }
        }

        public Kadr Get(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pkKadr", id);
            parameters.Add("@u", 3);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Kadr>("exec dbo.usp_Kadry_Kadr_detail @pk = @pkKadr, @U = @u", parameters).FirstOrDefault();
            }
        }

        public Kadr GetByGoogleEmail(string email)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var p1 = new DynamicParameters();
                p1.Add("@email", email);
                var id = db.Query<long>("select dbo.ufn_Kadry_ByGoogleEmail(@email)", p1).First();
                if (id == 0) return null;

                return Get(id);
            }
        }

        public string GetPhoto(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pkKadr", id);
            parameters.Add("@u", 3);

            using (IDbConnection db = new SqlConnection(connectionString.Replace(";Initial Catalog=PDAA;", ";Initial Catalog=PDAA_image;")))
            {
                var byteBuffer = db.Query<byte[]>("exec dbo.usp_Kadry_PicData_GetPicData @IdKadr=@pkKadr, @IdKadr_us=@u", parameters).FirstOrDefault();

                if (byteBuffer == null) 
                    return string.Empty;

                var base64 = Convert.ToBase64String(byteBuffer);
                var imgSrc = String.Format("data:image/gif;base64,{0}", base64);

                return imgSrc;

                //var mstr = new MemoryStream();
                //mstr.Write(byteBuffer, 0, byteBuffer.Length);
                //picX.Image = Image.FromStream(mstr);
                //mstr.Close();
            }
        }

        public List<OrderDataVacation> GetKadrVacation(long kadrId, long orderTypeId = -1, long vacationSubTypeId = -1)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@kadrId", kadrId);
                parameters.Add("@orderTypeId", orderTypeId);
                parameters.Add("@vacationSubTypeId", vacationSubTypeId);

                var sql = "exec dbo.usp_Kadry_Vacation_jrn_new @Kadr = @kadrId, @OrderType = @orderTypeId, @VacationSubType = @vacationSubTypeId";
                return db.Query<OrderDataVacation>(sql, parameters).ToList();
            }
        }

        public List<OrderDataBusinessTrip> GetKadrBusinessTrips(long kadrId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@kadrId", kadrId);

                var sql = "exec dbo.usp_Kadry_BusinessTrip_list_byKadr @KadrPK = @kadrId";
                return db.Query<OrderDataBusinessTrip>(sql, parameters).ToList();
            }
        }

        /// <summary>
        /// последнее, основное (не совместитель) посадовое перемищення
        /// </summary>
        /// <param name="kadrPK"></param>
        /// <returns></returns>
        public long GetMoving_Last_Main(long kadrId)
        {
            long result = 0;

            if (kadrId <= 0)
                return result;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@kadrId", kadrId);

                var sql = "select dbo.ufn_Kadry_Moving_LastMain(@kadrId)";

                result = db.Query<long>(sql, parameters).FirstOrDefault();
                return result;
            }
        }

        public void SetPassword(long kadrPK, string password, long whoChangePassword)
        {
            var strCommand = "exec dbo.usp_Kadry_spr_ofKadr_upd_new " +
                             "  @IdKadr=" + kadrPK +
                             ", @ControlName='TxtUs_psw_confirm'" +
                             ", @ControlValue='" + cryptStr(password) + "'" +
                             ", @LastUserEdit='" + lastUserEdit() + "'" +
                             ", @IdKadr_us=" + whoChangePassword + "";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(strCommand);
            }

            using (MD5 md5Hash = MD5.Create())
            {
                string passMD5 = ServiceCurrentUser.GetMd5Hash(md5Hash, password);
                strCommand = "exec dbo.usp_Kadry_spr_ofKadr_upd_new " +
                             "  @IdKadr=" + kadrPK +
                             ", @ControlName='TxtUs_psw_md5_confirm'" +
                             ", @ControlValue='" + passMD5 + "'" +
                             ", @LastUserEdit='" + lastUserEdit() + "'" +
                             ", @IdKadr_us=" + whoChangePassword + "";

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Execute(strCommand);
                }
            }
        }

        private static string cryptStr(string str)
        {
            var retVal = "";

            for (int i = 0; i < str.Length; i++)
            {
                retVal = retVal + (chr((byte) (asc(Convert.ToChar(str.Substring(i, 1))) ^ 255)));
            }

            return retVal;
        }

        private static byte asc(char src)
        {
            return (Encoding.Default.GetBytes(src + "")[0]);
        }

        private static char chr(byte src)
        {
            return (Encoding.Default.GetChars(new[] { src })[0]);
        }

        private static string lastUserEdit()
        {
            var retVal = "";

            retVal = Environment.MachineName + ", " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            return retVal;
        }

        //public void Create(Kadr Kadr)
        //{
        //    using (IDbConnection db = new SqlConnection(connectionString))
        //    {
        //        var sqlQuery = "INSERT INTO Kadrs (Name, Age) VALUES(@Name, @Age)";
        //        db.Execute(sqlQuery, Kadr);

        //        // если мы хотим получить id добавленного пользователя
        //        //var sqlQuery = "INSERT INTO Kadrs (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
        //        //int? KadrId = db.Query<int>(sqlQuery, Kadr).FirstOrDefault();
        //        //Kadr.Id = KadrId.Value;
        //    }
        //}

        //public void Update(Kadr Kadr)
        //{
        //    using (IDbConnection db = new SqlConnection(connectionString))
        //    {
        //        var sqlQuery = "UPDATE Kadrs SET Name = @Name, Age = @Age WHERE Id = @Id";
        //        db.Execute(sqlQuery, Kadr);
        //    }
        //}

        //public void Delete(int id)
        //{
        //    using (IDbConnection db = new SqlConnection(connectionString))
        //    {
        //        var sqlQuery = "DELETE FROM Kadrs WHERE Id = @id";
        //        db.Execute(sqlQuery, new { id });
        //    }
        //}
    }
}
