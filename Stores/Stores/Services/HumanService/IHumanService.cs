using Stores.Entities;

namespace Stores.Services.HumanService
{
    public interface IHumanService
    {
        Task<List<Human>> GetHumans();
        Task<Human?> GetHumanById(int humanId);
        Task<Human> CreateHuman(Human human);
        Task<Human?> EditHuman(int humanId, Human human);
        Task<bool> DeleteHuman(int humanId);
    }
}
