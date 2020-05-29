using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public class RepoKafedra : IRepoKafedra
    {
        string connectionString = null;
        public RepoKafedra(string conn)
        {
            connectionString = conn;
        }
        public Kafedra Get(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Kafedra>("exec dbo.usp_Kafedra_spr @IdKafedra = @id", parameters).FirstOrDefault();
            }
        }
       
    }
}
