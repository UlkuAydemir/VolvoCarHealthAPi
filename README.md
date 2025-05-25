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

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- IDE like Visual Studio 2022 or Visual Studio Code
- SQL Server running in Docker (configured via `docker-compose.yml`)

---

## Setup and Run

1. **Start SQL Server with Docker Compose**

   ```bash
   docker-compose up -d


## Future Improvements

- Add Service Layer
- Introduce a service layer to encapsulate business logic, improving separation of concerns.

- Implement Authentication & Authorization
- Secure the API using JWT or OAuth to control access.

- Add Logging and Monitoring
- Integrate logging frameworks (e.g., Serilog) and monitoring tools for better diagnostics.

- Support for Pagination and Filtering
- Add pagination, filtering, and sorting to list endpoints.

- Error Handling Middleware
- Improve global error handling for consistent API responses.

- Background Jobs for Maintenance Alerts
- Add scheduled jobs to notify users when maintenance is due.

- Extend Domain Model
- Include more vehicle parameters or history tracking.

- Containerization and CI/CD Pipeline
- Improve deployment automation and container orchestration.
