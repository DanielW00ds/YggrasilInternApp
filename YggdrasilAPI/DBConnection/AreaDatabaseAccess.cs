using ModelLiberary;
using System.Data.SqlClient;

namespace YggdrasilAPI.DBConnection
{

    public class AreaDatabaseAccess : IAreaAccess
    {
        public string _connectionString { get; set; }

        public AreaDatabaseAccess(IConfiguration inConfiguration)
        {
            string useConnectionString = inConfiguration["ConnectionString"];
            _connectionString = inConfiguration.GetConnectionString(useConnectionString);
        }

        public AreaDatabaseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Area GetArea(int id)
        {
            Area foundArea;
            string queryString = "SELECT * FROM Areas WHERE id = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@id", id);
                readCommand.Parameters.Add(idParam);
                con.Open();
                SqlDataReader areaReader = readCommand.ExecuteReader();
                foundArea = new Area();
                while (areaReader.Read())
                {
                    foundArea = GetAreaFromReader(areaReader);
                }
            }
            return foundArea;
        }

        private Area GetAreaFromReader(SqlDataReader areaReader)
        {
            Area area = new Area();
            area.Name = areaReader.GetString(areaReader.GetOrdinal("name"));
            area.ID = areaReader.GetInt32(areaReader.GetOrdinal("id"));
            return area;
        }

        public List<Area> GetAreas()
        {
            List<Area> foundAreas = new List<Area>();
            Area readArea;
            string queryString = "SELECT * FROM Areas";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader areaReader = readCommand.ExecuteReader();
                foundAreas = new List<Area>();
                while (areaReader.Read())
                {
                    readArea = GetAreaFromReader(areaReader);
                    foundAreas.Add(readArea);
                }
            }
            return foundAreas;
        }
    }
}
