using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Service
{
    public interface IAssetServiceConnection
    {
        public Task<Asset> GetAssetAsync(int id);
        public Task<List<Asset>> GetAssetsAsync();
        public Task<bool> AddAssetAsync(Asset asset);
        public Task<bool> UpdateAssetAsync(Asset asset);
        public Task<bool> DeleteAssetAsync(int id);
    }
}
