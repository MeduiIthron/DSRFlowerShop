namespace DSRFlowerShop.BouquetService.Models;

using DSRFlowerShop.FlowerService.Models;

public class BouquetModel {
    public int Id { get; set; }
    public int DealerID { get; set; }
    public string Status { get; set; }
    public IEnumerable<FlowerModel> Flowers { get; set; }
}