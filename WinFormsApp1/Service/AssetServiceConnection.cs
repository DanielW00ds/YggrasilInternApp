using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ModelLiberary;

namespace WinFormsApp1.Service
{
    public class AssetServiceConnection : IAssetServiceConnection
    {
        public async Task<Asset> GetAssetAsync(int id)
        {
            APIConnectionDetails.SetUrl($"Asset/{id}");
            string json = await APIConnectionDetails.getHTTP().GetStringAsync(APIConnectionDetails.Url);
            Asset? asset = JsonSerializer.Deserialize<Asset>(json, APIConnectionDetails.JOptions());
            return asset;
        }

        public async Task<List<Asset>> GetAssetsAsync()
        {
            List<Asset>? assets;
            APIConnectionDetails.SetUrl("Assets");
            string json = await APIConnectionDetails.getHTTP().GetStringAsync(APIConnectionDetails.Url);
            try
            {
                assets = JsonSerializer.Deserialize<List<Asset>>(json, APIConnectionDetails.JOptions());
            }
            catch
            {
                assets = new List<Asset>();
            }
            return assets;
        }

        public async Task<bool> AddAssetAsync(Asset asset)
        {
            APIConnectionDetails.SetUrl("Assets");
            var successCheck = await APIConnectionDetails.getHTTP().PostAsJsonAsync(APIConnectionDetails.Url, asset, APIConnectionDetails.JOptions());
            return successCheck.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAssetAsync(Asset asset)
        {
            APIConnectionDetails.SetUrl($"Assets/{asset.ID}");
            var successCheck = await APIConnectionDetails.getHTTP().PutAsJsonAsync(APIConnectionDetails.Url, asset, APIConnectionDetails.JOptions());
            return successCheck.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAssetAsync(int id)
        {
            APIConnectionDetails.SetUrl($"Assets/{id}");
            var successCheck = await APIConnectionDetails.getHTTP().DeleteAsync(APIConnectionDetails.Url);
            return successCheck.IsSuccessStatusCode;
        }
    }
}
