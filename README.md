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

- Architecture & Code Quality

Add Service Layer
Introduce a service layer between controllers and repositories to encapsulate business logic and improve maintainability.

Implement Global Error Handling Middleware
Centralize exception handling to produce consistent and structured error responses across the API.

Extend Domain Model
Add more vehicle-related data such as tire pressure, fuel levels, or historical logs for better diagnostics and tracking.

- Security

Implement Authentication & Authorization
Secure API endpoints using JWT or OAuth to manage user roles and protect sensitive operations.

- Monitoring & Diagnostics

Add Logging and Monitoring
Use logging frameworks like Serilog, and integrate with monitoring platforms (e.g., Application Insights, ELK stack) to track application health and usage.

- Usability

Support for Pagination and Filtering
Enhance API endpoints that return collections by adding pagination, filtering, and sorting options.

Background Jobs for Maintenance Alerts
Schedule periodic jobs (using Hangfire, Quartz.NET, etc.) to notify users when vehicle maintenance is due.

- DevOps
Containerization and CI/CD Pipeline
Improve deployment automation using Docker (already in place) and set up CI/CD pipelines (e.g., GitHub Actions, Azure DevOps) for streamlined delivery.
