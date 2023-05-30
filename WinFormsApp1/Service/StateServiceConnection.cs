using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormsApp1.Service
{
    public class StateServiceConnection : IStateServiceConnection
    {
        public async Task<List<State>> GetStatesAsync()
        {
            APIConnectionDetails.SetUrl("State");
            string json = await APIConnectionDetails.getHTTP().GetStringAsync(APIConnectionDetails.Url);
            List<State>? states = JsonSerializer.Deserialize<List<State>>(json, APIConnectionDetails.JOptions());
            return states;
        }
    }
}
