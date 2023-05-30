using ModelLiberary;
using System.Data.SqlClient;

namespace YggdrasilAPI.DBConnection
{
    public class CounterpartDatabaseAccess : ICounterpartAccess
    {
        public string _connectionString { get; set; }

        public CounterpartDatabaseAccess(IConfiguration inConfiguration)
        {
            string useConnectionString = inConfiguration["ConnectionString"];
            _connectionString = inConfiguration.GetConnectionString(useConnectionString);
        }

        public CounterpartDatabaseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Counterpart GetCounterpart(int id)
        {
            Counterpart foundCounterpart;
            string queryString = "SELECT * FROM Counterparts WHERE id = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@id", id);
                readCommand.Parameters.Add(idParam);
                con.Open();
                SqlDataReader counterpartReader = readCommand.ExecuteReader();
                foundCounterpart = new Counterpart();
                while (counterpartReader.Read())
                {
                    foundCounterpart = GetCounterpartFromReader(counterpartReader);
                }
            }
            return foundCounterpart;
        }

        private Counterpart GetCounterpartFromReader(SqlDataReader cpReader)
        {
            Counterpart counterpart = new Counterpart();
            counterpart.Name = cpReader.GetString(cpReader.GetOrdinal("name"));
            counterpart.ID = cpReader.GetInt32(cpReader.GetOrdinal("id"));
            return counterpart;
        }

        public List<Counterpart> GetCounterparts()
        {
            List<Counterpart> foundCounterparts = new List<Counterpart>();
            Counterpart readCounterpart;
            string queryString = "SELECT * FROM Counterparts";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader cpReader = readCommand.ExecuteReader();
                foundCounterparts = new List<Counterpart>();
                while (cpReader.Read())
                {
                    readCounterpart = GetCounterpartFromReader(cpReader);
                    foundCounterparts.Add(readCounterpart);
                }
            }
            return foundCounterparts;
        }
    }
}
