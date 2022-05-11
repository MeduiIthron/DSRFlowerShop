namespace DSRFlowerShop.Db.Entities;

public class Category: BaseEntity 
{
    public int DealerID { get; set; }
    public Dealer Dealer { get; set; }
    public string Name { get; set; }
    public ICollection<Flower> Flowers;
}