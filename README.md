[![ci](https://github.com/Erqes/ECommerceOrderAPI/actions/workflows/ci.yml/badge.svg?branch=master)](https://github.com/Erqes/ECommerceOrderAPI/actions/workflows/ci.yml)
#  ECommerceOrderAPI

A simple ASP.NET Core Web API using Clean Architecture and PostgreSQL.

---

##  Description

ECommerceOrderAPI is a lightweight web API designed to manage e-commerce orders.  
The project follows the Clean Architecture pattern, with Entity Framework Core for data access, PostgreSQL as the database, and a CI/CD pipeline using GitHub Actions.

---

##  Architecture

The solution is structured into the following projects:
- **Domain** — Core business entities and interfaces  
- **Application** — Business logic  
- **Infrastructure** — Data access and PostgreSQL integration  
- **UI** — ASP.NET Core Web API

---

## Technologies

- ASP.NET Core 9.0
- Clean Architecture
- PostgreSQL
- Entity Framework Core
- GitHub Actions CI/CD
- Swagger / OpenAPI
- FluentValidator
---

## Getting Started Locally
1.Add your connection string to appsettings.json in ECommerceOrderAPI.UI:
```json
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=ECommerceOrderDb;Username=postgres;Password=yourpassword"
  }
```
2.Apply database migrations:
```bash
  dotnet ef database update --project ./ECommerceOrderAPI.Infrastructure --startup-project ./ECommerceOrderAPI.UI
```
3. Build and run application.

## Azure

https://ecommerceorderapp.azurewebsites.net/swagger
