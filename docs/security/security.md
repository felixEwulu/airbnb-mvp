# Security Guidelines

This document describes the security practices for the Airbnb clone project.

## Authentication & Authorization
- Authentication is handled via JWT tokens.
- Refresh tokens are stored securely and rotated on login.
- Role-based access control (RBAC) is enforced for API endpoints (e.g., Admin, Host, Guest).

## Data Protection
- Passwords are hashed using industry-standard algorithms (e.g., bcrypt/Argon2).
- Sensitive data (payment info, tokens) is never logged.
- HTTPS is required for all environments.

## Secure Coding Guidelines
- Validate all input to prevent SQL injection and XSS.
- Sanitize user-uploaded content (images, messages).
- Use parameterized queries via Entity Framework Core.

## Monitoring & Incident Response
- Logs are collected via Serilog for API activity and errors.
- Alerts configured in GitHub Actions and cloud environment for anomalies.
- Security patches are applied monthly or as needed.

## OWASP Best Practices
- Broken authentication prevention.
- Sensitive data exposure mitigation.
- Proper error handling and logging.

