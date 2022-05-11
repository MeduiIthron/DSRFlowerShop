namespace DSRFlowerShop.API.Controllers.Bouquets.Models;

using AutoMapper;
using FluentValidation;
using DSRBouquetShop.API.Bouquets.Models;
using DSRFlowerShop.Common;

public class UpdateBouquetRequest
{
    public int DealerID { get; set; }
    public BouquetStatus Status { get; set; }
}

public class UpdateBouquetRequestValidator : AbstractValidator<UpdateBouquetRequest>
{
    public UpdateBouquetRequestValidator()
    {
        RuleFor(x => x.DealerID)
            .NotEmpty().WithMessage("DealerID is required.");

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
