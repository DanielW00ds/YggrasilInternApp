using ModelLiberary;
using YggdrasilAPI.DBConnection;

namespace YggdrasilAPI.BusinessLogic
{
    public class CounterpartDataControl : ICounterpartData
    {
        ICounterpartAccess _cpAccess;
        public CounterpartDataControl(ICounterpartAccess inCounterpartAccess)
        {
            _cpAccess = inCounterpartAccess;
        }
        public List<Counterpart>? Get()
        {
            List<Counterpart>? foundCounterparts;
            try
            {
                foundCounterparts = _cpAccess.GetCounterparts();
            }
            catch
            {
                foundCounterparts = null;
            }
            return foundCounterparts;
        }
    }
}
