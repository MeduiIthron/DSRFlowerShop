using AutoMapper;
using DSRFlowerShop.API.Flowers.Models;
using DSRFlowerShop.Db.Entities;
using FluentValidation;

namespace DSRFlowerShop.BouquetService.Models;

public class AddFlowerBouquetModel
{
    public int BouquetID { get; set; }
    public int DealerID { get; set; }
    public int FlowerId { get; set; }
    public int Count { get; set; } = 1;
}

public class AddFlowerBouquetModelValidator: AbstractValidator<AddFlowerBouquetModel> {
    
    public AddFlowerBouquetModelValidator() {
        RuleFor(x => x.BouquetID)
            .NotEmpty().WithMessage("BouquetID is required.");
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("Dealer ID is required.");
        RuleFor(x => x.FlowerId)
            .NotEmpty().WithMessage("Flower Id is required.");
    }
}

public class AddFlowerBouquetModelProfile : Profile
{
    public AddFlowerBouquetModelProfile()
    {
        CreateMap<AddFlowerBouquetModel, Flower>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FlowerId));
    }
}

public class AddBouquetFlowerModelProfile : Profile
{
    public AddBouquetFlowerModelProfile()
    {
        CreateMap<AddFlowerBouquetModel, Bouquet>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BouquetID));
    }
}