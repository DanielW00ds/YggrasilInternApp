using ModelLiberary;

namespace YggdrasilAPI.DBConnection
{
    public interface IAssetTypeAccess
    {
        public AssetType GetAssetType(int id);
        public List<AssetType> GetAssetTypes();
    }
}
