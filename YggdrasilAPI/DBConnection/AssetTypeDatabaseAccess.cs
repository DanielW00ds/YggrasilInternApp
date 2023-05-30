using ModelLiberary;
using System.Data.SqlClient;

namespace YggdrasilAPI.DBConnection
{
    public class AssetTypeDatabaseAccess : IAssetTypeAccess
    {
        public string _connectionString { get; set; }

        public AssetTypeDatabaseAccess(IConfiguration inConfiguration)
        {
            string useConnectionString = inConfiguration["ConnectionString"];
            _connectionString = inConfiguration.GetConnectionString(useConnectionString);
        }

        public AssetTypeDatabaseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public AssetType GetAssetType(int id)
        {
            AssetType foundAssetType;
            string queryString = "SELECT * FROM AssetTypes WHERE id = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@id", id);
                readCommand.Parameters.Add(idParam);
                con.Open();
                SqlDataReader assetTypeReader = readCommand.ExecuteReader();
                foundAssetType = new AssetType();
                while (assetTypeReader.Read())
                {
                    foundAssetType = GetAssetTypeFromReader(assetTypeReader);
                }
            }
            return foundAssetType;
        }

        private AssetType GetAssetTypeFromReader(SqlDataReader assetTypeReader)
        {
            AssetType assetType = new AssetType();
            assetType.Name = assetTypeReader.GetString(assetTypeReader.GetOrdinal("name"));
            assetType.ID = assetTypeReader.GetInt32(assetTypeReader.GetOrdinal("id"));
            return assetType;
        }


        public List<AssetType> GetAssetTypes()
        {
            List<AssetType> foundAssetTypes = new List<AssetType>();
            AssetType readAssetType;
            string queryString = "SELECT * FROM AssetTypes";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader atReader = readCommand.ExecuteReader();
                foundAssetTypes = new List<AssetType>();
                while (atReader.Read())
                {
                    readAssetType = GetAssetTypeFromReader(atReader);
                    foundAssetTypes.Add(readAssetType);
                }
            }
            return foundAssetTypes;
        }
    }
}
