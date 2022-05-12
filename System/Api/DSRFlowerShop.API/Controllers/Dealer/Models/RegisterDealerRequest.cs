namespace DSRFlowerShop.Api.Controllers.Dealer.Models;

using FluentValidation;
using AutoMapper;
using DSRFlowerShop.DealerService.Models;

public class RegisterDealerRequest
{
    public string Login { get; set; }
    public string Password { get; set; }
}

public class RegisterDealerRequestValidator : AbstractValidator<RegisterDealerRequest>
{
    public RegisterDealerRequestValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Login is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}

public class CreateDealerRequestProfile : Profile
{
    public CreateDealerRequestProfile()
    {
        CreateMap<RegisterDealerRequest, RegisterDealerModel>();
    }
}