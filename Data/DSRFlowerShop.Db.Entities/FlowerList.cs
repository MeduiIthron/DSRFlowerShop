using DSRFlowerShop.Db.Entities.Common;

namespace DSRFlowerShop.Db.Entities;

public class FlowerList: BaseEntity
{
    public int DealerID { get; set; }
    public Dealer Dealer { get; set; }
    public string Name { get; set; }
    public ICollection<Flower> Flowers { get; set; }
    
    public FlowerList()
    {
        Flowers = new List<Flower>();
    }
}