using Domain.Models;

namespace Infrastructure.interfaces.Services;

public interface ITaxpayerService
{
    Task<IEnumerable<Taxpayer>> GetAllTaxpayers();
}