namespace DSRFlowerShop.API.Controllers.Flowers.Models;

using AutoMapper;
using FluentValidation;
using DSRFlowerShop.API.Flowers.Models;

public class AddFlowerRequest
{
    public int DealerID { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; } = string.Empty;
    public float Price { get; set; } = 0.0F;
}

public class AddFlowerResponseValidator : AbstractValidator<AddFlowerRequest>
{
    public AddFlowerResponseValidator()
    {
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("DealerID is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required.");
    }
}

public class AddFlowerRequestProfile : Profile
{
    public AddFlowerRequestProfile()
    {
        CreateMap<AddFlowerRequest, AddFlowerModel>();
    }
}

