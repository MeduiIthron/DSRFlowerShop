namespace DSRFlowerShop.API.Bouquets.Models;

using DSRFlowerShop.API.Flowers.Models;
using DSRFlowerShop.Common;

public class BouquetModel {
    public int Id { get; set; }
    public int DealerID { get; set; }
    public BouquetStatus Status { get; set; }
    public ICollection<FlowerModel> Flowers { get; set; }
}