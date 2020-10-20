using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using pdaa.asu.api.Persistence.DataModels;
using pdaa.asu.api.Services.ViewModels;
using PDAA_cs.Common.DataModels;

namespace pdaa.asu.api.Persistence
{
    public class RepoZno : IRepoZno
    {
        private string _connectionString = null;

        public RepoZno(string conn)
        {
            _connectionString = conn;
        }

        public List<ZnoExam> GetZnoExams()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<ZnoExam>("exec dbo.usp_Zno_Exam_list @U = 3, @showDel = 0")
                    .ToList();
            }
        }

        public List<ZnoCalculatorResult> GetZnoCalculator(int year, long exam1Id, long exam2Id, long exam3Id, long exam4Id, long exam5Id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<ZnoCalculatorResult>($"exec dbo.usp_Zno_ExamsForSpecForYear_list_calculator @year = {year}, @exam1 = {exam1Id}, @exam2 = {exam2Id}, @exam3 = {exam3Id}, @exam4 = {exam4Id}, @exam5 = {exam5Id}")
                    .ToList();
            }
        }

        public ZnoSpec GetSpec(long specForYearId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", specForYearId);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<ZnoSpec>(@"SELECT 
                    tblZNO_Spec.Id
                    , SpecCode
                    , SpecName
                    , EducProgram
                    FROM dbo.tblZNO_SpecForYear
                    inner join dbo.tblZNO_Spec on ZnoSpecId = tblZNO_Spec.Id
                where
                        tblZNO_SpecForYear.Id = @id
                    and(tblZNO_SpecForYear.IsDel = 0)
                    and(tblZNO_Spec.IsDel = 0)", parameters).FirstOrDefault();
            }
        }
    }
}
