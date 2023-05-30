using ModelLiberary;

namespace YggdrasilAPI.DBConnection
{
    public interface ITechTypeAccess
    {
        public TechnologyType GetTechType(int id);
        public List<TechnologyType> GetTechTypes();
    }
}
