namespace DSRFlowerShop.Db.Entities;

public class Dealer : BaseEntity
{
    public string Login { get; set; }
    public string Password { get; set; }
    public ICollection<Flower> Flowers;
    public ICollection<Bouquet> Bouquets;
    public ICollection<Category> Categories;
}