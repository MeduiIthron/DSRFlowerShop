namespace DSRFlowerShop.BouquetService;

using DSRFlowerShop.API.Bouquets.Models;
using DSRFlowerShop.API.Flowers.Models;

public interface IBouquetService 
{    
    Task<IEnumerable<BouquetModel>> GetBouquets(int dealerID, int offset = 0, int limit = 10);
    Task<BouquetModel> GetBouquet(int dealerID, int BouquetId);
    Task<BouquetModel> AddBouquet(AddBouquetModel model);
    Task<BouquetModel> AddFlower(BouquetModel model, BouquetFlowerModel flower);
    Task UpdateBouquet(int dealerID, int id, UpdateBouquetModel model);
    Task DeleteBouquet(int dealerID, int BouquetId);
}