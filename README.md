# RegistrationDemo

## System Requirements
1. Microsoft SQL Server must be installed on the system.
2. Node.js and Angular CLI must be installed for the frontend development environment.

## Setup Instructions

### 1. Database Setup
   - Install Microsoft SQL Server if not already installed.
   - Create a new database in SQL Server for the project.

### 2. Backend Setup
   - Open the solution (.sln) file in your preferred IDE (e.g., Visual Studio, Visual Studio Code, JetBrains Rider).
   - Modify the connection string in the `appsettings.json` file of the API project to point to the created database.
   - Additionally, update the connection string in the `UsersContextFactory.cs` file located in the Database project.

### 3. Frontend Setup
   - Open a terminal or command prompt.
   - Navigate to the frontend project directory within the solution.
   - Ensure Node.js is installed on your system.
   - Install Angular CLI globally using the following command:
     ```
     npm install -g @angular/cli
     ```
   - Install frontend dependencies by running:
     ```
     npm install
     ```

## Running the Project
1. Launch the Backend/API:
   - Build and run the API project in your IDE.

2. Launch the Frontend:
   - Navigate to the frontend project directory in the terminal.
   - Run the Angular development server using the following command:
     ```
     ng serve
     ```

3. Access the Application:
   - Once both the API and frontend are running, access the application in your web browser.
   - The frontend will typically be accessible at http://localhost:4200/.
