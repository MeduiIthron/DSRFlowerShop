using AutoMapper;
using DSRFlowerShop.BouquetService.Models;
using FluentValidation;

namespace DSRFlowerShop.Api.Controllers.Bouquet.Models;

public class AddFlowerBouquetRequest
{
    public int BouquetID { get; set; }
    public int DealerID { get; set; }
    public int FlowerId { get; set; }
    public int Count { get; set; } = 1;
}

public class AddFlowerBouquetRequestValidator: AbstractValidator<AddFlowerBouquetRequest> {
    
    public AddFlowerBouquetRequestValidator() {
        RuleFor(x => x.BouquetID)
            .NotEmpty().WithMessage("BouquetID is required.");
        RuleFor(x => x.FlowerId)
            .NotEmpty().WithMessage("FlowerId is required.");
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("Dealer is required.");
    }
}

public class AddFlowerBouquetRequestProfile : Profile
{
    public AddFlowerBouquetRequestProfile()
    {
        CreateMap<AddFlowerBouquetRequest, AddFlowerBouquetModel>();
    }
}