using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Service;

namespace WinFormsApp1.Controllers
{
    public class CounterpartController
    {
        private ICounterpartServiceConnection _cpConnect = new CounterpartServiceConnection();
        public async Task<List<Counterpart>> GetCounterpartsAsync()
        {
            List<Counterpart> counterparts = await _cpConnect.GetCounterpartsAsync();
            return counterparts;
        }
    }
}
