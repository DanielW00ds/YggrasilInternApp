using ModelLiberary;

namespace YggdrasilAPI.DBConnection
{
    public interface IAssetAccess
    {
        public Asset GetAsset(int id);
        public List<Asset> GetAssets();
        public bool AddAsset(Asset asset);
        public bool UpdateAsset(Asset asset);
        public bool DeleteAsset(int id);
    }
}
