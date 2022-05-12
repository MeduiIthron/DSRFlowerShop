using DSRFlowerShop.Api.Controllers.Dealer.Models;
using DSRFlowerShop.DealerService.Models;

namespace DSRFlowerShop.Api.Controllers.Dealer;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using DSRFlowerShop.DealerService;
using DSRFlowerShop.Common.Security;

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
    public async Task<DealerResponse> CreateDealer([FromBody] RegisterDealerRequest request)
    {
        var DealerModel = mapper.Map<RegisterDealerModel>(request);
        var Dealer = await DealerService.RegisterDealer(DealerModel);
        var response = mapper.Map<DealerResponse>(Dealer);
        return response;
    }
}