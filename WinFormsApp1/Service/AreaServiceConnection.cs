using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormsApp1.Service
{
    public class AreaServiceConnection : IAreaServiceConnection
    {
        public async Task<List<Area>> GetAreasAsync()
        {
            APIConnectionDetails.SetUrl("Areas");
            string json = await APIConnectionDetails.getHTTP().GetStringAsync(APIConnectionDetails.Url);
            List<Area>? areaList = JsonSerializer.Deserialize<List<Area>>(json, APIConnectionDetails.JOptions());
            return areaList;
        }
    }
}
