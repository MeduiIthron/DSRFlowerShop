using DSRFlowerShop.Api.Controllers.Flower.Models;

namespace DSRFlowerShop.Api.Controllers.Bouquet;

using AutoMapper;
using DSRFlowerShop.BouquetService;
using DSRFlowerShop.Common.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DSRFlowerShop.Api.Controllers.Bouquet.Models;
using DSRFlowerShop.BouquetService.Models;

[Route("api/v{version:apiVersion}/Bouquets")]
[ApiController]
[ApiVersion("1.0")]
public class BouquetsController: ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<BouquetsController> logger;
    private readonly IBouquetService BouquetService;

    public BouquetsController(IMapper mapper, ILogger<BouquetsController> logger, IBouquetService BouquetService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.BouquetService = BouquetService;
    }

    [HttpPost("")]
    [Authorize(AppScopes.FlowersWrite)]
    public async Task<BouquetResponse> CreateBouquet([FromBody] CreateBouquetRequest request)
    {
        var BouquetModel = mapper.Map<CreateBouquetModel>(request);
        var Bouquet = await BouquetService.RegisterBouquet(BouquetModel);
        var response = new BouquetResponse()
        {
            DealerID = Bouquet.DealerID,
            Id = Bouquet.Id,
            Status = Bouquet.Status,
            Flowers = mapper.Map<IEnumerable<CountedFlowerResponse>>(Bouquet.Flowers),
            FullPrice = Bouquet.Flowers.Sum(x => x.Count * x.Flower.Price)
        };
        return response;
    }
    
    [HttpGet("")]
    [Authorize(AppScopes.FlowersRead)]
    public async Task<IEnumerable<BouquetResponse>> GetBouquets([FromQuery] int DealerID, [FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var bouquets = await BouquetService.GetBouquets(DealerID, offset, limit);
        var response = bouquets.Select(Bouquet => new BouquetResponse()
        {
            DealerID = Bouquet.DealerID,
            Id = Bouquet.Id,
            Status = Bouquet.Status,
            Flowers = mapper.Map<IEnumerable<CountedFlowerResponse>>(Bouquet.Flowers),
            FullPrice = Bouquet.Flowers.Sum(x => x.Count * x.Flower.Price)
        });

        return response;
    }
    
    [HttpPut("")]
    [Authorize(AppScopes.FlowersWrite)]
    public async Task<IActionResult> UpdateBoquet([FromBody] UpdateBouquetRequest request)
    {
        var model = mapper.Map<UpdateBouquetModel>(request);
        await BouquetService.UpdateBouquet(model);

        return Ok();
    }
    
    [HttpPatch("")]
    [Authorize(AppScopes.FlowersWrite)]
    public async Task<BouquetResponse> AddFlowerBouquet([FromBody] AddFlowerBouquetRequest request)
    {
        var BouquetModel = mapper.Map<AddFlowerBouquetModel>(request);
        var Bouquet = await BouquetService.AddFlowerBoquet(BouquetModel);
        var response = new BouquetResponse()
        {
            DealerID = Bouquet.DealerID,
            Id = Bouquet.Id,
            Status = Bouquet.Status,
            Flowers = mapper.Map<IEnumerable<CountedFlowerResponse>>(Bouquet.Flowers),
            FullPrice = Bouquet.Flowers.Sum(x => x.Count * x.Flower.Price)
        };
        return response;
    }
}