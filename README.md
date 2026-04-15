# CandidateTest

Professional Blazor + .NET 10 + SQL Server CRUD assignment using the exact required names:

- Solution: `CandidateTest`
- Project: `CandidateTest.Web`
- Database: `CandidateTestDb`
- Table: `Users`

## Stack

- .NET 10
- Blazor Web App with interactive server rendering
- Entity Framework Core 10
- SQL Server / SQL Server LocalDB

## Features

- View all users
- View a single user
- Create a user
- Edit a user
- Delete a user
- Server-side EF Core persistence
- SQL migration included
- LocalDB connection string included

## Project Structure

- `CandidateTest.sln`
- `CandidateTest.Web/Components/Pages/Users` for CRUD pages
- `CandidateTest.Web/Data` for `CandidateTestDbContext`
- `CandidateTest.Web/Models` for entity model
- `CandidateTest.Web/Services` for data access abstraction
- `CandidateTest.Web/Migrations` for initial EF migration
- `CandidateTest.Web/DatabaseSetup.sql` optional manual database script

## How to Run in Visual Studio 2026

1. Open `CandidateTest.sln`
2. Restore NuGet packages
3. Ensure SQL Server LocalDB is available
4. Check connection string in `CandidateTest.Web/appsettings.json`
5. Run the project


## DB Migration
The application calls `Database.Migrate()` on startup, so the `CandidateTestDb` database and `Users` table are created automatically if migrations can run.
If still not migrated then run following commands in the Package Manager Console
add-migration initialcreate
update-database


## Alternative Database Setup

If you prefer manual setup, run `CandidateTest.Web/DatabaseSetup.sql` against SQL Server or LocalDB, then start the application.

## Notes

- Authentication and authorization are intentionally excluded per the assignment rules.
- Styling is intentionally simple and professional.
- Email is enforced as unique to avoid duplicate records.
