using DSRFlowerShop.Db.Entities.Common;

namespace DSRFlowerShop.Db.Entities;

public class Bouquet: BaseEntity
{
    public int DealerID { get; set; }
    public Dealer Dealer { get; set; }
    public string Status { get; set; }
    public ICollection<Flower> Flowers { get; set; }
    public ICollection<FlowerCounter> Counters { get; set; }
    
    public Bouquet()
    {
        Flowers = new List<Flower>();
        Status = "editing";
        Counters = new List<FlowerCounter>();
    }
}