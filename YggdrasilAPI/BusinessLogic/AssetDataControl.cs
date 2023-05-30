using ModelLiberary;
using YggdrasilAPI.DBConnection;

namespace YggdrasilAPI.BusinessLogic
{
    public class AssetDataControl : IAssetData
    {
        IAssetAccess _assetAccess;

        public AssetDataControl(IAssetAccess inAssetAccess)
        {
            _assetAccess = inAssetAccess;
        }
        public Asset? get(int id)
        {
            Asset? foundAsset;
            try
            {
                foundAsset = _assetAccess.GetAsset(id);
            }
            catch
            {
                foundAsset=null;
            }
            return foundAsset;
        }
        

        public List<Asset>? get()
        {
            List<Asset>? foundAssets;
            try
            {
                foundAssets = _assetAccess.GetAssets();
            }
            catch
            {
                foundAssets = null;
            }
            return foundAssets;
        }

        public bool Post(Asset asset)
        {
            bool succes = false;
            try
            {
                bool val = _assetAccess.AddAsset(asset);
                if (val) { succes = true; }
            }
            catch (Exception)
            {
                throw;
            }
            return succes;
        }
        public bool Put(Asset asset)
        {
            bool succes = false;
            try
            {
                bool val = _assetAccess.UpdateAsset(asset);
                if (val) { succes = true; }
            }
            catch (Exception)
            {
                throw;
            }
            return succes;
        }

        public bool Delete(int id)
        {
            bool succes = false;
            try
            {
                bool val = _assetAccess.DeleteAsset(id);
                if (val) { succes = true; }
            }
            catch (Exception)
            {
                throw;
            }
            return succes;
        }
    }
}
