using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Service
{
    public interface IAssetTypeServiceConnection
    {
        public Task<List<AssetType>> GetAssetTypesAsync();
    }
}
