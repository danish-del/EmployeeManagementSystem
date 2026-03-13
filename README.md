# Employee Management System API

A secure Employee Management System built using ASP.NET Core Web API.
This project provides authentication and employee management functionality using a clean architecture approach.

## Features

* User Registration
* Secure Login Authentication
* JWT Token Authorization
* Add Employee
* Update Employee
* Delete Employee
* View Employee List
* RESTful API Design
* Swagger API Documentation

## Technologies

* ASP.NET Core Web API
* C#
* Entity Framework Core
* SQL Server
* JWT Authentication
* Swagger (OpenAPI)
* Visual Studio

## Architecture

This project follows a layered architecture:

Controllers → Handle HTTP Requests
Services → Business Logic
Repository → Database Operations
Entities → Models
Data → Database Context

## Authentication Flow

1. User registers an account
2. User logs in with email and password
3. System generates JWT Token
4. Client sends token in Authorization header
5. Protected APIs validate token before access

## API Endpoints

### Authentication

POST /api/auth/register
POST /api/auth/login

### Employees

GET /api/employees
GET /api/employees/{id}
POST /api/employees
PUT /api/employees/{id}
DELETE /api/employees/{id}

## Setup Instructions

1. Clone the repository
2. Open solution in Visual Studio
3. Update SQL Server connection string in appsettings.json
4. Run migrations
5. Run the project

## API Testing

After running the project open Swagger UI:

/swagger

From there you can test all API endpoints.

## Future Improvements

* Role Based Authorization
* Refresh Tokens
* Frontend Integration
* Docker Support

## License

This project is licensed under the MIT License.
