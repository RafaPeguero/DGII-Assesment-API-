using Domain.Models;
using Infrastructure.interfaces;
using Infrastructure.interfaces.repository;
using Infrastructure.interfaces.Services;

namespace Infrastructure.Services;

public class TaxpayerService: ITaxpayerService
{
    private readonly ITaxpayerRepository _taxpayerRepository;

    public TaxpayerService(ITaxpayerRepository taxpayerRepository)
    {
        _taxpayerRepository = taxpayerRepository;
    }

    public  async Task<IEnumerable<Taxpayer>> GetAllTaxpayers()
    {
        return await _taxpayerRepository.GetAll() ?? throw new InvalidOperationException();
    }
}