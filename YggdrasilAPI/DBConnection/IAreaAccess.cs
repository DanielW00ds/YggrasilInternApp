using ModelLiberary;

namespace YggdrasilAPI.DBConnection
{
    public interface IAreaAccess
    {
        public Area GetArea(int id);
        public List<Area> GetAreas();
    }
}
