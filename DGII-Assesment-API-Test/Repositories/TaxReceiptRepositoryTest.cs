using System.Data;
using DGII_Assesment_API_Test.Utilities;
using Domain.Models;
using FluentAssertions;
using Infrastructure.interfaces.repository;
using Infrastructure.repositories;
using RepoDb;

namespace DGII_Assesment_API_Test.Repositories;
[TestClass]
public class TaxReceiptRepositoryTest
{
    private IDbConnection _connection = null!;
    private ITaxReceiptRepository _repository = null!;
    
    [TestInitialize]
    public void Setup()
    {
        _connection = RepositoryTestUtility.Setup("Resources/Tables/TaxReceipt.sql");
        _repository = new TaxReceiptRepository(_connection);
    }
    
    [TestMethod]
    public async Task ShouldGetAll()
    {
        //Arrange
        var taxReceipts = new List<TaxReceipt>()
        {
            new ()
            {
                Id = 1,
                TaxPayerId = 111111111,
                Ncf = "E1",
                Amount = 100.00,
                Itbis18 = 180.00
            },
            new ()
            {
                Id = 2,
                TaxPayerId = 222222,
                Ncf = "E2",
                Amount = 350.00,
                Itbis18 = 25.00
            },
        };
        //Act
        await _connection.InsertAllAsync(taxReceipts);
        var result =  await _repository.GetAll();
            
        //Assert
        result.Should().BeEquivalentTo(taxReceipts);
    }
    
    [TestMethod]
    public async Task ShouldGetByTaxpayerId()
    {
        var taxReceipts = new List<TaxReceipt>()
        {
            new ()
            {
                Id = 1,
                TaxPayerId = 111111111,
                Ncf = "E1",
                Amount = 100.00,
                Itbis18 = 180.00
            },
            new ()
            {
                Id = 2,
                TaxPayerId = 111111111,
                Ncf = "E3",
                Amount = 100.00,
                Itbis18 = 180.00
            },
            new ()
            {
                Id = 3,
                TaxPayerId = 222222,
                Ncf = "E2",
                Amount = 350.00,
                Itbis18 = 25.00
            },
        };

        await _connection.InsertAllAsync(taxReceipts);

        var result =  await _repository.GetTaxReceiptsByTaxPayerId(111111111);

        result.Should().BeEquivalentTo(taxReceipts.Where(x => x.TaxPayerId == 111111111));
    }
}