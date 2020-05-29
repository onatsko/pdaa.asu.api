using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public class RepoSchedule : IRepoSchedule
    {
        string connectionString = null;
        public RepoSchedule(string conn)
        {
            connectionString = conn;
        }
        public List<ScheduleData> GetScheduleForTeacher(string sql, bool isForStudent)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sd = db.Query<ScheduleData>(sql).ToList();
                if (isForStudent)
                {
                    foreach (var scheduleData in sd)
                    {
                        scheduleData.IdGrup = 0;
                    }
                }
                else
                {
                    foreach (var scheduleData in sd)
                    {
                        scheduleData.IdKadr = 0;
                    }
                }

                return sd;
            }
        }

        //public void RegisterSiteQuerySchedule(string kadr, string week)
        //{
        //    var sql = "	exec dbo.usp_Adm_LogOndAdd @u, 'BlazorSite', @pk, 'Запрос расписания', @before, @after";

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@u", 3);

        //    long pk = 0;
        //    long.TryParse(kadr, out pk);
        //    parameters.Add("@pk", pk);
        //    parameters.Add("@before", $"kadr - {kadr}");
        //    parameters.Add("@after", $"week - {week}");

        //    using (IDbConnection db = new SqlConnection(connectionString))
        //    {
        //        db.Execute(sql, parameters);
        //    }
        //}

        //public void RegisterSiteQueryGroupList(string kadr, long groupPK)
        //{
        //    var sql = "	exec dbo.usp_Adm_LogOndAdd @u, 'BlazorSite', @pk, 'Запрос списка группы', @before, @after";

        //    var parameters = new DynamicParameters();
        //    parameters.Add("@u", 3);

        //    long pk = 0;
        //    long.TryParse(kadr, out pk);
        //    parameters.Add("@pk", pk);
        //    parameters.Add("@before", $"kadr - {kadr}");
        //    parameters.Add("@after", $"groupPK - {groupPK}");

        //    using (IDbConnection db = new SqlConnection(connectionString))
        //    {
        //        db.Execute(sql, parameters);
        //    }
        //}

        public ScheduleJrn GetScheduleJrn(long Id)
        {
            var sql = @"SELECT [IdSchedule]
                            ,[IdDiscipinesDistrib]
                            ,[EducYearBegin]
                            ,[WeekNum]
                            ,[IdAuditory]
                            ,[DayOfWeekNum]
                            ,[LessonNum]
                            ,[Prim]
                            ,[IsDel]
                            ,[LastUserEdit]
                            ,[IdKadr_us]
                            ,[IdScheduleAuditoryBlockType]
                        FROM [dbo].[tblSchedule_jrn]" +
                      $" where IdSchedule = {Id}";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var result = db.Query<ScheduleJrn>(sql).FirstOrDefault();
                return result;
            }
        }

        public DiscipinesDistribJrn GetDiscipinesDistribJrn(long Id)
        {
            var sql = @"SELECT [IdDiscipinesDistrib]
                          ,[IdEducPlanSpec]
                          ,[IdDisciplines_jrn]
                          ,[IdAspirant]
                          ,[IdKafAdditionalDek]
                          ,[IdKafAdditional]
                          ,[IdKafedra]
                          ,[YearEduc]
                          ,[SemesterEducYear]
                          ,[SemesterEduc]
                          ,[IdKadr]
                          ,[IdMoving]
                          ,[IdGrup]
                          ,[GrupSub]
                          ,[IdDiscipinesDistribType]
                          ,[DistribHour]
                          ,[InThread]
                          ,[IsDel]
                          ,[LastUserEdit]
                          ,[IdKadr_us]
                          ,[IdPosada]
                          ,[Stavka]
                          ,[IdDivision]
                          ,[Oklad]
                          ,[chkPoohBah]
                          ,[Ext]
                      FROM [dbo].[tblEducProc_DiscipinesDistrib_jrn] " +
                      $" where IdDiscipinesDistrib = {Id}";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var result = db.Query<DiscipinesDistribJrn>(sql).FirstOrDefault();
                return result;
            }
        }

        public DisciplinesJrn GetDiscipinesJrn(long Id)
        {
            var sql = "SELECT * FROM [dbo].[tblDisciplines_jrn] " +
                      $" where IdDisciplines_jrn = {Id}";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var result = db.Query<DisciplinesJrn>(sql).FirstOrDefault();
                return result;
            }
        }

        public Discipline GetDiscipine(long Id)
        {
            var sql = "SELECT * FROM [dbo].[tblDisciplines_spr] " +
                      $" where IdDisciplines = {Id}";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var result = db.Query<Discipline>(sql).FirstOrDefault();
                return result;
            }
        }


        //public Kadr Get(long id)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@pkKadr", id);
        //    parameters.Add("@u", 3);

        //    using (IDbConnection db = new SqlConnection(connectionString))
        //    {
        //        return db.Query<Kadr>("exec dbo.usp_Kadry_Kadr_detail @pk = @pkKadr, @U = @u", parameters).FirstOrDefault();
        //    }
        //}


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
