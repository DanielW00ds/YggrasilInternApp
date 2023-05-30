using ModelLiberary;
using WinFormsApp1.Service;

namespace WinFormsApp1.Controllers
{
    public class AssetController
    {
        private IAssetServiceConnection _aConnect = new AssetServiceConnection();

        public async Task<List<Asset>> GetAssetsAsync()
        {
            List<Asset> assets = await _aConnect.GetAssetsAsync();
            return assets;
        }

        public async Task<Asset> GetAssetAsync(int id)
        {
            Asset asset = await _aConnect.GetAssetAsync(id);
            return asset;
        }

        public async Task<bool> AddAsset(Asset asset)
        {
            bool succes = await _aConnect.AddAssetAsync(asset);
            return succes;
        }
        public async Task<bool> UpdateAsset(Asset asset)
        {
            bool succes = await _aConnect.UpdateAssetAsync(asset);
            return succes;
        }

        public async Task<bool> DeleteAsset(int id){
            bool succes = await _aConnect.DeleteAssetAsync(id);
            return succes;
        }
    }
}
