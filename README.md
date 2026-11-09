# RaceDay MVC

RaceDay MVC is the ASP.NET Core MVC web application for the RaceDay event platform. It provides a browser-based interface for account registration and sign-in, race-event pages, and organiser and participant areas. The MVC app communicates with the RaceDay API over HTTP.

## Features

- Register and sign in through the RaceDay API.
- Store the API-issued JWT in an HTTP-only cookie and attach it to API requests.
- Redirect signed-in users to organiser or participant areas according to their role.
- View event pages and organiser event listings.
- Create events with details and an optional banner image.
- Browse participant pages for events, enrolments, results, and profile information.

> Some participant and event pages may currently be UI scaffolding; availability depends on the API and implementation state.

## Technology

- .NET 8 / ASP.NET Core MVC
- C# and Razor views
- HTML, CSS, and JavaScript
- A separate RaceDay API project (referenced by the solution)

## Prerequisites

- .NET 8 SDK
- The RaceDay API project and its own prerequisites, running locally and reachable at `https://localhost:7258/` (the current URL configured by the MVC app)

## Run locally

The solution references the API project at `..\RaceDay_api\RaceDay_api.csproj`, so arrange the MVC and API projects as sibling directories, or update the project reference if your checkout uses a different layout.

1. Start the RaceDay API and ensure its HTTPS endpoint is `https://localhost:7258/`.
2. From this repository's directory, run the MVC application:

   ```bash
   dotnet run --project RaceDay_MVC.csproj
   ```

3. Open the local URL printed by `dotnet run` in your browser.

Alternatively, open `RaceDay_MVC.sln` in Visual Studio, set `RaceDay_MVC` as the startup project, and run it while the API is available.

## Configuration

The named `RaceDayApi` HTTP client is configured in `Program.cs`. If the API uses a different URL, update its `BaseAddress` there. The current development setup bypasses TLS certificate validation for the API client; use a trusted development certificate locally and remove that bypass before deploying or using this configuration outside a controlled development environment.

General ASP.NET Core settings, including logging and allowed hosts, are in `appsettings.json`.

## Project layout

```text
Controllers/   MVC controllers and API-facing actions
Models/        View models and API data-transfer models
Services/      Shared HTTP client support, including JWT forwarding
Views/         Razor views
wwwroot/       Static assets (CSS, JavaScript, images)
Program.cs     Application and dependency-injection setup
```

## Notes

This repository contains the MVC front end. API-backed features require the separate RaceDay API to be running and configured as described above.
