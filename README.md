# VolvoCarHealth API

A RESTful API for controlling the temperature of the engine, battery, and lubricant in a car. constructed using SQL Server, Entity Framework Core, and ASP.NET Core.
---

## Features

- Vehicle status CRUD operations
- Methods for critical status and health summary assistance
- Monitoring the maintenance schedule and calculating the number of days before the next repair
- Domain, infrastructure, and API layers make up a clean architecture.
- Unit testing using Moq and xUnit
- Support for SQL Server databases with Docker Compose

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
To increase maintainability and encapsulate business logic, add a service layer between controllers and repositories.

Implement Global Error Handling Middleware
To generate standardized and organized error answers throughout the API, centralize exception handling.

Extend Domain Model
For improved monitoring and diagnostics, include more vehicle-related information like tire pressure, fuel levels, or previous logs.

- Security

Implement Authentication & Authorization
Manage user roles and safeguard important processes using secure API endpoints that employ OAuth or JWT.

- Monitoring & Diagnostics

Add Logging and Monitoring
To monitor the health and usage of your applications, use logging frameworks like Serilog and combine them with monitoring systems like Application Insights and ELK stack.

- Usability

Support for Pagination and Filtering
Add pagination, filtering, and sorting options to API calls that return collections to improve them.

Background Jobs for Maintenance Alerts
Set up recurring jobs to alert users when auto maintenance is necessary (using Hangfire, Quartz.NET, etc.).

- DevOps
  
Containerization and CI/CD Pipeline
For faster delivery, set up CI/CD pipelines (such as GitHub Actions and Azure DevOps) and enhance deployment automation with Docker (which is already in place).
