namespace DSRFlowerShop.API.Flowers.Models;

using AutoMapper;
using FluentValidation;
using DSRFlowerShop.Db.Entities;

public class UpdateFlowerModel
{
    public int Id { get; set; }
    public int DealerID { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; } = string.Empty;
    public float Price { get; set; } = 0.0F;
}

public class UpdateFlowerModelValidator : AbstractValidator<UpdateFlowerModel>
{
    public UpdateFlowerModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required.");
    }
}

public class UpdateFlowerModelProfile : Profile
{
    public UpdateFlowerModelProfile()
    {
        CreateMap<UpdateFlowerModel, Flower>();
    }
}