# User Management API

A .NET 7 Web API for managing users, built with scalability and maintainability in mind.

## Features
- **CRUD Operations**: Create, read, update, and delete users.
- **Validation**: Ensures proper data integrity using annotations.
- **Swagger Documentation**: Interactive API testing via Swagger UI.
- **Containerized**: Docker support for easy deployment.
- **CI/CD**: Automated testing and deployment using GitHub Actions.

## Getting Started

### Prerequisites
- .NET 7 SDK
- Docker (optional)

### Running Locally
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/UserManagementApi.git
   cd UserManagementApi
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run --project UserManagementApi
   ```

4. Access Swagger UI at:
   ```
   http://localhost:5000/swagger
   ```

### Running with Docker
1. Build the Docker image:
   ```bash
   docker build -t usermanagementapi .
   ```

2. Run the Docker container:
   ```bash
   docker run -d -p 8080:80 usermanagementapi
   ```

3. Access the API at:
   ```
   http://localhost:8080/swagger
   ```

### CI/CD Workflow
This project uses GitHub Actions for CI/CD, including:
- **Build**: Ensures the project builds successfully.
- **Test**: Runs unit tests.
- **Deploy**: Builds and pushes a Docker image to Docker Hub.

## License
This project is licensed under the MIT License.
# ai-.net-service-testing
