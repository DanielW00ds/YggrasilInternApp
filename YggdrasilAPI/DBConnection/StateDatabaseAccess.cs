using ModelLiberary;
using System.Data.SqlClient;

namespace YggdrasilAPI.DBConnection
{
    public class StateDatabaseAccess : IStateAccess
    {
        public string _connectionString { get; set; }

        public StateDatabaseAccess(IConfiguration inConfiguration)
        {
            string useConnectionString = inConfiguration["ConnectionString"];
            _connectionString = inConfiguration.GetConnectionString(useConnectionString);
        }

        public StateDatabaseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public State GetState(int id)
        {
            State foundState;
            string queryString = "SELECT * FROM States WHERE id = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@id", id);
                readCommand.Parameters.Add(idParam);
                con.Open();
                SqlDataReader stateReader = readCommand.ExecuteReader();
                foundState = new State();
                while (stateReader.Read())
                {
                    foundState = GetStateFromReader(stateReader);
                }
            }
            return foundState;
        }

        private State GetStateFromReader(SqlDataReader stateReader)
        {
            State state = new State();
            state.Name = stateReader.GetString(stateReader.GetOrdinal("name"));
            state.ID = stateReader.GetInt32(stateReader.GetOrdinal("id"));
            return state;
        }

        public List<State> GetStates()
        {
            List<State> foundStates = new List<State>();
            State readState;
            string queryString = "SELECT * FROM States";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader stateReader = readCommand.ExecuteReader();
                foundStates = new List<State>();
                while (stateReader.Read())
                {
                    readState = GetStateFromReader(stateReader);
                    foundStates.Add(readState);
                }
            }
            return foundStates;
        }
    }
}
