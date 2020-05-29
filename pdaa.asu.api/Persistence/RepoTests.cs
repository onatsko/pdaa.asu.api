using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public class RepoTests : IRepoTests
    {
        private string _connectionString = null;

        public RepoTests(string conn)
        {
            _connectionString = conn;
        }
        public string GetQuestion(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<string>("select QuestionPicHtml from tblTest_Question_spr where IdQuestion = @id", parameters).FirstOrDefault();
            }
        }

        public List<long> GetAnswerIdsForQuestion(long questionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", questionId);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<long>("exec dbo.usp_Test_Adm_Answer_spr_ofQuestion @IdQuestion = @id", parameters).ToList();
            }
        }

        public string GetAnswer(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<string>("select AnswerPicHtml from tblTest_Answer_spr where IdAnswer = @id", parameters).FirstOrDefault();
            }
        }

        public List<Test_Shablon> GetShablons(long kadrId, long kadrDivisionId, long kadrPosadaId)
        {
            if (kadrPosadaId == 3) //student
            {
                var parameters = new DynamicParameters();
                parameters.Add("@groupId", kadrDivisionId);

                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    return db.Query<Test_Shablon>("exec dbo.usp_AdmTestShablonDifAccess @IdGrup = @groupId", parameters)
                        .ToList();
                }
            }
            else
            {
                var parameters = new DynamicParameters();
                parameters.Add("@kadrId", kadrId);

                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    return db.Query<Test_Shablon>("exec dbo.usp_AdmTestShablonDifAccess @IdKadr = @kadrId", parameters)
                        .ToList();
                }
            }
        }

        public Test_ShablonDetail GetShablonDetail(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Test_ShablonDetail>("exec dbo.usp_TestSt_ShablonParam @IdShablon = @Id", parameters).FirstOrDefault();
            }
        }

        public long StartTestJrnl(Test_ShablonDetail shablon, long currentUserId, long kadrDivisionId, long kadrPosadaId)
        {
            //Открываем новую запись в tblTestShablon_jrn
            var sql = "exec dbo.usp_TestSt_ShablonOtbor " +
                             "  @IdKadr = @kadrId" +
                             ", @IdDivision = @kadrDivisionId" +
                             ", @IdPosada = @kadrPosadaId" +
                             ", @ShablonName = @shablonName" +
                             ", @IdVidSysOcen = @shablonVidSysOcen";
           

            var parameters = new DynamicParameters();
            parameters.Add("@kadrId", currentUserId);
            parameters.Add("@kadrDivisionId", kadrDivisionId);
            parameters.Add("@kadrPosadaId", kadrPosadaId);
            parameters.Add("@shablonName", shablon.Name);
            parameters.Add("@shablonVidSysOcen", shablon.VidSysOcen);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                //_idTestShablon = OndMain.dbReadLong(strCommand);
                return db.Query<long>(sql, parameters).FirstOrDefault();
            }
        }

        public List<Test_StartedTestQuestion> GetQuestionsForTest(long startTestShablonId, long shablonId)
        {
            var sql = $"exec dbo.usp_TestSt_QuestionOtbor @IdTestShablon = @startTestShablonId, @IdShablon = @shablonId";

            var parameters = new DynamicParameters();
            parameters.Add("@startTestShablonId", startTestShablonId);
            parameters.Add("@shablonId", shablonId);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                //_idTestShablon = OndMain.dbReadLong(strCommand);
                return db.Query<Test_StartedTestQuestion>(sql, parameters).ToList();
            }
        }

        public List<Test_StartedTestAnswer> GetStartedTestQestionAnswers(long startTestShablonId, long questionId)
        {
            var sql = "exec dbo.usp_TestSt_AnswerOtbor @IdTestShablon = @startTestShablonId, @IdQuestion = @questionId";

            var parameters = new DynamicParameters();
            parameters.Add("@startTestShablonId", startTestShablonId);
            parameters.Add("@questionId", questionId);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                //_idTestShablon = OndMain.dbReadLong(strCommand);
                return db.Query<Test_StartedTestAnswer>(sql, parameters).ToList();
            }
        }

        public void SetStartedTestQuestionAnswer(long testAnswerId, int answerFlFakt, long currentUserId)
        {
            var sql =
                "exec dbo.usp_Test_St_Answer_spr_Fl_upd @IdTestAnswer= @testAnswerId, @AnswerFl_fakt = @answerFlFakt, @LastUserEdit = @lastEdit, @IdKadr_us = @currentUserId";

            var parameters = new DynamicParameters();
            parameters.Add("@testAnswerId", testAnswerId);
            parameters.Add("@answerFlFakt", answerFlFakt);
            parameters.Add("@lastEdit", $"BlazorSite {DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}");
            parameters.Add("@currentUserId", currentUserId);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, parameters);
            }
        }

        public void CheckTest(long startTestShablonId, long shablonId)
        {
            var sql = "exec dbo.usp_TestSt_Check @IdTestShablon = @startTestShablonId, @IdShablon = @shablonId";

            var parameters = new DynamicParameters();
            parameters.Add("@startTestShablonId", startTestShablonId);
            parameters.Add("@shablonId", shablonId);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, parameters);
            }
        }

        public string GetTestResult(long startTestShablonId)
        {
            var sql = "exec dbo.usp_TestSt_ItogShablon @IdTestShablon = @startTestShablonId";

            var parameters = new DynamicParameters();
            parameters.Add("@startTestShablonId", startTestShablonId);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                //_idTestShablon = OndMain.dbReadLong(strCommand);
                return db.Query<string>(sql, parameters).FirstOrDefault();
            }
        }

    }
}
