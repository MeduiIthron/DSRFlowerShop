namespace DSRFlowerShop.API.Controllers.Bouquets.Models;

using AutoMapper;
using FluentValidation;
using DSRFlowerShop.API.Bouquets.Models;

public class AddBouquetRequest
{
    public int DealerID { get; set; }
}

public class AddBouquetResponseValidator : AbstractValidator<AddBouquetRequest>
{
    public AddBouquetResponseValidator()
    {
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("DealerID is required.");
    }
}

public class AddBouquetRequestProfile : Profile
{
    public AddBouquetRequestProfile()
    {
        CreateMap<AddBouquetRequest, AddBouquetModel>();
    }
}

