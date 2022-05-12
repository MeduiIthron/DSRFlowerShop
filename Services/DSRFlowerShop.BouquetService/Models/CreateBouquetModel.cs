namespace DSRFlowerShop.BouquetService.Models;

using FluentValidation;
using AutoMapper;
using DSRFlowerShop.Db.Entities;

public class CreateBouquetModel
{
    public int DealerID { get; set; }
}

public class CreateBouquetModelValidator: AbstractValidator<CreateBouquetModel> {
    
    public CreateBouquetModelValidator() {
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("Dealer is required.");
    }
}

public class CreateBouquetModelProfile : Profile
{
    public CreateBouquetModelProfile()
    {
        CreateMap<CreateBouquetModel, Bouquet>();
    }
}