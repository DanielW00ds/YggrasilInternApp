using ModelLiberary;
using YggdrasilAPI.DBConnection;

namespace YggdrasilAPI.BusinessLogic
{
    public class StateDataControl : IStateData
    {
        IStateAccess _stateAccess;
        public StateDataControl(IStateAccess inStateAccess)
        {
            _stateAccess = inStateAccess;
        }

        public List<State>? Get()
        {
            List<State>? foundStates;
            try
            {
                foundStates = _stateAccess.GetStates();
            }
            catch
            {
                foundStates = null;
            }
            return foundStates;
        }
    }
}
