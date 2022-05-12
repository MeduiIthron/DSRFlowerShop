namespace DSRFlowerShop.BouquetService.Models;

using AutoMapper;
using DSRFlowerShop.Db.Entities;
using FluentValidation;

public class UpdateBouquetModel {
    public int Id { get; set; }
    public int DealerID { get; set; }
    public string Status { get; set; }
}

public class UpdateBouquetModelValidator: AbstractValidator<UpdateBouquetModel> {
    
    public UpdateBouquetModelValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
        
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("Dealer is required.");
        
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required.");
    }
}

public class UpdateBouquetModelProfile : Profile
{
    public UpdateBouquetModelProfile()
    {
        CreateMap<UpdateBouquetModel, Bouquet>();
    }
}