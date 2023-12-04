using Microsoft.EntityFrameworkCore;
using Stores.Data;
using Stores.Entities;

namespace Stores.Services.EmployeService
{
    public class EmployeService : IEmployeService
    {
        private readonly DataContext _context;

        public EmployeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employe>> GetEmployes()
        {
            return await _context.Employes.ToListAsync();
        }

        public async Task<Employe?> GetEmployeById(int employeId)
        {
            return await _context.Employes.FindAsync(employeId);
        }

        public async Task<Employe> CreateEmploye(Employe employe)
        {
            _context.Employes.Add(employe);
            await _context.SaveChangesAsync();
            return employe;
        }

        public async Task<Employe?> EditEmploye(int employeId, Employe employe)
        {
            var dbEmploye = await _context.Employes.FindAsync(employeId);

            if (dbEmploye == null)
            {
                return null;
            }

            dbEmploye.HumanID = employe.HumanID;
            dbEmploye.DateOfWork = employe.DateOfWork;
            dbEmploye.Position = employe.Position;
            dbEmploye.StoreID = employe.StoreID;

            await _context.SaveChangesAsync();
            return dbEmploye;
        }

        public async Task<bool> DeleteEmploye(int employeId)
        {
            var employe = await _context.Employes.FindAsync(employeId);

            if (employe == null)
            {
                return false;
            }

            _context.Employes.Remove(employe);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
