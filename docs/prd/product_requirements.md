# Product Requirements Document (PRD) - Airbnb MVP

## 1. Overview
This document defines the product requirements for the Airbnb MVP (Minimum Viable Product).  
The goal is to create a booking platform where users can list, discover, and book accommodations.

## 2. Objectives
- Allow hosts to list properties with details (images, location, price, availability).
- Allow guests to search and book properties.
- Enable secure payments.
- Provide reviews and ratings for trust.
- Ensure responsive design for web and mobile.

## 3. Target Users
- **Hosts**: Individuals who want to list properties for short-term rental.
- **Guests**: Users looking to book accommodations.

## 4. Key Features
- **Authentication**: User signup/login (email, social logins optional).
- **Property Listings**: Add, edit, delete property details.
- **Search & Filter**: Location, price, dates, property type.
- **Booking**: Reserve property with real-time availability.
- **Payments**: Secure checkout (Stripe/Paystack).
- **Reviews & Ratings**: Guests leave reviews after booking.
- **Favorites**: Guests save preferred properties.

## 5. Non-Functional Requirements
- Scalability: Handle growing number of users.
- Security: Follow best practices for authentication and payments.
- Performance: Fast page load and API response (<200ms for most endpoints).
- Reliability: 99.9% uptime target.

## 6. Assumptions & Dependencies
- Users have internet access.
- Payment gateway integration required.
- Database designed as per ERD (see `/docs/database/database.md`).

## 7. Milestones
1. Setup backend architecture ✅
2. Implement core business logic (properties, bookings, payments).
3. Build frontend integration.
4. Testing (unit, integration, end-to-end).
5. Deployment.
