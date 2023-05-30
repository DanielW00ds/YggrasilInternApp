using ModelLiberary;

namespace YggdrasilAPI.DBConnection
{
    public interface ICounterpartAccess
    {
        public Counterpart GetCounterpart(int id);
        public List<Counterpart> GetCounterparts();
    }
}
