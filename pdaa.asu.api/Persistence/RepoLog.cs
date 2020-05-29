using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public class RepoLog : IRepoLog
    {
        string connectionString = null;
        public RepoLog(string conn)
        {
            connectionString = conn;
        }

        public void AddLog(
            long currentUserId
            , string tableName
            , long elementPK
            , string whatDo
            , string elementBefore
            , string elementAfter)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@u", currentUserId);
            parameters.Add("@tableName", tableName);
            parameters.Add("@elementPK", elementPK);
            parameters.Add("@whatDo", whatDo);
            parameters.Add("@elementBefore", elementBefore);
            parameters.Add("@elementAfter", elementAfter);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sql = "exec dbo.usp_Adm_LogOndAdd @u = @u, @tableName = @tableName, @elementPK = @elementPK, @whatDo = @whatDo, @elementBefore = @elementBefore, @elementAfter = @elementAfter";
                db.Execute(sql, parameters);
            }
        }


        public List<LogOnd> GetLogs(string tableName, string whatDo, DateTime from, DateTime to)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //var sql = "exec dbo.usp_Adm_LogOnd_Logs 'BlazorSite', 0, 'Успешный вход с кодом%', '20200401', '19000101'";
                var sql = $"exec dbo.usp_Adm_LogOnd_Logs '{tableName}', 0, '{whatDo}', '{from.ToString("yyyyMMdd 00:00:00")}', '{to.ToString("yyyyMMdd 23:59:59")}'";
                return db.Query<LogOnd>(sql).ToList();
            }
        }

        public List<TelegramBotHistory> GetTelegramShedulerRequestLogs(DateTime from, DateTime to)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //var sql = "exec dbo.usp_Adm_LogOnd_Logs 'BlazorSite', 0, 'Успешный вход с кодом%', '20200401', '19000101'";
                var sql = $@"SELECT 
                        [pkTelegramBotHistory]
                        ,[TBHDate]
                        ,[MsgText]
                    FROM [dbo].[tblAdm_TelegramBotHistory] 
                    where 
                            (lower(MsgText) like '/розклад%')
                        and (TBHDate>='{from.ToString("yyyyMMdd 00:00:00")}' and TBHDate<='{to.ToString("yyyyMMdd 23:59:59")}')";
                return db.Query<TelegramBotHistory>(sql).ToList();
            }
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
