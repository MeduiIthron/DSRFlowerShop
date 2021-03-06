using DSRFlowerShop.FlowerService.Models;

namespace DSRFlowerShop.FlowerService;

using DSRFlowerShop.API.Flowers.Models;

public interface IFlowerService
{
    Task<IEnumerable<FlowerModel>> GetFlowers(int dealerID, int offset = 0, int limit = 10);
    Task<FlowerModel> GetFlower(int dealerID, int FlowerId);
    Task<FlowerModel> AddFlower(CreateFlowerModel model);
    Task UpdateFlower(UpdateFlowerModel model);
    Task DeleteFlower(int dealerID, int FlowerId);
}