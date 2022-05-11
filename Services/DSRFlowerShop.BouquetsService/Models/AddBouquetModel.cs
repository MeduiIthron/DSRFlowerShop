namespace DSRFlowerShop.API.Bouquets.Models;

using AutoMapper;
using FluentValidation;
using DSRFlowerShop.Db.Entities;

public class AddBouquetModel {
    public int DealerID { get; set; }
}

public class AddBouquetModelValidator: AbstractValidator<AddBouquetModel> {
    
    public AddBouquetModelValidator() {
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("Dealer is required.");
    }
}