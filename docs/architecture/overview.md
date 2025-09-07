# Architecture

## Overview
The Airbnb MVP follows a clean architecture approach with separation of concerns:

- **Api**: Entry point for HTTP requests (controllers, middleware).
- **Application**: Business logic and use cases.
- **Domain**: Core domain models and interfaces.
- **Infrastructure**: Data access, external services, persistence.
- **Contracts**: DTOs for communication between layers.
- **Tests**: Unit and integration tests.

This ensures maintainability, testability, and scalability.
