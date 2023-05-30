using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Service;

namespace WinFormsApp1.Controllers
{
    public class StateController
    {
        private IStateServiceConnection _sConnect = new StateServiceConnection();
        public async Task<List<State>> GetStatesAsync()
        {
            List<State> states = await _sConnect.GetStatesAsync();
            return states;
        }
    }
}
