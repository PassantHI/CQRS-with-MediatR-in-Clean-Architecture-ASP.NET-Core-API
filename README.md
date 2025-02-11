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

---

## 📂 Project Structure

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

