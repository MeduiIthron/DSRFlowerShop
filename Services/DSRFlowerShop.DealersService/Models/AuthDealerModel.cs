namespace DSRFlowerShop.API.Dealers.Models;

using AutoMapper;
using FluentValidation;
using DSRFlowerShop.Db.Entities;

public class AuthDealerModel
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}

public class AuthDealerModelValidator : AbstractValidator<AuthDealerModel> {
    
    public AuthDealerModelValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Login is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}

public class AuthDealerModelProfile : Profile
{
    public AuthDealerModelProfile()
    {
        CreateMap<Dealer, AuthDealerModel>();
    }
}
