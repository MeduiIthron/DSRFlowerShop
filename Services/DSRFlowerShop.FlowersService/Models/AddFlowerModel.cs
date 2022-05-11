namespace DSRFlowerShop.API.Flowers.Models;

using AutoMapper;
using FluentValidation;
using DSRFlowerShop.Db.Entities;

public class AddFlowerModel {
    public int DealerID { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; } = string.Empty;
    public float Price { get; set; } = 0.0F;
}

public class AddFlowerModelValidator: AbstractValidator<AddFlowerModel> {
    
    public AddFlowerModelValidator() {
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("Dealer is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required.");
    }
}