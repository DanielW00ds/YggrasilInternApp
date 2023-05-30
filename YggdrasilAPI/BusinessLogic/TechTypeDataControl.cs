using ModelLiberary;
using YggdrasilAPI.DBConnection;

namespace YggdrasilAPI.BusinessLogic
{
    public class TechTypeDataControl : ITechTypeData
    {
        ITechTypeAccess _ttAccess;
        public TechTypeDataControl(ITechTypeAccess inTtAccess)
        {
            _ttAccess = inTtAccess;
        }

        public List<TechnologyType>? Get()
        {
            List<TechnologyType>? foundTechTypes;
            try
            {
                foundTechTypes = _ttAccess.GetTechTypes();
            }
            catch
            {
                foundTechTypes = null;
            }
            return foundTechTypes;
        }
    }
}
