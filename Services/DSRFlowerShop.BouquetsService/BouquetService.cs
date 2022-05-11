namespace DSRFlowerShop.BouquetService;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DSRFlowerShop.Common.Exceptions;
using DSRFlowerShop.Common.Validator;
using DSRFlowerShop.Db.Context.Context;
using DSRFlowerShop.Db.Entities;
using DSRFlowerShop.API.Bouquets.Models;
using DSRFlowerShop.API.Flowers.Models;

public class BouquetService : IBouquetService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<AddBouquetModel> addBouquetModelValidator;
    private readonly IModelValidator<UpdateBouquetModel> updateBouquetModelValidator;

    public BouquetService(
        IDbContextFactory<MainDbContext> contextFactory,
        IMapper mapper,
        IModelValidator<AddBouquetModel> addBouquetModelValidator,
        IModelValidator<UpdateBouquetModel> updateBouquetModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.addBouquetModelValidator = addBouquetModelValidator;
        this.updateBouquetModelValidator = updateBouquetModelValidator;
    }

    public async Task<IEnumerable<BouquetModel>> GetBouquets(int dealerID, int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Bouquets = context
            .Bouquets
            .AsQueryable();

        Bouquets = Bouquets
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 1000)));

        var data = (await Bouquets.ToListAsync()).Select(Bouquet => mapper.Map<BouquetModel>(Bouquet));

        return data;
    }

    public async Task<BouquetModel> GetBouquet(int dealerID, int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Bouquet = await context.Bouquets.Select(x => x).FirstOrDefaultAsync(x => x.Id.Equals(id) && x.DealerID.Equals(dealerID));

        var data = mapper.Map<BouquetModel>(Bouquet);

        return data;
    }
    public async Task<BouquetModel> AddBouquet(AddBouquetModel model)
    {
        addBouquetModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var Bouquet = mapper.Map<Bouquet>(model);
        await context.Bouquets.AddAsync(Bouquet);
        context.SaveChanges();

        return mapper.Map<BouquetModel>(Bouquet);
    }

    public async Task UpdateBouquet(int dealerID, int BouquetId, UpdateBouquetModel model)
    {
        updateBouquetModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var Bouquet = await context.Bouquets.FirstOrDefaultAsync(x => x.Id.Equals(BouquetId) && x.DealerID.Equals(dealerID));

        ProcessException.ThrowIf(() => Bouquet is null, $"The Bouquet (id: {BouquetId}) was not found");

        Bouquet = mapper.Map(model, Bouquet);

        context.Bouquets.Update(Bouquet);
        context.SaveChanges();
    }

    public async Task DeleteBouquet(int dealerID, int BouquetId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Bouquet = await context.Bouquets.FirstOrDefaultAsync(x => x.Id.Equals(BouquetId) && x.DealerID.Equals(dealerID))
            ?? throw new ProcessException($"The Bouquet (id: {BouquetId}) was not found");

        context.Remove(Bouquet);
        context.SaveChanges();
    }

    public async Task<BouquetModel> AddFlower(BouquetModel model, BouquetFlowerModel flower) {
        using var context = await contextFactory.CreateDbContextAsync();

        var Bouquet = await context.Bouquets.FirstOrDefaultAsync(x => x.Id.Equals(model.Id) && x.DealerID.Equals(model.DealerID));
        ProcessException.ThrowIf(() => Bouquet is null, $"The Bouquet (id: {model.Id}) was not found");
        Bouquet = mapper.Map(model, Bouquet);

        var Flower = await context.Flowers.Select(x => x).FirstOrDefaultAsync(x => x.Id.Equals(flower.Id) && x.DealerID.Equals(flower.DealerID));
        
        ProcessException.ThrowIf(() => Flower is null, $"The Flower (id: {flower.Id}) was not found");
        Bouquet.Flowers.Add(Flower);
        context.Bouquets.Update(Bouquet);
        context.SaveChanges();
        
        return mapper.Map<BouquetModel>(Bouquet);
    }
}
