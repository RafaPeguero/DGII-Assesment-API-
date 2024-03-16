using Infrastructure.interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;
[ApiController]
[Route("[controller]")]
public class TaxpayerController: ControllerBase
{
    private readonly ITaxpayerService _taxpayerService;

    public TaxpayerController(ITaxpayerService taxpayerService)
    {
        _taxpayerService = taxpayerService;
    }
    
    [HttpGet("")]
    public async Task<ActionResult> GetAllTaxpayers()
    {
        try
        {
            var result = await _taxpayerService.GetAllTaxpayers();
            return Ok(result);
        }
        catch (Exception exception)
        {
            return BadRequest(exception);
        }
    }
}