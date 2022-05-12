namespace DSRFlowerShop.Api.Controllers.Bouquet.Models;

using FluentValidation;
using AutoMapper;
using DSRFlowerShop.BouquetService.Models;


public class CreateBouquetRequest
{
    public int DealerID { get; set; }
}

public class CreateBouquetRequestValidator: AbstractValidator<CreateBouquetRequest> {
    
    public CreateBouquetRequestValidator() {
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("Dealer is required.");
    }
}

public class CreateBouquetRequestProfile : Profile
{
    public CreateBouquetRequestProfile()
    {
        CreateMap<CreateBouquetRequest, CreateBouquetModel>();
    }
}