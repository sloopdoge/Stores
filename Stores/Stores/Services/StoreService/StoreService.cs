using Microsoft.EntityFrameworkCore;
using Stores.Data;
using Stores.Entities;

namespace Stores.Services.StoreService
{
    public class StoreService : IStoreService
    {
        private readonly DataContext _context;

        public StoreService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Store>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store?> GetStoreById(int storeId)
        {
            return await _context.Stores.FindAsync(storeId);
        }

        public async Task<Store> CreateStore(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task<Store?> EditStore(int storeId, Store store)
        {
            var dbStore = await _context.Stores.FindAsync(storeId);

            if (dbStore == null)
            {
                return null;
            }

            dbStore.Title = store.Title;
            dbStore.City = store.City;
            dbStore.Address = store.Address;
            dbStore.Email = store.Email;
            dbStore.PostCode = store.PostCode;
            dbStore.Owner = store.Owner;

            await _context.SaveChangesAsync();
            return dbStore;
        }

        public async Task<bool> DeleteStore(int storeId)
        {
            var store = await _context.Stores.FindAsync(storeId);

            if (store == null)
            {
                return false;
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
