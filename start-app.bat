@echo off
echo Starting Weather App...
echo.

echo Starting .NET Core Backend...
start cmd /k "cd backend\WeatherApi && dotnet run"
echo Backend starting at http://localhost:5000/api/weatherforecast
echo.

echo Waiting for backend to initialize (10 seconds)...
timeout /t 10 /nobreak > nul

echo Starting Angular Frontend...
start cmd /k "cd frontend && npm install && npm start"
echo Frontend will be available at http://localhost:4200
echo.

echo Both servers are starting...
echo - Backend: http://localhost:5000/api/weatherforecast
echo - Frontend: http://localhost:4200
echo.
echo You can close this window after you're done using the application.
echo To stop the servers, close their respective command windows.