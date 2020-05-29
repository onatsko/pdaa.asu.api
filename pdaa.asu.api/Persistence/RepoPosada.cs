using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public class RepoPosada : IRepoPosada
    {
        string connectionString = null;
        public RepoPosada(string conn)
        {
            connectionString = conn;
        }
        public Posada Get(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@u", 3);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Posada>("exec dbo.usp_Kadry_Posada_detail @pk = @id, @U = @u", parameters).FirstOrDefault();
            }
        }
       
    }
}
