# EshopApp – Simple E-Commerce Backend

This project is a simple and well-structured e-commerce backend, designed using Clean Architecture. It provides the foundational functionality for managing a store, including product and category management, sales invoices, and reports.

---

## Technologies Used

- ✅ ASP.NET Core Web API (.NET 8)
- ✅ Entity Framework Core
- ✅ SQLite (or SQL Server)
- ✅ Angular 17 (Frontend – Coming Soon)
- ✅ Clean Architecture

---

## Project Structure
EshopApp/
├── EshopApp.API → Web API entry point (Controllers)
├── EshopApp.Application → UseCases, DTOs, Interfaces
├── EshopApp.Domain → Entities, Enums, ValueObjects
├── EshopApp.Infrastructure → Repositories, UnitOfWork, Query Helpers
├── EshopApp.Persistence → DbContext, Model Configurations, Migrations
└── EshopApp.Shared → Base classes (e.g., BaseEntity, Result)


---

##Features Implemented

- [x] Store basic info (name, address, phone, etc.)
- [x] Category management (tree structure, CRUD)
- [x] Product management (CRUD)
- [x] Invoice creation (select customer, total calculation)
- [x] Invoice listing & search by date/customer
- [x] Admin/Seller registration and login
- [x] (Optional) MediatR-based UseCases

---

##How to Run

### 1. Apply Migrations & Create Database
```bash
cd EshopApp.API
dotnet ef database update --project ../EshopApp.Persistence --startup-project .
dotnet run --project EshopApp.API

http://localhost:5007/swagger/index.html

Quick Start
Install .NET 8 SDK.

Open the solution and apply the database update.

Use Swagger or Postman to test the API endpoints.

Developer
FatemehFarshchi

