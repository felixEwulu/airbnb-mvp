# Frequently Asked Questions (FAQ)

### Q: How do I set up the project locally?
1. Clone the repository.
2. Run `dotnet restore` in the root.
3. Start the backend with `dotnet run --project backend/Airbnb.Api`.

### Q: Where is the database schema?
The ERD is available in `docs/images/erd.png`, and details are in [database.md](../database/database.md).

### Q: How are dependencies managed?
All dependencies are managed via NuGet for .NET and npm for frontend.

### Q: How are tests run?
Run:
```bash
dotnet test ./backend/Airbnb.Tests/Airbnb.Tests.csproj
Q: How do I contribute?

Check the contributing guide
 for branch naming, commit messages, and pull request workflow.

Q: What’s next on the roadmap?

See roadmap.md
 for planned features and milestones.