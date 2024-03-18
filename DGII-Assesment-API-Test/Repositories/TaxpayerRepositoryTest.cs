using System.Data;
using DGII_Assesment_API_Test.Utilities;
using Domain.Models;
using FluentAssertions;
using Infrastructure.interfaces.repository;
using Infrastructure.repositories;
using RepoDb;

namespace DGII_Assesment_API_Test.Repositories;
[TestClass]
public class TaxpayerRepositoryTest
{
    private IDbConnection _connection = null!;
    private ITaxpayerRepository _repository = null!;
    
    [TestInitialize]
    public void Setup()
    {
        _connection = RepositoryTestUtility.Setup("Resources/Tables/Taxpayer.sql");
        _repository = new TaxpayerRepository(_connection);
    }
    

    [TestMethod]
    public async Task ShouldGet()
    {
        var taxpayers = new List<Taxpayer>()
        {
            new ()
            {
                TaxpayerId = 111111111,
                Name = "Juan Perez",
                Status = "Activo",
                Type = "Persona Fisica",
            },
            new ()
            {
                TaxpayerId = 22222,
                Name = "Pedro Sanchez",
                Status = "Activo",
                Type = "Persona Fisica",
            }
        };
    
        await _connection.InsertAllAsync(taxpayers);
    
        var result =  await _repository.GetAll();
    
        result.Should().BeEquivalentTo(taxpayers);
    }
}