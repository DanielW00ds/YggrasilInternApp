using ModelLiberary;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace YggdrasilAPI.DBConnection
{
    public class AssetDatabaseAccess : IAssetAccess
    {
        public string _connectionString { get; set; }

        public AssetDatabaseAccess(IConfiguration inConfiguration)
        {
            string useConnectionString = inConfiguration["ConnectionString"];
            _connectionString = inConfiguration.GetConnectionString(useConnectionString);
        }

        private Asset GetAssetFromReader(SqlDataReader assetReader)
        {
            ICounterpartAccess _cpAccess = new CounterpartDatabaseAccess(_connectionString);
            IAreaAccess _areaAccess = new AreaDatabaseAccess(_connectionString);
            IAssetTypeAccess _atAccess = new AssetTypeDatabaseAccess(_connectionString);
            ITechTypeAccess _ttAccess = new TechTypeDatabaseAccess(_connectionString);
            IStateAccess _sAccess = new StateDatabaseAccess(_connectionString);
            Asset foundAsset = new Asset();
            foundAsset.ID = assetReader.GetInt32(assetReader.GetOrdinal("id"));
            foundAsset.Name = assetReader.GetString(assetReader.GetOrdinal("name"));
            foundAsset.Notes = assetReader.GetString(assetReader.GetOrdinal("notes"));
            foundAsset.ModifiedBy = assetReader.GetString(assetReader.GetOrdinal("modifiedBy"));
            foundAsset.Capacity = assetReader.GetDecimal(assetReader.GetOrdinal("capacity"));
            foundAsset.Longtitude = assetReader.GetDecimal(assetReader.GetOrdinal("longitude"));
            foundAsset.Latitude = assetReader.GetDecimal(assetReader.GetOrdinal("latitude"));
            foundAsset.ContractStart = assetReader.GetDateTime(assetReader.GetOrdinal("contractStart"));
            foundAsset.ContractEnd = assetReader.GetDateTime(assetReader.GetOrdinal("contractEnd"));
            foundAsset.ModifiedAt = assetReader.GetDateTime(assetReader.GetOrdinal("modifiedAt"));
            foundAsset.Counterpart = _cpAccess.GetCounterpart(assetReader.GetInt32(assetReader.GetOrdinal("fk_Counterpart_ID")));
            foundAsset.Area = _areaAccess.GetArea(assetReader.GetInt32(assetReader.GetOrdinal("fk_Area_ID")));
            foundAsset.AssetType = _atAccess.GetAssetType(assetReader.GetInt32(assetReader.GetOrdinal("fk_AssetType_ID")));
            foundAsset.technologyType = _ttAccess.GetTechType(assetReader.GetInt32(assetReader.GetOrdinal("fk_TechnologyType_ID")));
            foundAsset.state = _sAccess.GetState(assetReader.GetInt32(assetReader.GetOrdinal("fk_State_ID")));
            try
            {
                foundAsset.ApprovedAt = assetReader.GetDateTime(assetReader.GetOrdinal("approvedAt"));
            }
            catch
            {
                foundAsset.ApprovedAt = null;
            }
            try
            {
                foundAsset.ApprovedBy = assetReader.GetString(assetReader.GetOrdinal("approvedBy"));
            }
            catch
            {
                foundAsset.ApprovedAt = null;
            }
            return foundAsset;
        }

        public Asset GetAsset(int id)
        {
            Asset foundAsset;
            string queryString = "SELECT * FROM Assets WHERE id = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@id", id);
                readCommand.Parameters.Add(idParam);
                con.Open();
                SqlDataReader assetReader = readCommand.ExecuteReader();
                foundAsset = new Asset();
                while (assetReader.Read())
                {
                    foundAsset = GetAssetFromReader(assetReader);
                }
            }
            return foundAsset;
        }

        public List<Asset> GetAssets()
        {
            List<Asset> foundAssets;
            Asset readAsset;

            string queryString = "SELECT * FROM Assets";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader assetReader = readCommand.ExecuteReader();
                foundAssets = new List<Asset>();
                while (assetReader.Read())
                {
                    readAsset = GetAssetFromReader(assetReader);
                    foundAssets.Add(readAsset);
                }
            }

                return foundAssets;
        }

        public bool UpdateAsset(Asset asset)
        {
            int rowsInserted = 0;
            string queryString = "UPDATE Assets SET name = @Name, notes = @Notes, capacity = @Capacity, longitude = @Longitude, latitude = @Latitude, " +
                                 "contractStart = @ContractStart, contractEnd = @ContractEnd, approvedBy = @ApprovedBy, approvedAt = @ApprovedAt, modifiedBy = @ModifiedBy, modifiedAt = @ModifiedAt, " +
                                 "fk_Counterpart_ID = (SELECT id from Counterparts where id = @Counterpart), "  +
                                 "fk_Area_ID = (SELECT id from Areas where id = @Area), " +
                                 "fk_AssetType_ID = (SELECT id from AssetTypes where id = @AssetType), " +
                                 "fk_TechnologyType_ID = (SELECT id from TechnologyTypes where id = @TechType), " +
                                 "fk_State_ID = (SELECT id from States where id = @State) " + 
                                 "WHERE id = @ID";
            using (var con = new SqlConnection(_connectionString))
            using (var insertQuery = new SqlCommand(queryString, con))
            {
                insertQuery.Parameters.AddWithValue("Name", asset.Name);
                insertQuery.Parameters.AddWithValue("Notes", asset.Notes);
                insertQuery.Parameters.AddWithValue("Capacity", asset.Capacity);
                insertQuery.Parameters.AddWithValue("Longitude", asset.Longtitude);
                insertQuery.Parameters.AddWithValue("Latitude", asset.Latitude);
                insertQuery.Parameters.AddWithValue("ContractStart", asset.ContractStart);
                insertQuery.Parameters.AddWithValue("ContractEnd", asset.ContractEnd);
                insertQuery.Parameters.AddWithValue("ApprovedBy", asset.ApprovedBy);
                insertQuery.Parameters.AddWithValue("ApprovedAt", asset.ApprovedAt);
                insertQuery.Parameters.AddWithValue("ModifiedBy", asset.ModifiedBy);
                insertQuery.Parameters.AddWithValue("ModifiedAt", asset.ModifiedAt);
                insertQuery.Parameters.AddWithValue("Counterpart", asset.Counterpart.ID);
                insertQuery.Parameters.AddWithValue("Area", asset.Area.ID);
                insertQuery.Parameters.AddWithValue("AssetType", asset.AssetType.ID);
                insertQuery.Parameters.AddWithValue("TechType", asset.technologyType.ID);
                insertQuery.Parameters.AddWithValue("State", asset.state.ID);
                insertQuery.Parameters.AddWithValue("ID", asset.ID);

                if (con != null)
                {
                    con.Open();
                    rowsInserted = insertQuery.ExecuteNonQuery();
                }
            }
            return (rowsInserted > 0);
        }

        public bool AddAsset(Asset asset)
        {
            int rowsInserted = 0;
            string queryString = "INSERT INTO Assets(name, notes, capacity, longitude, latitude, " +
                                 "contractStart, contractEnd, modifiedBy, " +
                                 "ModifiedAt, fk_Counterpart_ID, fk_Area_ID, fk_AssetType_ID, fk_TechnologyType_ID, fk_State_ID )" +
                                 "VALUES (@Name, @Notes, @Capacity, @Longitude, @Latitude, " +
                                 "@ContractStart, @ContractEnd, @ModifiedBy, @ModifiedAt, " +
                                 "(SELECT id from Counterparts where id = @Counterpart), " +"" +
                                 "(SELECT id from Counterparts where id = @Area), " +
                                 "(SELECT id from Counterparts where id = @AssetType), "  +
                                 "(SELECT id from Counterparts where id = @TechType), " +
                                 "(SELECT id from Counterparts where id = @State))";
            using (var con = new SqlConnection(_connectionString))
            using (var insertQuery = new SqlCommand(queryString, con))
            {
                insertQuery.Parameters.AddWithValue("Name", asset.Name);
                insertQuery.Parameters.AddWithValue("Notes", asset.Notes);
                insertQuery.Parameters.AddWithValue("Capacity", asset.Capacity);
                insertQuery.Parameters.AddWithValue("Longitude", asset.Longtitude);
                insertQuery.Parameters.AddWithValue("Latitude", asset.Latitude);
                insertQuery.Parameters.AddWithValue("ContractStart", asset.ContractStart);
                insertQuery.Parameters.AddWithValue("ContractEnd", asset.ContractEnd);
                insertQuery.Parameters.AddWithValue("ModifiedBy", asset.ModifiedBy);
                insertQuery.Parameters.AddWithValue("ModifiedAt", asset.ModifiedAt);
                insertQuery.Parameters.AddWithValue("Counterpart", asset.Counterpart.ID);
                insertQuery.Parameters.AddWithValue("Area", asset.Area.ID);
                insertQuery.Parameters.AddWithValue("AssetType", asset.AssetType.ID);
                insertQuery.Parameters.AddWithValue("TechType", asset.technologyType.ID);
                insertQuery.Parameters.AddWithValue("State", asset.state.ID);

                if (con != null)
                {
                    con.Open();
                    rowsInserted = insertQuery.ExecuteNonQuery();
                }
            }
            return (rowsInserted > 0);
        }
        public bool DeleteAsset(int id)
        {
            int rowsAffected = 0;
            string queryString = "DELETE FROM Assets WHERE id = @id";

            using (var conn = new SqlConnection(_connectionString))
            using (var deleteQuery = new SqlCommand(queryString, conn))
            {
                deleteQuery.Parameters.AddWithValue("id", id);

                if (conn != null)
                {
                    conn.Open();
                    rowsAffected = deleteQuery.ExecuteNonQuery();
                }
            }
            return (rowsAffected > 0);
        }
    }
}
