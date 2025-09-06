# Contributing to Airbnb MVP

Thank you for considering contributing! By following these guidelines, we can keep the project maintainable and professional.

---

## 1. Branching Strategy

Use descriptive branch names:

| Type       | Format                         | Example                        |
|-----------|--------------------------------|--------------------------------|
| Feature   | `feature/<short-description>`   | `feature/jwt-authentication`   |
| Bug Fix   | `fix/<short-description>`       | `fix/login-error`               |
| Chore     | `chore/<short-description>`     | `chore/update-dependencies`    |

Always branch off `main`.  

---

## 2. Commit Messages

Follow **Conventional Commits** style:

- `feat:` New feature
- `fix:` Bug fix
- `chore:` Non-code changes (docs, CI, refactoring)
- `docs:` Documentation updates
- `test:` Adding or updating tests

**Example:**

feat: add JWT authentication and Swagger support


---

## 3. Pull Requests

1. Push your branch to GitHub.  
2. Open a PR targeting `main`.  
3. Fill in the PR template (if available).  
4. Ensure all CI checks pass before requesting a review.  
5. Merge only after approval. Use **Squash Merge** for cleaner history.

---

## 4. Code Style

- **C# Backend**:
  - PascalCase for classes, camelCase for variables.
  - Use braces `{}` for all control blocks.
  - Keep methods small, modular, and testable.

- **Frontend **:
  

- **General**:
  - Add XML comments for public-facing APIs.
  - Keep files focused (single responsibility principle).

---

## 5. Testing

- Add **unit tests** for all new features.  
- Run tests locally before pushing:

```bash
dotnet test

For frontend changes:

npm test

6. CI/CD

GitHub Actions automatically runs builds and tests on PRs.

Ensure your PR passes CI before merging.

7. Reporting Issues

Search existing issues first.

Provide clear description, steps to reproduce, and expected behavior.

Label the issue if possible (bug, enhancement, question).

Thank you for contributing and keeping this project high-quality!


