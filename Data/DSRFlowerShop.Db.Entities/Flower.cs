namespace DSRFlowerShop.Db.Entities;

public class Flower: BaseEntity 
{
    public int DealerID { get; set; }
    public Dealer Dealer { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public float Price { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Bouquet> Bouquets { get; set; }
}