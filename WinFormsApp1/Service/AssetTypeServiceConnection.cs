using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormsApp1.Service
{
    public class AssetTypeServiceConnection : IAssetTypeServiceConnection
    {
        public async Task<List<AssetType>> GetAssetTypesAsync()
        {
            APIConnectionDetails.SetUrl("AssetTypes");
            string json = await APIConnectionDetails.getHTTP().GetStringAsync(APIConnectionDetails.Url);
            List<AssetType>? assetTypes = JsonSerializer.Deserialize<List<AssetType>>(json, APIConnectionDetails.JOptions());
            return assetTypes;
        }
    }
}
