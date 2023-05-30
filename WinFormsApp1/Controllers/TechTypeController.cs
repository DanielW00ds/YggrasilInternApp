using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Service;

namespace WinFormsApp1.Controllers
{
    public class TechTypeController
    {
        private ITechTypeServiceConnection _ttConnection = new TechTypeServiceConnection();
        public async Task<List<TechnologyType>> GetTechTypesAsync()
        {
            List<TechnologyType> techTypes = await _ttConnection.GetTechTypesAsync();
            return techTypes;
        }
    }
}
