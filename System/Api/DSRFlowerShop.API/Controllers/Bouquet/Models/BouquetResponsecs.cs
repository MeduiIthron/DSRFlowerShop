using DSRFlowerShop.Api.Controllers.Flower.Models;

namespace DSRFlowerShop.Api.Controllers.Bouquet.Models;

using DSRFlowerShop.FlowerService.Models;
using AutoMapper;
using DSRFlowerShop.BouquetService.Models;

public class BouquetResponse
{
    public int Id { get; set; }
    public int DealerID { get; set; }
    public string Status { get; set; }
    public float FullPrice { get; set; }
    public IEnumerable<FlowerResponse> Flowers { get; set; }
}