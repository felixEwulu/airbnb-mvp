# Technical Design Document (TTD) - Airbnb MVP

## 1. Overview
This document outlines the technical implementation of the Airbnb MVP.

## 2. System Architecture
- **Frontend**: React/Next.js (or Blazor if .NET full-stack).
- **Backend**: .NET Core Web API.
- **Database**: PostgreSQL (preferred for scalability).
- **Authentication**: JWT tokens.
- **Payments**: Stripe or Paystack integration.
- **Hosting/Deployment**: Azure / AWS / DigitalOcean.

## 3. Modules
1. **User Management**
   - Authentication & Authorization.
   - User profile CRUD.
2. **Property Management**
   - Property CRUD.
   - Upload images.
   - Availability scheduling.
3. **Booking Management**
   - Check availability.
   - Reserve and confirm booking.
   - Booking history.
4. **Payments**
   - Secure checkout with gateway.
   - Payment status tracking.
5. **Reviews**
   - Post and retrieve reviews.
6. **Messaging (optional future feature)**
   - Conversation between hosts and guests.

## 4. Database Design
- Reference: `/docs/database/database.md`.
- Entities: Users, Properties, Bookings, Payments, Reviews, Messages, Favorites.

## 5. API Endpoints
- **Auth**: `/api/auth/register`, `/api/auth/login`
- **Properties**: `/api/properties`, `/api/properties/{id}`
- **Bookings**: `/api/bookings`, `/api/bookings/{id}`
- **Payments**: `/api/payments`
- **Reviews**: `/api/reviews`

## 6. Security Considerations
- Hash & salt passwords (ASP.NET Identity).
- Validate all API inputs.
- Role-based authorization (host vs guest).
- HTTPS only.

## 7. Deployment & CI/CD
- GitHub Actions pipeline (already setup ✅).
- Staging and production environments.
- Auto-deploy to cloud provider on merge to `main`.

## 8. Testing Strategy
- Unit tests for business logic.
- Integration tests for API endpoints.
- Load testing for scalability.

