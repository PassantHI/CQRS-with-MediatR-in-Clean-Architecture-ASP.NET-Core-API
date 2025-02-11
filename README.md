# 📽 Movie App API
# A Movie Management API built with .NET Core, CQRS, and MediatR, implementing Clean Architecture. 🚀

## 📖 Table of Contents  
- [🔧 Installation](#-installation)  
- [📂 Project Structure](#-project-structure)  
- [🚀 Features](#-features)  
- [📜 API Endpoints](#-api-endpoints)  
- [📸 Screenshots](#-screenshots)  
- [📌 Technologies Used](#-technologies-used)  
- [📄 License](#-license)  

---

## 🔧 Installation  
To set up this project locally, follow these steps:  

```bash
git clone https://github.com/PassantHI/CQRS-with-MediatR-in-Clean-Architecture-ASP.NET-Core-API.git
cd CQRS-with-MediatR-in-Clean-Architecture-ASP.NET-Core-API
dotnet restore
dotnet run
```

---

## 📁 Project Structure

```bash
📦 MovieApp
├── 📁 App.API              # API Layer (Controllers, Swagger, Dependency Injection)
│   ├── 📁 Controllers      # API Endpoints
│   ├── Program.cs         # API Startup Configuration
│   ├── appsettings.json   # Configuration File
│
├── 📁 App.Application      # Application Layer (CQRS, Business Logic)
│   ├── 📁 Features        # Queries & Commands
│   ├── 📁 DTOs            # Data Transfer Objects
│   ├── 📁 Interfaces      # Repository Contracts

│
├── 📁 App.Domain           # Domain Layer (Entities & Interfaces)
│   ├── 📁 Entities        # Movie, Genre, etc.

│
├── 📁 App.Infrastructure   # Infrastructure Layer (Data Persistence)
│   ├── 📁 Persistence     # EF Core DbContext, Migrations
│   ├── 📁 Identity        # UserAccount
│   ├── 📁 Repositories    # Generic & UnitOfWork
│

└── MovieApp.sln           # .NET Solution File
```

---



## 🚀 Features

### ✅ CQRS Pattern with MediatR
### ✅ Unit of Work & Repository Pattern
### ✅ EF Core for Database Access
### ✅ Clean Architecture Principles

---


## 📜 API Endpoints 

| HTTP Method | Endpoint | Description |
|------------|---------|-------------|
| `GET`      | `/api/Movie/{id}` | Get a movie by ID |
| `POST`     | `/api/Movie` | Add a new movie |
| `PUT`      | `/api/Movie` | Update a movie |
| `DELETE`   | `/api/Movie/{id}` | Delete a movie |
| `GET`      | `/api/Movie/Search/{Keyword}` | Search Using name |
| `GET`      | `/api/Movie/{genre}` | Filter Movies by genres |
| `GET`      | `/api/Movie/Rate/{N}` | Filter TopRated Movies |

---

| HTTP Method | Endpoint | Description |
|------------|---------|-------------|
|`GET`      | `/api/Genre/{id}` | Get a genre by ID |
| `GET`      | `/api/Genre` | Get all genres |
| `POST`     | `/api/Genre` | Add a new genre |
| `PUT`      | `/api/Genre` | Update a genre |
| `DELETE`   | `/api/Genre/{id}` | Delete a genre |

--- 

| HTTP Method | Endpoint | Description |
|------------|---------|-------------|
| `POST`     | `/api/auth/register` | Register a new user |
| `POST`     | `/api/auth/login` | User login |
| `POST`     | `/api/auth/confirm-email` | Confirm user email |

--- 

## 📌 Technologies Used
### ASP.NET Core 🚀
### Entity Framework Core 🗄️
### MediatR for CQRS 🔀
### FluentValidation for Validation ✅
### Swagger for API Docs 📖








