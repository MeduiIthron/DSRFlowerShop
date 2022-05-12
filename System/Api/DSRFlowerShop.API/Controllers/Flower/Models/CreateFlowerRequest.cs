namespace DSRFlowerShop.API.Controllers.Flowers.Models;

using AutoMapper;
using FluentValidation;
using DSRFlowerShop.API.Flowers.Models;

public class CreateFlowerRequest
{
    public int DealerID { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; } = string.Empty;
    public float Price { get; set; } = 0.0F;
}

public class CreateFlowerResponseValidator : AbstractValidator<CreateFlowerRequest>
{
    public CreateFlowerResponseValidator()
    {
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("DealerID is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required.");
    }
}

public class CreateFlowerRequestProfile : Profile
{
    public CreateFlowerRequestProfile()
    {
        CreateMap<CreateFlowerRequest, CreateFlowerModel>();
    }
}

