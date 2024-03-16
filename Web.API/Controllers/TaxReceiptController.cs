using Infrastructure.interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxReceiptController: ControllerBase
{
    private readonly ITaxReceiptService _taxReceiptService;

    public TaxReceiptController(ITaxReceiptService taxReceiptService)
    {
        _taxReceiptService = taxReceiptService;
    }
    
    [HttpGet("")]
    public async Task<ActionResult> GetAllTaxReceipts()
    {
        try
        {
            var result = await _taxReceiptService.GetAllTaxReceipts();
            return Ok(result);
        }
        catch (Exception exception)
        {
            return BadRequest(exception);
        }
    }
    
    [HttpGet("{taxpayerId}")]
    public async Task<ActionResult> GetAllTaxReceiptsByTaxpayer( int taxpayerId)
    {
        try
        {
            var result = await _taxReceiptService.GetAllTaxReceiptsByTaxpayerId(taxpayerId);
            return Ok(result);
        }
        catch (Exception exception)
        {
            return BadRequest(exception);
        }
    }
}