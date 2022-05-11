﻿namespace DSRFlowerShop.API.Dealers.Models;

using AutoMapper;
using FluentValidation;
using DSRFlowerShop.Db.Entities;

public class RegisterDealerModel
{
    public string Login { get; set; }
    public string Password { get; set; }
}

public class RegisterDealerModelValidator : AbstractValidator<AuthDealerModel> {
    
    public RegisterDealerModelValidator() {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Login is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}

public class RegisterDealerModelProfile : Profile
{
    public RegisterDealerModelProfile()
    {
        CreateMap<Dealer, AuthDealerModel>();
    }
}
