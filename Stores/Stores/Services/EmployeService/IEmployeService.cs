using Stores.Entities;

namespace Stores.Services.EmployeService
{
    public interface IEmployeService
    {
        Task<List<Employe>> GetEmployes();
        Task<Employe?> GetEmployeById(int employeId);
        Task<Employe> CreateEmploye(Employe employe);
        Task<Employe?> EditEmploye(int employeId, Employe employe);
        Task<bool> DeleteEmploye(int cemployeId);
    }
}
