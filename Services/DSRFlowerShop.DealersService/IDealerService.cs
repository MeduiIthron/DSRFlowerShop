namespace DSRFlowerShop.DealerService;

using DSRFlowerShop.API.Dealers.Models;

public interface IDealerService
{
    Task<DealerModel> CreateDealer(RegisterDealerModel dealer);
    Task<DealerModel> UsingDealer(AuthDealerModel dealer);
}