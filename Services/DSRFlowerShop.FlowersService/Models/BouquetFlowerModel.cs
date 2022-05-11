namespace DSRFlowerShop.API.Flowers.Models;

using AutoMapper;
using FluentValidation;
using DSRFlowerShop.Db.Entities;

public class BouquetFlowerModel {
    public int DealerID { get; set; }
    public int Id { get; set; }
}

public class BouquetFlowerModelValidator: AbstractValidator<BouquetFlowerModel> {
    
    public BouquetFlowerModelValidator() {
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("Dealer is required.");
    }
}