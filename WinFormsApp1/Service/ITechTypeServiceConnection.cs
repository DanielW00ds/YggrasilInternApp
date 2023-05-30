using ModelLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Service
{
    public interface ITechTypeServiceConnection
    {
        public Task<List<TechnologyType>> GetTechTypesAsync();
    }
}
