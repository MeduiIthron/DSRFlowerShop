namespace DSRFlowerShop.DealerService.Models;

using AutoMapper;
using FluentValidation;
using DSRFlowerShop.Db.Entities;

public class DealerModel
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}

public class DealerModelValidator: AbstractValidator<DealerModel> {
    
    public DealerModelValidator() {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Login is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}

public class DealerModelProfile : Profile
{
    public DealerModelProfile()
    {
        CreateMap<Dealer, DealerModel>();
    }
}