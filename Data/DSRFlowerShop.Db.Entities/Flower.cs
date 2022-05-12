using DSRFlowerShop.Db.Entities.Common;

namespace DSRFlowerShop.Db.Entities;

public class Flower: BaseEntity
{
    public int DealerID { get; set; }
    public Dealer Dealer { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public float Price { get; set; }
    public ICollection<Bouquet> Bouquets { get; set; }
    public ICollection<FlowerList> FlowerLists { get; set; }
    public ICollection<FlowerCounter> Counters { get; set; }

    public Flower()
    {
        Bouquets = new List<Bouquet>();
        FlowerLists = new List<FlowerList>();
        Counters = new List<FlowerCounter>();
    }
}