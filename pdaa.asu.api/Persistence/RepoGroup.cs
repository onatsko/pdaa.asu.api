using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public class RepoGroup : IRepoGroup
    {
        string connectionString = null;
        public RepoGroup(string conn)
        {
            connectionString = conn;
        }

        public Group Get(long PK)
        {
            var sql = "exec dbo.usp_Kadry_Group_detail @pk = @pk, @U = @u";
            var parameters = new DynamicParameters();
            parameters.Add("@pk", PK);
            parameters.Add("@u", 3);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Group>(sql, parameters).FirstOrDefault();
            }
        }

        public List<Kadr> GetGroupList(long groupPK)
        {
            var sql = "exec dbo.usp_EducStud_Stud_ofIdEducPlanSpec @IdGrup = @groupPK, @IdKadr_us = @u, @ShowOnlyActive = 1";

            var parameters = new DynamicParameters();
            parameters.Add("@groupPK", groupPK);
            parameters.Add("@u", 3);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Kadr>(sql, parameters).ToList();
            }
        }

        public string GetName(long groupId)
        {
            var sql = "select dbo.ufn_GrupNameAutoAll(@pk, @u)";
            var parameters = new DynamicParameters();
            parameters.Add("@pk", groupId);
            parameters.Add("@u", 3);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<string>(sql, parameters).FirstOrDefault();
            }
        }
    }
}
