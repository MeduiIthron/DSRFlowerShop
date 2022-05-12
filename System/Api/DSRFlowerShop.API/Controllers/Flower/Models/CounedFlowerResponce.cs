using DSRFlowerShop.BouquetService.Models;

namespace DSRFlowerShop.Api.Controllers.Flower.Models;

using AutoMapper;
using DSRFlowerShop.FlowerService.Models;
public class CountedFlowerResponse
{
    public FlowerResponse Flower;
    public int Count;
}

public class CountedFlowerResponseProfile : Profile
{
    public CountedFlowerResponseProfile()
    {
        CreateMap<FlowerModel, CountedFlowerResponse>();
    }
}