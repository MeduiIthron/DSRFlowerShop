namespace DSRFlowerShop.API.Controllers.Bouquets.Models;

using AutoMapper;
using DSRBouquetShop.API.Bouquets.Models;
using DSRFlowerShop.Common;
public class BouquetResponse
{
    public int Id { get; set; }
    public int DealerID { get; set; }
    public BouquetStatus Status { get; set; }
}

public class BouquetResponseProfile : Profile
{
    public BouquetResponseProfile()
    {
        CreateMap<BouquetModel, BouquetResponse>();
    }
}
