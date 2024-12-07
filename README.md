# CarRental

**CarRental** is a robust car rental management system built with .NET. It employs **CQRS (Command Query Responsibility Segregation)** and **Clean Architecture** to ensure scalability, maintainability, and a clear separation of concerns.

## Features

- **Vehicle Management**:  
  Add, update, and manage the vehicle inventory efficiently.

- **Customer Management**:  
  Maintain customer profiles and track rental history.

- **Reservation System**:  
  Process bookings, cancellations, and schedule management.

- **Billing and Invoicing**:  
  Generate invoices and handle secure payment processing.

- **Authentication and Authorization**:  
  Uses **JWT (JSON Web Tokens)** for secure user authentication and role-based access control.

---

## Architecture

This project is designed with **Clean Architecture** principles, emphasizing a layered architecture with dependencies pointing inward toward the core domain. Additionally, the **CQRS pattern** ensures a clear separation of read and write operations for improved performance and scalability.

### **Clean Architecture Layers**
- **Core Layer**: Contains domain entities, use cases, and interfaces.
- **Application Layer**: Implements use cases and mediates between the core and infrastructure layers.
- **Infrastructure Layer**: Handles external concerns like database interactions and external services.
- **Presentation Layer**: Includes APIs, controllers, and views.

### **CQRS Pattern**
- **Command Side**: Handles create, update, and delete operations.
- **Query Side**: Focuses on optimized data retrieval, separate from command operations.

---

## Technologies Used

- **.NET 6**: Modern, high-performance web framework.
- **Entity Framework Core**: ORM for database operations.
- **MediatR**: Implements the mediator pattern for clean request/response handling.
- **FluentValidation**: Provides validation for commands and queries.
- **JWT (JSON Web Token)**: Ensures secure authentication and role-based access control.
- **SQL Server**: Relational database for transactional data.
- **Swagger**: API documentation and testing.

---

## Installation

### Prerequisites

Ensure the following are installed on your machine:
- .NET 6 SDK
- SQL Server

### Steps

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Oguzhaan7/CarRental.git
   cd CarRental
