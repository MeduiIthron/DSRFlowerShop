using DSRFlowerShop.Common.Exceptions;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DSRFlowerShop.BouquetService;
using DSRFlowerShop.BouquetService.Models;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DSRFlowerShop.Db.Context.Context;
using DSRFlowerShop.Common.Validator;
using DSRFlowerShop.Db.Entities;
using DSRFlowerShop.FlowerService.Models;

public class BouquetService : IBouquetService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<CreateBouquetModel> RegisterBouquetModelValidator;

    public BouquetService(
        IDbContextFactory<MainDbContext> contextFactory,
        IMapper mapper,
        IModelValidator<CreateBouquetModel> RegisterBouquetModelValidator
    )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.RegisterBouquetModelValidator = RegisterBouquetModelValidator;
    }

    public async Task<BouquetModel> RegisterBouquet(CreateBouquetModel bouquet)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Model = mapper.Map<Bouquet>(bouquet);
        await context.Bouquets.AddAsync(Model);
        context.SaveChanges();
        var data = new BouquetModel()
        {
            Id = Model.Id,
            DealerID = Model.DealerID,
            Status = Model.Status,
            Flowers = mapper.Map<IEnumerable<FlowerModel>>(Model.Flowers)
        };

        return data;
    }

    public async Task<IEnumerable<BouquetModel>> GetBouquets(int dealerID, int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        
        var Bouquets = context
            .Bouquets
            .AsQueryable();

        Bouquets = Bouquets.Where(b => b.DealerID.Equals(dealerID));

        Bouquets = Bouquets
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 1000)));
        
        var data = await Bouquets.Select(Bouquet => new BouquetModel() {
            Id = Bouquet.Id,
            DealerID = Bouquet.DealerID,
            Status = Bouquet.Status,
            Flowers = mapper.Map<IEnumerable<FlowerModel>>(Bouquet.Flowers)
        }).ToListAsync();

        return data;
    }

    public async Task UpdateBouquet(UpdateBouquetModel bouquet)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var exists = await context.Bouquets.Select(x => x)
            .FirstOrDefaultAsync(x => x.Id.Equals(bouquet.Id) && x.DealerID.Equals(bouquet.DealerID));
        
        ProcessException.ThrowIf(() => exists is null, $"The Boquet (login: {bouquet.Id}) not exists");
        
        var Model = mapper.Map<Bouquet>(bouquet);
        context.Bouquets.Update(Model);
        context.SaveChanges();
    }

    public async Task<BouquetModel> AddFlowerBoquet(AddFlowerBouquetModel operation)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        var bouquet = mapper.Map<Bouquet>(operation);
        var flower = await context.Flowers.Select(x => x).FirstOrDefaultAsync(x => x.Id.Equals(operation.FlowerId) && x.DealerID.Equals(operation.DealerID));

        var cnt = bouquet.Counters.First(x => x.FlowerID.Equals(flower.Id));
        cnt.Count += operation.Count;
        
        bouquet.Flowers.Add(flower);
        context.Flowers.Update(flower);
        context.Bouquets.Update(bouquet);
        context.SaveChanges();

        return new BouquetModel()
        {
            Id = bouquet.Id,
            DealerID = bouquet.DealerID,
            Status = bouquet.Status,
            Flowers = mapper.Map<IEnumerable<FlowerModel>>(bouquet.Flowers)
        };
    }
}