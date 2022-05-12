using DSRFlowerShop.FlowerService.Models;

namespace DSRFlowerShop.FlowerService;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DSRFlowerShop.Common.Exceptions;
using DSRFlowerShop.Common.Validator;
using DSRFlowerShop.Db.Context.Context;
using DSRFlowerShop.Db.Entities;
using DSRFlowerShop.API.Flowers.Models;

public class FlowerService : IFlowerService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<CreateFlowerModel> addFlowerModelValidator;
    private readonly IModelValidator<UpdateFlowerModel> updateFlowerModelValidator;

    public FlowerService(
        IDbContextFactory<MainDbContext> contextFactory,
        IMapper mapper,
        IModelValidator<CreateFlowerModel> addFlowerModelValidator,
        IModelValidator<UpdateFlowerModel> updateFlowerModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.addFlowerModelValidator = addFlowerModelValidator;
        this.updateFlowerModelValidator = updateFlowerModelValidator;
    }

    public async Task<IEnumerable<FlowerModel>> GetFlowers(int dealerID, int offset = 0, int limit = 10)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Flowers = context
            .Flowers
            .AsQueryable();

        Flowers = Flowers.Where(b => b.DealerID.Equals(dealerID));
        
        Flowers = Flowers
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 1000)));

        var data = (await Flowers
            .ToListAsync())
            .Select(Flower => mapper.Map<FlowerModel>(Flower));

        return data;
    }

    public async Task<FlowerModel> GetFlower(int dealerID, int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Flower = await context.Flowers.Select(x => x).FirstOrDefaultAsync(x => x.Id.Equals(id) && x.DealerID.Equals(dealerID));

        var data = mapper.Map<FlowerModel>(Flower);

        return data;
    }
    public async Task<FlowerModel> AddFlower(CreateFlowerModel model)
    {
        addFlowerModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var Flower = mapper.Map<Flower>(model);
        await context.Flowers.AddAsync(Flower);
        context.SaveChanges();

        return mapper.Map<FlowerModel>(Flower);
    }

    public async Task UpdateFlower(UpdateFlowerModel model)
    {
        updateFlowerModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var Flower = await context.Flowers.FirstOrDefaultAsync(x => x.Id.Equals(model.Id) && x.DealerID.Equals(model.DealerID));

        ProcessException.ThrowIf(() => Flower is null, $"The Flower (id: {model.Id}) was not found");

        Flower = mapper.Map(model, Flower);

        context.Flowers.Update(Flower);
        context.SaveChanges();
    }

    public async Task DeleteFlower(int dealerID, int FlowerId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Flower = await context.Flowers.FirstOrDefaultAsync(x => x.Id.Equals(FlowerId) && x.DealerID.Equals(dealerID))
            ?? throw new ProcessException($"The Flower (id: {FlowerId}) was not found");

        context.Remove(Flower);
        context.SaveChanges();
    }
}
