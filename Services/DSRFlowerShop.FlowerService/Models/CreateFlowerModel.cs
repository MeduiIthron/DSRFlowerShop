namespace DSRFlowerShop.API.Flowers.Models;

using AutoMapper;
using DSRFlowerShop.Db.Entities;
using FluentValidation;

public class CreateFlowerModel {
    public int DealerID { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; } = string.Empty;
    public float Price { get; set; } = 0.0F;
}

public class CreateFlowerModelValidator: AbstractValidator<CreateFlowerModel> {
    
    public CreateFlowerModelValidator() {
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("Dealer is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required.");
    }
}

public class CreateFlowerModelProfile : Profile
{
    public CreateFlowerModelProfile()
    {
        CreateMap<CreateFlowerModel, Flower>();
    }
}