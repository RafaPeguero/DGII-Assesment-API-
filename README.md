# DGII Assesment API .NET Core Project

This is a web api with the purpose of view a list of Taxpayers and their Tax Receipts.

## Stack and Libraries
- C# 12
- .Net 8
- ASP .Net Core
- Sqlite
- RepoDb
- MS Test
- NSubstitute


## Project Structure
This project is divided in 4 Projects: Web.API, Infraestructure, Domain and DGII-Assesment-API-Test

```
├── Web.API
│   └── Controllers
│   │   └── TaxPayerController.cs
│   │   └── TaxReceiptController.cs
│   └── Program.cs
│   └── Dockerfile
├── Infraestructure
│   └── DataSource
│   │   └── dgii-db
│   └── Factories
│   │   └── ConnectionFactory.cs
│   └── Interfaces
│   │   └── Factories
│   │   └── Repository
│   │   └── Services
│   └── Repositories
│   │   └── TaxpayerRepository.cs
│   │   └── TaxreceiptRepository.cs
│   └── Services
│   │   └── TaxpayerService.cs
│   │   └── TaxReceiptService.cs
│   └── DependencyInjection.cs
│   │   └── TaxPayerController.cs
│   │   └── TaxReceiptController.cs
├── Domain
│   └── Models
│   │   └── Taxpayer.cs
│   │   └── TaxReceipt.cs
├── DGII-Assesment-API-Test
│   └── Controllers
│   └── Factories
│   └── Repositories
│   └── Resources
│   │   └── Tables.cs
|   │   │   └── Taxpayer.sql.cs
|   │   │   └── TaxReceipt.sql.cs
│   └── Services
│   └── Utilities
│   │   └── RepositoryTestUtility.cs
│   │   └── TestConnectionFactory.cs
```
- `Domain` In this layer are the models/entities of this project
- `Dockerfile` is .NET Core Web API Dockerfile
- `Infraestructure` In this layer are Database configuration with Sqlite, The repositories with a Base Repository with the base CRUD options and services
-  `Web.Api` In this layer are the controllers for the API.
-  `DGII-Assesment-API-Test` In this layer are the unit tests for all the classes from all the layers, the tests are build with MSTest and NSubstitute.

## Test Coverage

![1-Unit test coverage-api](https://github.com/RafaPeguero/DGII-Assesment-API-/assets/28870732/e4e51212-1618-4e63-b132-ceaa304adf6a)
