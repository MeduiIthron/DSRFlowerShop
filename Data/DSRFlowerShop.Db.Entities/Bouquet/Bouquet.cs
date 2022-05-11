namespace DSRFlowerShop.Db.Entities;

using DSRFlowerShop.Common;

public class Bouquet: BaseEntity 
{
    public int DealerID { get; set; }
    public Dealer Dealer { get; set; }
    public BouquetStatus Status { get; set; } = BouquetStatus.Edited;
    public ICollection<Flower> Flowers { get; set; }
}