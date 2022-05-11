namespace DSRFlowerShop.API.Bouquets.Models;

using AutoMapper;
using FluentValidation;
using DSRFlowerShop.Db.Entities;

using DSRFlowerShop.Common;

public class UpdateBouquetModel {
    public int DealerID { get; set; }
    public BouquetStatus Status { get; set; }
}

public class UpdateBouquetModelValidator: AbstractValidator<UpdateBouquetModel> {
    
    public UpdateBouquetModelValidator() {
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("Dealer is required.");
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required.");
    }
}