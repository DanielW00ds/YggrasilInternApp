using ModelLiberary;
using YggdrasilAPI.DBConnection;

namespace YggdrasilAPI.BusinessLogic
{
    public class AssetTypeDataControl : IAssetTypeData
    {
        IAssetTypeAccess _atAcces;
        public AssetTypeDataControl(IAssetTypeAccess inAtAcces)
        {
            _atAcces = inAtAcces;
        }

        public List<AssetType>? Get()
        {
            List<AssetType>? foundAssetTypes;
            try
            {
                foundAssetTypes = _atAcces.GetAssetTypes();
            }
            catch
            {
                foundAssetTypes = null;
            }
            return foundAssetTypes;
        }
    }
}
