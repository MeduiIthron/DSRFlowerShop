using DSRFlowerShop.Db.Entities.Common;

namespace DSRFlowerShop.Db.Entities;

public class Dealer: BaseEntity
{
    public int DealerID { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public ICollection<Flower> Flowers { get; set; }
    public ICollection<Bouquet> Bouquets { get; set; }
    public ICollection<FlowerList> FlowerLists { get; set; }

    public Dealer()
    {
        Flowers = new List<Flower>();
        Bouquets = new List<Bouquet>();
        FlowerLists = new List<FlowerList>();
    }
}