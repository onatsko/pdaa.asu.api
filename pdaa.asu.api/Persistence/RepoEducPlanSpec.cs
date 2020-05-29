using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public class RepoEducPlanSpec : IRepoEducPlanSpec
    {
        string connectionString = null;
        public RepoEducPlanSpec(string conn)
        {
            connectionString = conn;
        }
        public EducPlanSpec Get(long id, int year)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@year", year);
            parameters.Add("@u", 3);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<EducPlanSpec>("exec dbo.usp_EducPlanSpec_prm_2015 @IdEducPlanSpec=@id, @EducYearBeginCalc=@year, @IdKadr_us = @u", parameters).FirstOrDefault();
            }
        }

        public List<DisciplineForSelect> GetDisciplineForSelect(
            long educPlanSpecId, 
            int semesrt,
            long studentId,
            long movingId,
            EducPlanSpec educPlanSpec)
        {
            //Затык от ЮЮ (Вет.фак магистрам нужно скармливать дисциплины бакалавров)
            var kvalifId = educPlanSpec.KvalifFK;
            if (educPlanSpec.FakultetFK == 5 && kvalifId == 3)
                kvalifId = 1;

            var parameters = new DynamicParameters();
            parameters.Add("@semesrt", semesrt);
            parameters.Add("@yearBegin", educPlanSpec.EducYearBegin);
            parameters.Add("@IdKvalif", kvalifId);
            parameters.Add("@IdVidEduc", educPlanSpec.EducVidFK);
            parameters.Add("@IsStn", educPlanSpec.IsStn ? 1 : 0);
            parameters.Add("@IdEducPlanSpecDiffSelectMain", educPlanSpecId);
            parameters.Add("@IdMoving", movingId);
            parameters.Add("@u", studentId);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var results = db.Query<DisciplineForSelect>("exec dbo.usp_EducPlan_DisciplinesDiffSelect_jrn   @IdEducPlanSpec=0, @DisciplinesName='', @IdKategoryType=0, @chkInterKaf=-1, @chkInterKafCalc=1, @IsDisciplinesDiffSelect=1, @SemesterEduc=@semesrt, @EducPlanYearBegin=@yearBegin, @IdKvalif=@IdKvalif, @IdVidEduc=@IdVidEduc, @IsStn=@IsStn, @IdEducPlanSpecDiffSelectMain=@IdEducPlanSpecDiffSelectMain, @IdMoving=@IdMoving, @IdKadr_us=@u"
                    , parameters);
                    //.ToList()();

                    return results.ToList();
            }
        }

        public List<DisciplineSelected> GetSelectedDiscipline(
            long educPlanSpecId,
            long movingId,
            int semesrt,
            long studentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@semesrt", semesrt);
            parameters.Add("@IdEducPlanSpecDiffSelectMain", educPlanSpecId);
            parameters.Add("@IdMoving", movingId);
            parameters.Add("@u", studentId);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sql = "exec dbo.usp_EducPlan_DisciplinesDiffSelectStud_jrn " +
                          "  @IdDisciplinesDiffSelect_jrn = 0" + //0 +
                          ", @IdMoving = @IdMoving" + //_idMoving +
                          ", @SemesterEduc= @semesrt" + //_semesterEduc +
                          ", @IdEducPlanSpec = @IdEducPlanSpecDiffSelectMain" + //_idEducPlanSpecDiffSelectMain +
                          ", @IdKadr_us = @u";// + OndMain.currentUserPK + "";
                var results = db.Query<DisciplineSelected>(sql, parameters);

                return results.ToList();
            }
        }

        public int AddStudentDisciplineSelect(long disciplineId, long movingId, int semestr, long educPlanSpecId, long studentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@disciplineId", disciplineId);
            parameters.Add("@semesrt", semestr);
            parameters.Add("@educPlanSpecId", educPlanSpecId);
            parameters.Add("@movingId", movingId);
            parameters.Add("@u", studentId);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sql = "exec dbo.usp_EducPlan_DisciplinesDiffSelectStud_InsNew " +
                          "  @IdDisciplines_jrn = @disciplineId" +
                          ", @IdMoving = @movingId" +
                          ", @SemesterEduc = @semesrt" +
                          ", @IdEducPlanSpec = @educPlanSpecId" + 
                          ", @U = @u";
                return db.Execute(sql, parameters);
            }
        }

        public int DelStudentDisciplineSelect(long disciplineId, long movingId, int semestr, long educPlanSpecId, int rowNum, long studentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@disciplineId", disciplineId);
            parameters.Add("@semesrt", semestr);
            parameters.Add("@educPlanSpecId", educPlanSpecId);
            parameters.Add("@movingId", movingId);
            parameters.Add("@rowNumPrevios", rowNum);
            parameters.Add("@LastUserEdit", $"PdaaSite#{studentId}#{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}");
            parameters.Add("@u", studentId);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sql = "exec dbo.usp_EducPlan_DisciplinesDiffSelectStud_IsDel " +
                          "  @IdDisciplinesDiffSelect_jrn = @disciplineId" +
                          ", @IdMoving = @movingId" +
                          ", @SemesterEduc = @semesrt" +
                          ", @IdEducPlanSpecDiffSelectMain = @educPlanSpecId" +
                          ", @ROW_NUM_Previos = @rowNumPrevios" +
                          ", @LastUserEdit = @LastUserEdit" +
                          ", @IdKadr_us = @u";
                return db.Execute(sql, parameters);
            }
        }

        public int MoveStudentDisciplineSelect(long disciplineId, long movingId, int semestr, long educPlanSpecId, int rowNum, int rowNumNext, long studentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@disciplineId", disciplineId);
            parameters.Add("@semesrt", semestr);
            parameters.Add("@educPlanSpecId", educPlanSpecId);
            parameters.Add("@movingId", movingId);
            parameters.Add("@rowNumPrevios", rowNum);
            parameters.Add("@rowNumNext", rowNumNext);
            parameters.Add("@LastUserEdit", $"PdaaSite#{studentId}#{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}");
            parameters.Add("@u", studentId);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sql = "exec dbo.usp_EducPlan_DisciplinesDiffSelectStud_OrderChange " +
                          "  @IdDisciplinesDiffSelect_jrn = @disciplineId" +
                          ", @IdMoving = @movingId" +
                          ", @SemesterEduc = @semesrt" +
                          ", @IdEducPlanSpecDiffSelectMain = @educPlanSpecId" +
                          ", @ROW_NUM_Previos = @rowNumPrevios" +
                          ", @ROW_NUM_Next = @rowNumNext" +
                          ", @LastUserEdit = @LastUserEdit" +
                          ", @IdKadr_us = @u";
                return db.Execute(sql, parameters);
            }
        }
    }
}
