# RaceDay MVC

RaceDay MVC is the ASP.NET Core MVC web application for the RaceDay event platform. It provides a browser-based interface for account registration and sign-in, race-event pages, and organiser and participant areas. The MVC app communicates with the RaceDay API over HTTP.

## Features

- Register and sign in through the RaceDay API.
- Store the API-issued JWT in an HTTP-only cookie and attach it to API requests.
- Redirect signed-in users to organiser or participant areas according to their role.
- View event pages and organiser event listings.
- Create events with details and an optional banner image.
- Browse participant pages for events, enrolments, results, and profile information.

## Technology

- .NET 8 / ASP.NET Core MVC
- C# and Razor views
- HTML, CSS, and JavaScript
- A separate RaceDay API project

## Colors used 
- Navy Blue, White, Orange, black these are race colors they bring out the boldness of the raceday theme.  

## Project layout

Controllers/   MVC controllers and API-facing actions
Models/        View models and API data-transfer models
Services/      Shared HTTP client support, including JWT forwarding
Views/         Razor views

## Screenshots 
<img width="1904" height="1010" alt="Screenshot 2026-11-09 125916" src="https://github.com/user-attachments/assets/aef628da-660f-4d81-99c8-983698a0ffcf" /> The Homepage screenshot showing how the home page looks like.
<img width="1904" height="1009" alt="Screenshot 2026-11-09 125933" src="https://github.com/user-attachments/assets/6b1be70c-dc6a-4706-ad6c-864f1f3c0213" /> The AboutUs page screenshot showing how he about us page looks like. 
<img width="1906" height="1012" alt="Screenshot 2026-11-09 125948" src="https://github.com/user-attachments/assets/1e5ccc6d-a601-4bb5-96bd-5df115e38ba3" /> This is the events page it shows all the events avaliable and how the event page looks like.
<img width="1907" height="1003" alt="Screenshot 2026-11-09 130004" src="https://github.com/user-attachments/assets/8463ee7c-94ee-4188-ae3b-303d501a34f4" /> This is the Race Calender page it shows the dates and the times the races are going to take place and this is how it looks like.
<img width="1909" height="1117" alt="Screenshot 2026-11-09 130022" src="https://github.com/user-attachments/assets/82afeb4e-433c-470d-9da1-3e122302c6e0" /> This is the Results page , it shows the rseults of the race, the positions people came in and if they have completed the race, this is how the page looks like.
<img width="1912" height="1119" alt="Screenshot 2026-11-09 130048" src="https://github.com/user-attachments/assets/edecdf6f-12e4-480d-bc56-777e6a57464f" /> This is the contact us page it shows the information needed to contact and a form the user can fill in to send a message and this is how the page looks like. 







