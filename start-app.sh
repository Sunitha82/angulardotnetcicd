#!/bin/bash

echo "Starting Weather App..."
echo ""

echo "Starting .NET Core Backend..."
gnome-terminal -- bash -c "cd backend/WeatherApi && dotnet run; exec bash" || \
xterm -e "cd backend/WeatherApi && dotnet run; exec bash" || \
open -a Terminal.app "cd backend/WeatherApi && dotnet run"
echo "Backend starting at http://localhost:5000/api/weatherforecast"
echo ""

echo "Waiting for backend to initialize (10 seconds)..."
sleep 10

echo "Starting Angular Frontend..."
gnome-terminal -- bash -c "cd frontend && npm install && npm start; exec bash" || \
xterm -e "cd frontend && npm install && npm start; exec bash" || \
open -a Terminal.app "cd frontend && npm install && npm start"
echo "Frontend will be available at http://localhost:4200"
echo ""

echo "Both servers are starting..."
echo "- Backend: http://localhost:5000/api/weatherforecast"
echo "- Frontend: http://localhost:4200"
echo ""
echo "You can close this window after you're done using the application."
echo "To stop the servers, close their respective terminal windows or press Ctrl+C in each."