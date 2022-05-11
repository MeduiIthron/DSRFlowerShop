namespace DSRFlowerShop.API.Controllers.Dealers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DSRFlowerShop.Common.Security;
using DSRFlowerShop.API.Dealers.Models;
using DSRFlowerShop.API.Controllers.Dealers.Models;
using DSRFlowerShop.DealerService;
using Serilog;

[Route("api/v{version:apiVersion}/Dealers")]
[ApiController]
[ApiVersion("1.0")]
public class DealersController: ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<DealersController> logger;
    private readonly IDealerService DealerService;

    public DealersController(IMapper mapper, ILogger<DealersController> logger, IDealerService DealerService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.DealerService = DealerService;
    }

    [HttpPost("")]
    [Authorize(AppScopes.FlowersWrite)]
    public async Task<DealerResponse> CreateDealer([FromBody] CreateDealerRequest request)
    {
        var DealerModel = mapper.Map<RegisterDealerModel>(request);

        Log.Information("->>");
        var Dealer = await DealerService.CreateDealer(DealerModel);
        var response = mapper.Map<DealerResponse>(Dealer);
        return response;
    }

    [HttpPut("")]
    [Authorize(AppScopes.FlowersWrite)]
    public async Task<DealerResponse> UsingDealer([FromBody] UsingDealerRequest request)
    {
        var DealerModel = mapper.Map<AuthDealerModel>(request);
        var Dealer = await DealerService.UsingDealer(DealerModel);
        var response = mapper.Map<DealerResponse>(Dealer);
        return response;
    }
}