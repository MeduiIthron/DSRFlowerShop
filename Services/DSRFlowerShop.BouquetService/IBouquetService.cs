namespace DSRFlowerShop.BouquetService;

using DSRFlowerShop.BouquetService.Models;

public interface IBouquetService
{
    Task<BouquetModel> RegisterBouquet(CreateBouquetModel bouquet);
    Task<IEnumerable<BouquetModel>> GetBouquets(int dealerID, int offset = 0, int limit = 10);
    Task UpdateBouquet(UpdateBouquetModel bouquet);
    
    Task<BouquetModel> AddFlowerBoquet(AddFlowerBouquetModel operation);
}