# Weather Forecast Application with CI/CD Pipeline

This project demonstrates an end-to-end CI/CD pipeline for deploying a web application built with Angular (frontend) and .NET Core (backend) to Azure App Service.

## Project Structure

```
├── backend/                  # .NET Core backend application
│   └── WeatherApi/           # Weather API project
│       ├── Controllers/      # API controllers
│       ├── Models/           # Data models
│       └── Data/             # JSON data files
├── frontend/                 # Angular frontend application
│   ├── src/                  # Source code
│   │   ├── app/              # Angular components, services, models
│   │   │   ├── components/   # UI components
│   │   │   ├── services/     # API services
│   │   │   └── models/       # Data models
│   │   ├── assets/           # Static assets
│   │   └── environments/     # Environment configurations
├── pipelines/                # CI/CD pipeline configurations
│   └── azure-pipelines.yml   # Azure DevOps pipeline definition
└── infrastructure/           # Infrastructure as Code
    └── azure-app-service.yml # Azure App Service configuration
```

## Application Overview

This application is a simple weather forecast viewer that:

1. Displays weather forecasts from a .NET Core API
2. Uses a JSON file as a data source (no database required)
3. Provides a responsive UI built with Angular and Bootstrap

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/) (v16.x or later)
- [Angular CLI](https://cli.angular.io/) (`npm install -g @angular/cli`)
- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli) (for deployment)
- [Azure DevOps account](https://dev.azure.com/) (for CI/CD pipeline)

## Running Locally

### Backend (.NET Core API)

1. Navigate to the backend project directory:
   ```
   cd backend/WeatherApi
   ```

2. Restore NuGet packages:
   ```
   dotnet restore
   ```

3. Run the API:
   ```
   dotnet run
   ```

The API will be available at `http://localhost:5000/api/weatherforecast`.

### Frontend (Angular)

1. Navigate to the frontend project directory:
   ```
   cd frontend
   ```

2. Install dependencies:
   ```
   npm install
   ```

3. Start the development server:
   ```
   npm start
   ```

The application will be available at `http://localhost:4200/`.

## Deployment

### Setting Up Azure DevOps Pipeline

1. Create a new project in Azure DevOps.

2. Import the repository containing this code.

3. Create a new pipeline:
   - Go to Pipelines > Create Pipeline
   - Select your repository
   - Configure your pipeline by selecting "Existing Azure Pipelines YAML file"
   - Select `/pipelines/azure-pipelines.yml`

4. Create an Azure Resource Manager service connection:
   - Go to Project Settings > Service connections
   - Create a new Azure Resource Manager service connection
   - Name it "Azure Subscription" (to match the name in the pipeline)

5. Run the pipeline to build and deploy the application.

### Manual Deployment

You can also deploy the application manually using the Azure CLI:

1. Create Azure resources:
   ```
   az deployment sub create --location eastus --template-file infrastructure/azure-app-service.yml
   ```

2. Build and publish the backend:
   ```
   dotnet publish backend/WeatherApi -c Release -o ./publish/backend
   ```

3. Build the frontend:
   ```
   cd frontend
   npm install
   npm run build
   ```

4. Deploy the backend:
   ```
   az webapp deployment source config-zip --resource-group weather-app-dev-rg --name weather-app-dev-api --src ./publish/backend.zip
   ```

5. Deploy the frontend:
   ```
   az webapp deployment source config-zip --resource-group weather-app-dev-rg --name weather-app-dev-web --src ./frontend/dist/weather-app.zip
   ```

## CI/CD Pipeline

The CI/CD pipeline is configured to:

1. Build both the frontend and backend applications
2. Run tests (if added in the future)
3. Deploy to Azure App Service
4. The pipeline is triggered on changes to the main branch

## Future Enhancements

- Add authentication and user management
- Implement a database for persistent storage
- Add unit and integration tests
- Set up staging and production environments