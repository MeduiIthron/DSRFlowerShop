namespace DSRFlowerShop.BouquetService;

using DSRFlowerShop.API.Bouquets.Models;

public interface IBouquetService 
{    
    Task<IEnumerable<BouquetModel>> GetBouquets(int dealerID, int offset = 0, int limit = 10);
    Task<BouquetModel> GetBouquet(int dealerID, int BouquetId);
    Task<BouquetModel> AddBouquet(AddBouquetModel model);
    Task UpdateBouquet(int dealerID, int id, UpdateBouquetModel model);
    Task DeleteBouquet(int dealerID, int BouquetId);
}