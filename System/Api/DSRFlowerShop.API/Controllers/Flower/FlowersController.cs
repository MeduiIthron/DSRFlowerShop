using DSRFlowerShop.Api.Controllers.Flower.Models;

namespace DSRFlowerShop.API.Controllers.Flowers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DSRFlowerShop.Common.Security;
using DSRFlowerShop.FlowerService;
using DSRFlowerShop.API.Flowers.Models;
using DSRFlowerShop.API.Controllers.Flowers.Models;

[Route("api/v{version:apiVersion}/Flowers")]
[ApiController]
[ApiVersion("1.0")]
public class FlowersController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<FlowersController> logger;
    private readonly IFlowerService FlowerService;

    public FlowersController(IMapper mapper, ILogger<FlowersController> logger, IFlowerService FlowerService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.FlowerService = FlowerService;
    }

    [HttpGet("")]
    [Authorize(AppScopes.FlowersRead)]
    public async Task<IEnumerable<FlowerResponse>> GetFlowers([FromQuery] int DealerID, [FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var Flowers = await FlowerService.GetFlowers(DealerID, offset, limit);
        var response = mapper.Map<IEnumerable<FlowerResponse>>(Flowers);

        return response;
    }

    [HttpGet("{id}")]
    [Authorize(AppScopes.FlowersRead)]
    public async Task<FlowerResponse> GetFlowerById([FromRoute] int DealerID, [FromRoute] int id)
    {
        var Flower = await FlowerService.GetFlower(DealerID, id);
        var response = mapper.Map<FlowerResponse>(Flower);

        return response;
    }

    [HttpPost("")]
    [Authorize(AppScopes.FlowersWrite)]
    public async Task<FlowerResponse> AddFlower(CreateFlowerRequest request)
    {
        var model = mapper.Map<CreateFlowerModel>(request);
        var Flower = await FlowerService.AddFlower(model);
        var response = mapper.Map<FlowerResponse>(Flower);

        return response;
    }

    [HttpPut("{id}")]
    [Authorize(AppScopes.FlowersWrite)]
    public async Task<IActionResult> UpdateFlower([FromRoute] int id, [FromBody] UpdateFlowerRequest request)
    {
        var model = mapper.Map<UpdateFlowerModel>(request);
        await FlowerService.UpdateFlower(model);

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(AppScopes.FlowersWrite)]
    public async Task<IActionResult> DeleteFlower([FromRoute] int dealerID, [FromRoute] int id)
    {
        await FlowerService.DeleteFlower(dealerID, id);

        return Ok();
    }
}
