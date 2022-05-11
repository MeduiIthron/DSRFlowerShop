namespace DSRFlowerShop.API.Controllers.Dealers.Models;

using AutoMapper;
using DSRFlowerShop.API.Dealers.Models;
using FluentValidation;

public class UsingDealerRequest
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password {  get; set; }
}

public class UsingDealerRequestValidator : AbstractValidator<UsingDealerRequest>
{
    public UsingDealerRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Login is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}

public class UsingDealerRequestProfile : Profile
{
    public UsingDealerRequestProfile()
    {
        CreateMap<UsingDealerRequest, AuthDealerModel>();
    }
}