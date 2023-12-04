using Microsoft.EntityFrameworkCore;
using Stores.Data;
using Stores.Entities;

namespace Stores.Services.HumanService
{
    public class HumanService : IHumanService
    {
        private readonly DataContext _context;

        public HumanService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Human>> GetHumans()
        {
            return await _context.Humans.ToListAsync();
        }

        public async Task<Human?> GetHumanById(int humanId)
        {
            return await _context.Humans.FindAsync(humanId);
        }

        public async Task<Human> CreateHuman(Human human)
        {
            _context.Humans.Add(human);
            await _context.SaveChangesAsync();
            return human;
        }

        public async Task<Human?> EditHuman(int humanId, Human human)
        {
            var dbHuman = await _context.Humans.FindAsync(humanId);

            if (dbHuman == null)
            {
                return null;
            }

            dbHuman.FirstName = human.FirstName;
            dbHuman.LastName = human.LastName;
            dbHuman.MiddleName = human.MiddleName;
            dbHuman.Birthdate = human.Birthdate;
            dbHuman.Email = human.Email;
            dbHuman.PhoneNumber = human.PhoneNumber;

            await _context.SaveChangesAsync();
            return dbHuman;
        }

        public async Task<bool> DeleteHuman(int humanId)
        {
            var human = await _context.Humans.FindAsync(humanId);

            if (human == null)
            {
                return false;
            }

            _context.Humans.Remove(human);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
