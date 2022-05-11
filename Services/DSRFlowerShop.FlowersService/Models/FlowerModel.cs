namespace DSRFlowerShop.API.Flowers.Models;

using AutoMapper;
using DSRFlowerShop.Db.Entities;

public class FlowerModel
{
    public int Id { get; set; }
    public int Dealer { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; } = string.Empty;
    public float Price { get; set; } = 0.0F;
}