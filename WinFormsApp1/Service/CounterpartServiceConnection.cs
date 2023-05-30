using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormsApp1.Service
{
    public class CounterpartServiceConnection : ICounterpartServiceConnection
    {
        public async Task<List<Counterpart>> GetCounterpartsAsync()
        {
            APIConnectionDetails.SetUrl("Counterparts");
            string json = await APIConnectionDetails.getHTTP().GetStringAsync(APIConnectionDetails.Url);
            List<Counterpart>? counterparts = JsonSerializer.Deserialize<List<Counterpart>>(json, APIConnectionDetails.JOptions());
            return counterparts;
        }
    }
}
