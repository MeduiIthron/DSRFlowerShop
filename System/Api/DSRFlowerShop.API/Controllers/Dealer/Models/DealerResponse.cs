namespace DSRFlowerShop.Api.Controllers.Dealer.Models;

using AutoMapper;
using DSRFlowerShop.DealerService.Models;

public class DealerResponse
{
    public int Id { get; set; }
}

public class CreateDealerResponseProfile : Profile
{
    public CreateDealerResponseProfile()
    {
        CreateMap<DealerModel, DealerResponse>();
    }
}