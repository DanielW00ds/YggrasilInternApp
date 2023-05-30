using ModelLiberary;
using System.Data.SqlClient;

namespace YggdrasilAPI.DBConnection
{
    public class TechTypeDatabaseAccess : ITechTypeAccess
    {
        public string _connectionString { get; set; }

        public TechTypeDatabaseAccess(IConfiguration inConfiguration)
        {
            string useConnectionString = inConfiguration["ConnectionString"];
            _connectionString = inConfiguration.GetConnectionString(useConnectionString);
        }

        public TechTypeDatabaseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public TechnologyType GetTechType(int id)
        {
            TechnologyType foundTechType;
            string queryString = "SELECT * FROM TechnologyTypes WHERE id = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@id", id);
                readCommand.Parameters.Add(idParam);
                con.Open();
                SqlDataReader techTypeReader = readCommand.ExecuteReader();
                foundTechType = new TechnologyType();
                while (techTypeReader.Read())
                {
                    foundTechType = GetTechTypeFromReader(techTypeReader);
                }
            }
            return foundTechType;
        }

        private TechnologyType GetTechTypeFromReader(SqlDataReader TechTypeReader)
        {
            TechnologyType techType = new TechnologyType();
            techType.Name = TechTypeReader.GetString(TechTypeReader.GetOrdinal("name"));
            techType.ID = TechTypeReader.GetInt32(TechTypeReader.GetOrdinal("id"));
            return techType;
        }

        public List<TechnologyType> GetTechTypes()
        {
            List<TechnologyType> foundTechTypes = new List<TechnologyType>();
            TechnologyType readTechType;
            string queryString = "SELECT * FROM TechnologyTypes";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader ttReader = readCommand.ExecuteReader();
                foundTechTypes = new List<TechnologyType>();
                while (ttReader.Read())
                {
                    readTechType = GetTechTypeFromReader(ttReader);
                    foundTechTypes.Add(readTechType);
                }
            }
            return foundTechTypes;
        }
    }
}
