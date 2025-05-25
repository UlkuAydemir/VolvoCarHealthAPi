# VolvoCarHealth API

A RESTful API for managing vehicle health status, including battery, oil, and engine temperature levels. Built with ASP.NET Core, Entity Framework Core, and SQL Server.
---

## Features

- CRUD operations for vehicle status
- Health summary and critical status helper methods
- Maintenance schedule tracking with days until next maintenance calculation
- Clean architecture with Domain, Infrastructure, and API layers
- Unit tests with xUnit and Moq
- Docker Compose support for SQL Server database

---

## Project Structure

- **VolvoCarHealth.Domain**  
  Contains domain entities and interfaces.

- **VolvoCarHealth.Infrastructure**  
  Data access layer, EF Core DbContext, repositories, helper methods and migrations.

- **VolvoCarHealth.Api**  
  ASP.NET Core Web API project, controllers, dependency injection, and startup configuration.

- **VolvoCarHealth.Tests**  
  Unit tests for repositories, controllers, and helper methods.

---

## Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- SQL Server running in Docker (configured via `docker-compose.yml`)

---

## Setup and Run

1. **Start SQL Server with Docker Compose**

   ```bash
   docker-compose up -d
