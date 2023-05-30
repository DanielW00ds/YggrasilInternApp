using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormsApp1.Service
{
    internal class TechTypeServiceConnection : ITechTypeServiceConnection
    {
        public async Task<List<TechnologyType>> GetTechTypesAsync()
        {
            APIConnectionDetails.SetUrl("TechnologyTypes");
            string json = await APIConnectionDetails.getHTTP().GetStringAsync(APIConnectionDetails.Url);
            List<TechnologyType>? techTypes = JsonSerializer.Deserialize<List<TechnologyType>>(json, APIConnectionDetails.JOptions());
            return techTypes;
        }
    }
}
