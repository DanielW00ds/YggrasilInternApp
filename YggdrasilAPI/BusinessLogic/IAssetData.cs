using ModelLiberary;

namespace YggdrasilAPI.BusinessLogic
{
    public interface IAssetData
    {
        Asset? get(int id);
        List<Asset>? get();
        bool Post(Asset asset);
        bool Put(Asset asset);
        bool Delete(int id);
    }
}
