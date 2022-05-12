namespace DSRFlowerShop.DealerService;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DSRFlowerShop.Db.Context.Context;
using DSRFlowerShop.Common.Validator;
using DSRFlowerShop.DealerService.Models;
using DSRFlowerShop.Common.Exceptions;
using DSRFlowerShop.Db.Entities;

public class DealerService : IDealerService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<RegisterDealerModel> RegisterDealerModelValidator;
    private readonly IModelValidator<DealerModel> DealerModelValidator;

    public DealerService(
        IDbContextFactory<MainDbContext> contextFactory,
        IMapper mapper,
        IModelValidator<RegisterDealerModel> RegisterDealerModelValidator,
        IModelValidator<DealerModel> DealerModelValidator
    )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.RegisterDealerModelValidator = RegisterDealerModelValidator;
        this.DealerModelValidator = DealerModelValidator;
    }

    public async Task<DealerModel> RegisterDealer(RegisterDealerModel dealer)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var exists = await context.Dealers.Select(x => x)
            .FirstOrDefaultAsync(x => x.Login.Equals(dealer.Login));
        
        ProcessException.ThrowIf(() => exists is not null, $"The Dealer (login: {dealer.Login}) already exists");

        var Account = mapper.Map<Dealer>(dealer);
        await context.Dealers.AddAsync(Account);
        context.SaveChanges();
        var data = mapper.Map<DealerModel>(Account);

        return data;
    }
}