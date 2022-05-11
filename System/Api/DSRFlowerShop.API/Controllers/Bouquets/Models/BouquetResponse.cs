namespace DSRFlowerShop.API.Controllers.Bouquets.Models;

using AutoMapper;
using DSRFlowerShop.API.Bouquets.Models;
using DSRFlowerShop.API.Flowers.Models;
using DSRFlowerShop.Common;

public class BouquetResponse
{
    public int Id { get; set; }
    public int DealerID { get; set; }
    public BouquetStatus Status { get; set; }

    public ICollection<FlowerModel> Flowers { get; set; }
}

public class BouquetResponseProfile : Profile
{
    public BouquetResponseProfile()
    {
        CreateMap<BouquetModel, BouquetResponse>();
    }
}
