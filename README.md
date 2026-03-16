# PackAndGo

## Description
PackAndGo is an ASP.NET Core Web API for the travel industry that allows users to book travel packages, including flights and hotels. The system includes functionality for searching holiday options, booking them, and checking their status.

## Features
- Search — Search for holiday options (HotelOnly, HotelAndFlight, LastMinuteHotels)
- Booking — Book a selected holiday option
- Status Check — Check the status of a booking (Pending, Success, Failed)
- Global Exception Handling — Generic error responses, internal details never exposed
- Header Authorization — API key based authentication

## Technologies Used
- .NET 10
- ASP.NET Core Web API
- C#
- In-memory storage (no database required)
  
## Setup
1. Clone the repo: https://github.com/lazartrajkovski/PackAndGo.git
2. Open the solution in Visual Studio or any .NET-compatible IDE
3. Run the project — no additional configuration required
4. Use the requests.txt file for sample requests
   
## Authorization
All endpoints require an Authorization header with the API key:
Authorization: test-api-key

## Endpoints
POST /api/Search - Search for available holiday options
POST /api/Booking - Book a selected option         
GET /api/Status?bookingCode={bookingCode} - Check the status of a booking 
