using ModelLiberary;
using WinFormsApp1.Service;

namespace WinFormsApp1.Controllers
{
    public class AreaController
    {
        private IAreaServiceConnection _areaConnect = new AreaServiceConnection();
        public async Task<List<Area>> GetAreasAsync()
        {
            List<Area> areaList = await _areaConnect.GetAreasAsync();
            return areaList;
        }
    }
}
