# Running the Weather App Locally

This guide provides step-by-step instructions for running both the backend (.NET Core) and frontend (Angular) components of the Weather App locally.

## Quick Start

For your convenience, we've provided scripts to start both the backend and frontend with a single command:

### Windows
Simply double-click the `start-app.bat` file or run it from the command prompt:
```
start-app.bat
```

### Linux/macOS
Make the script executable and run it:
```
chmod +x start-app.sh
./start-app.sh
```

These scripts will:
1. Start the .NET Core backend
2. Wait for it to initialize
3. Start the Angular frontend (including installing dependencies)
4. Display the URLs where the applications are available

## Manual Setup

If you prefer to start the applications manually, follow these instructions:

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/) (v16.x or later)
- [Angular CLI](https://cli.angular.io/) (`npm install -g @angular/cli`)

### Running the Backend (.NET Core API)

1. Open a terminal/command prompt
2. Navigate to the backend project directory:
   ```
   cd backend/WeatherApi
   ```

3. Restore NuGet packages:
   ```
   dotnet restore
   ```

4. Build the project:
   ```
   dotnet build
   ```

5. Run the API:
   ```
   dotnet run
   ```

6. The API will start and be available at:
   - http://localhost:5000/api/weatherforecast (HTTP)
   - https://localhost:5001/api/weatherforecast (HTTPS)

7. You can test the API by opening the URL in a browser or using a tool like [Postman](https://www.postman.com/) or [curl](https://curl.se/):
   ```
   curl http://localhost:5000/api/weatherforecast
   ```

### Using Swagger UI

The backend API includes Swagger UI, which provides interactive documentation for the API endpoints. To access Swagger UI:

1. Start the backend server as described above
2. Open a web browser and navigate to:
   - http://localhost:5000/swagger (HTTP)
   - https://localhost:5001/swagger (HTTPS)

Swagger UI allows you to:
- View all available API endpoints
- See the request and response models
- Test the API endpoints directly from the browser
- Explore the API documentation

## Running the Frontend (Angular)

1. Open a new terminal/command prompt (keep the backend running in the first terminal)
2. Navigate to the frontend project directory:
   ```
   cd frontend
   ```

3. Install dependencies (this only needs to be done once, or when dependencies change):
   ```
   npm install
   ```

4. Start the Angular development server:
   ```
   npm start
   ```
   or
   ```
   ng serve
   ```

5. The Angular application will start and be available at:
   - http://localhost:4200

6. Open a web browser and navigate to http://localhost:4200 to view the application

## Connecting Frontend to Backend

By default, the frontend is configured to connect to the backend at `http://localhost:5000`. If your backend is running on a different port or URL, you'll need to update the API URL in the `WeatherService`:

1. Open `frontend/src/app/services/weather.service.ts`
2. Update the `apiUrl` property to match your backend URL:
   ```typescript
   private apiUrl = 'http://localhost:5000/api/weatherforecast';
   ```

## Troubleshooting

### CORS Issues

If you encounter CORS (Cross-Origin Resource Sharing) issues, ensure that the backend is properly configured to allow requests from the frontend origin. The backend is already configured to allow CORS in the `Program.cs` file:

```csharp
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// ...

// Use CORS
app.UseCors("AllowAngularApp");
```

### Backend Not Starting

If the backend fails to start, check for error messages in the terminal. Common issues include:

- Port conflicts: Another application might be using port 5000 or 5001
- Missing dependencies: Ensure you've run `dotnet restore`
- Invalid configuration: Check the `appsettings.json` file for any errors

### Frontend Not Starting

If the frontend fails to start, check for error messages in the terminal. Common issues include:

- Port conflicts: Another application might be using port 4200
- Missing dependencies: Ensure you've run `npm install`
- Node.js version: Ensure you're using a compatible version of Node.js

## Verifying Everything Works

1. Start the backend (.NET Core API)
2. Start the frontend (Angular)
3. Open a browser and navigate to http://localhost:4200
4. You should see the Weather App interface
5. The app should display weather forecasts fetched from the backend API
6. If the data loads successfully, both components are working correctly!

## Stopping the Applications

- To stop the backend: Press `Ctrl+C` in the terminal where the backend is running
- To stop the frontend: Press `Ctrl+C` in the terminal where the frontend is running