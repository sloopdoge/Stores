using Stores.Entities;

namespace Stores.Services.StoreService
{
    public interface IStoreService
    {
        Task<List<Store>> GetStores();
        Task<Store?> GetStoreById(int storeId);
        Task<Store> CreateStore(Store store);
        Task<Store?> EditStore(int storeId, Store store);
        Task<bool> DeleteStore(int storeId);
    }
}
