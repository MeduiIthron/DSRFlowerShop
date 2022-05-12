using DSRFlowerShop.Db.Entities.Common;

namespace DSRFlowerShop.Db.Entities;

public class FlowerCounter: BaseEntity
{
    public int FlowerID { get; set; }
    public int BouquetID { get; set; }
    public Bouquet Bouquet { get; set; }
    public int Count { get; set; }
}