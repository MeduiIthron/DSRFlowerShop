using AutoMapper;
using DSRFlowerShop.API.Dealers.Models;

namespace DSRFlowerShop.API.Controllers.Dealers.Models;

public class DealerResponse
{
    public int Id { get; set; }
}

public class CreateDealerResponceProfile : Profile
{
    public CreateDealerResponceProfile()
    {
        CreateMap<DealerModel, DealerResponse>();
    }
}