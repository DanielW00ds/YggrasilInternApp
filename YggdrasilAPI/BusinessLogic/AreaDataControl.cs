using ModelLiberary;
using YggdrasilAPI.DBConnection;

namespace YggdrasilAPI.BusinessLogic
{
    public class AreaDataControl : IAreaData
    {
        IAreaAccess _areaAccess;

        public AreaDataControl(IAreaAccess inAreaAccess)
        {
            _areaAccess = inAreaAccess;
        }
        public List<Area>? Get()
        {
            List<Area>? foundAreas;
            try
            {
                foundAreas = _areaAccess.GetAreas();
            }
            catch
            {
                foundAreas = null;
            }
            return foundAreas;
        }
    }
}
