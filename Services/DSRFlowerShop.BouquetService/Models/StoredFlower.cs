using DSRFlowerShop.FlowerService.Models;

namespace DSRFlowerShop.BouquetService.Models;

public class StoredFlower
{
    public FlowerModel Flower { get; set; }
    public int Count { get; set; }
}