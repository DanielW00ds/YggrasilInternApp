using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Service;

namespace WinFormsApp1.Controllers
{
    public class AssetTypeController
    {
        private IAssetTypeServiceConnection _atConnect = new AssetTypeServiceConnection();
        public async Task<List<AssetType>> GetAssetTypesAsync()
        {
            List<AssetType> assetTypes = await _atConnect.GetAssetTypesAsync();
            return assetTypes;
        }
    }
}
