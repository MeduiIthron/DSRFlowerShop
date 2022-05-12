namespace DSRFlowerShop.Api.Controllers.Flower.Models;

using AutoMapper;
using DSRFlowerShop.FlowerService.Models;
public class FlowerResponse
{
    public int Id { get; set; }
    public int DealerID { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; } = string.Empty;
    public float Price { get; set; } = 0.0F;
}

public class FlowerResponseProfile : Profile
{
    public FlowerResponseProfile()
    {
        CreateMap<FlowerModel, FlowerResponse>();
    }
}