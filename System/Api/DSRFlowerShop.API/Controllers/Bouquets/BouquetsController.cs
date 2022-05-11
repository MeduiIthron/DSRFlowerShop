namespace DSRFlowerShop.API.Controllers.Bouquets;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DSRFlowerShop.Common.Security;
using DSRFlowerShop.BouquetService;
using DSRFlowerShop.API.Bouquets.Models;
using DSRFlowerShop.API.Controllers.Bouquets.Models;

[Route("api/v{version:apiVersion}/Bouquets")]
[ApiController]
[ApiVersion("1.0")]
public class BouquetsController : ControllerBase
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

    [HttpGet("")]
    [Authorize(AppScopes.FlowersRead)]
    public async Task<IEnumerable<BouquetResponse>> GetBouquets([FromRoute] int DealerID, [FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var Bouquets = await BouquetService.GetBouquets(DealerID, offset, limit);
        var response = mapper.Map<IEnumerable<BouquetResponse>>(Bouquets);

        return response;
    }

    [HttpGet("{id}")]
    [Authorize(AppScopes.FlowersRead)]
    public async Task<BouquetResponse> GetBouquetById([FromRoute] int DealerID, [FromRoute] int id)
    {
        var Bouquet = await BouquetService.GetBouquet(DealerID, id);
        var response = mapper.Map<BouquetResponse>(Bouquet);

        return response;
    }

    [HttpPost("")]
    [Authorize(AppScopes.FlowersWrite)]
    public async Task<BouquetResponse> AddBouquet(AddBouquetRequest request)
    {
        var model = mapper.Map<AddBouquetModel>(request);
        var Bouquet = await BouquetService.AddBouquet(model);
        var response = mapper.Map<BouquetResponse>(Bouquet);

        return response;
    }

    [HttpPut("{id}")]
    [Authorize(AppScopes.FlowersWrite)]
    public async Task<IActionResult> UpdateBouquet([FromRoute] int id, [FromBody] UpdateBouquetRequest request)
    {
        var model = mapper.Map<UpdateBouquetModel>(request);
        await BouquetService.UpdateBouquet(request.DealerID, id, model);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(AppScopes.FlowersWrite)]
    public async Task<IActionResult> DeleteBouquet([FromRoute] int dealerID, [FromRoute] int id)
    {
        await BouquetService.DeleteBouquet(dealerID, id);

        return Ok();
    }
}
