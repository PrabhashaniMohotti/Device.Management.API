A RESTful API for managing devices, built with .NET 9, Entity Framework Core, and PostgreSQL.

This API follows Controller -> Service -> Repository architecture, uses DTOs for requests and ViewModels for responses, and is fully containerized using Docker.

Project Overview

	This API allows you to:
		Create new device
		Update existing device
		Delete device
		Fetch device by ID
		Fetch all devices
		Fetch devices by brand
		Fetch devices by state

Technologies
	
	.NET 9 (ASP.NET Core Web API)
	Entity Framework Core
	PostgreSQL
	Swagger / OpenAPI
	Docker & Docker Compose

Architecture

The project is structured following the Controller -> Service -> Repository pattern:
	
	Controllers: Handle HTTP requests and responses.
	Services: Contain business logic and interact with repositories.
	Repositories: Handle data access using Entity Framework Core.
	DTOs: Data Transfer Objects for incoming requests.
	ViewModels: Models for outgoing responses.


Database Setup

	The API uses PostgreSQL as the database. Ensure you have PostgreSQL installed and running. You can configure the connection string in the appsettings.json file or use environment variables when deploying with Docker.

Running the Application (Local)

	Clone the repository:
	dotnet run

	Swagger UI: https://localhost:7143/swagger

Docker Setup

	Build and run the application using Docker Compose:
	docker-compose up --build
	This will set up both the API and a PostgreSQL database in separate containers.

Run using Docker

	docker-compose up --build
	Swagger: http://localhost:8080/swagger

API Endpoints

	Base URL: http://localhost:8080/api/devices
	Endpoints:
		GET /api/devices - Fetch all devices
		GET /api/devices/{id} - Fetch device by ID
		GET /api/devices/brand/{brand} - Fetch devices by brand
		GET /api/devices/state/{state} - Fetch devices by state
		POST /api/devices - Create new device
		PUT /api/devices/{id} - Update existing device
		DELETE /api/devices/{id} - Delete device


Request/Response Models

	DTOs: Used for incoming requests (e.g., CreateDeviceDto, UpdateDeviceDto).
	ViewModels: Used for outgoing responses (e.g., DeviceViewModel).

	Create / Update Device
		{
		  "name": "Device A",
		  "brand": "Brand X",
		  "state": 1
		}

	DeviceViewModel (Response)
		{
		  "id": 1,
		  "name": "Device A",
		  "brand": "Brand X",
		  "state": 1,
		  "createdAt": "2026-01-15T14:30:00Z"
		}

Swagger/API Documentation

	The API is documented using Swagger. Once the application is running, you can access the Swagger UI at:
	http://localhost:8080/swagger

	Swagger is integrated via Swashbuckle.
	Visit: http://localhost:8080/swagger (Docker) or https://localhost:7143/swagger (local)

