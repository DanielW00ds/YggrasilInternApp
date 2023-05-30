using ModelLiberary;

namespace YggdrasilAPI.DBConnection
{
    public interface IStateAccess
    {
        public State GetState(int id);
        public List<State> GetStates();
    }
}
