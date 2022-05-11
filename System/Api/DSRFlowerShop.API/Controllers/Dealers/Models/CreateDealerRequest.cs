namespace DSRFlowerShop.API.Controllers.Dealers.Models;

using FluentValidation;

public class CreateDealerRequest
{
    public string Login { get; set; }
    public string Password {  get; set; }
}

public class CreateDealerRequestValidator : AbstractValidator<CreateDealerRequest>
{
    public CreateDealerRequestValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Login is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}