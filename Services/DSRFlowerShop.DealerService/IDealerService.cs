using DSRFlowerShop.DealerService.Models;

namespace DSRFlowerShop.DealerService;

public interface IDealerService
{
    Task<DealerModel> RegisterDealer(RegisterDealerModel dealer);
}