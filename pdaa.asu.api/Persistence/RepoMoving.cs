using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public class RepoMoving : IRepoMoving
    {
        string connectionString = null;
        public RepoMoving(string conn)
        {
            connectionString = conn;
        }
        public List<Moving> GetAllByKadr(long kadrPK)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pkKadr", kadrPK);
            parameters.Add("@u", 3);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Moving>("exec dbo.usp_Kadry_Moving_list_ByKadr @kadrPK = @pkKadr, @U = @u", parameters).ToList();
            }
        }

        public List<Moving> GetAllActiveByKadr(long kadrPK)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pkKadr", kadrPK);
            parameters.Add("@u", 3);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Moving>("exec dbo.usp_Kadry_Moving_jrn_ofKadr_forPosada @IdKadr= @pkKadr", parameters).ToList();
            }
        }

        public Moving Get(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pkKadr", id);
            parameters.Add("@u", 3);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Moving>("exec dbo.usp_Kadry_Moving_detail @pk = @pkKadr, @U = @u", parameters).FirstOrDefault();
            }
        }
        public Moving GetLastMainByKadr(long kadrPK)
        {
            long movingPK = 0;

            var parameters = new DynamicParameters();
            parameters.Add("@pkKadr", kadrPK);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                movingPK = db.Query<long>("select dbo.ufn_Kadry_Moving_LastMain(@pkKadr)", parameters).FirstOrDefault();
                if (movingPK > 0)
                {
                    return Get(movingPK);
                }
            }

            return null;
        }

        public bool IsStudent(long kadrPK)
        {
            var movings = GetAllActiveByKadr(kadrPK);
            foreach (var moving in movings)
            {
                if (moving.PosadaFK == 3)
                    return true;
            }
            return false;
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
