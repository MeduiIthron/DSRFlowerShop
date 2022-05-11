namespace DSRFlowerShop.DealerService;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DSRFlowerShop.Common.Validator;
using DSRFlowerShop.Common.Exceptions;
using DSRFlowerShop.Db.Context.Context;
using DSRFlowerShop.API.Dealers.Models;
using DSRFlowerShop.Db.Entities;

public class DealerService : IDealerService {
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<AuthDealerModel> AuthDealerModelValidator;
    private readonly IModelValidator<DealerModel> DealerModelValidator;

    public DealerService(
        IDbContextFactory<MainDbContext> contextFactory,
        IMapper mapper,
        IModelValidator<AuthDealerModel> AuthDealerModelValidator,
        IModelValidator<DealerModel> DealerModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.AuthDealerModelValidator = AuthDealerModelValidator;
        this.DealerModelValidator = DealerModelValidator;
    }

    public async Task<DealerModel> CreateDealer(RegisterDealerModel dlr) {
        using var context = await contextFactory.CreateDbContextAsync();

        var exists = await context.Dealers.Select(x => x)
            .FirstOrDefaultAsync(x => x.Login.Equals(dlr.Login));

        ProcessException.ThrowIf(() => exists is not null, $"The Dealer (login: {dlr.Login}) already exists");

        var Account = mapper.Map<Dealer>(dlr);
        await context.Dealers.AddAsync(Account);
        var data = mapper.Map<DealerModel>(Account);

        return data;
    }

    public async Task<DealerModel> UsingDealer(AuthDealerModel Dealer) {
        using var context = await contextFactory.CreateDbContextAsync();
        var dlr = await context.Dealers.Select(x => x)
            .FirstOrDefaultAsync(x => x.Login.Equals(Dealer.Login) && x.Password.Equals(Dealer.Password) && x.Id.Equals(Dealer.Id));

        ProcessException.ThrowIf(() => Dealer is null, $"The Dealer (login: {Dealer.Login}) not exists");
        var data = mapper.Map<DealerModel>(Dealer);

        return data;
    }
}