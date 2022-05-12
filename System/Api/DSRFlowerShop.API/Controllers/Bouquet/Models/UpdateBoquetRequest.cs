namespace DSRFlowerShop.Api.Controllers.Bouquet.Models;

using AutoMapper;
using DSRFlowerShop.BouquetService.Models;
using FluentValidation;

public class UpdateBouquetRequest
{
    public int Id { get; set; }
    public int DealerID { get; set; }
    public string Status { get; set; }
}

public class UpdateBouquetRequestValidator: AbstractValidator<UpdateBouquetRequest> {
    
    public UpdateBouquetRequestValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("Dealer is required.");
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required.");
    }
}

public class UpdateBouquetRequestProfile : Profile
{
    public UpdateBouquetRequestProfile()
    {
        CreateMap<UpdateBouquetRequest, UpdateBouquetModel>();
    }
}