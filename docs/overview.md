# NAAC Finance Application Overview

## Technology Stack

### Frontend
- **Framework**: React with TypeScript
- **CSS Framework**: Bootstrap 5 with `data-bs-theme="dark"`
- **Runtime**: Node.js

### Backend
- **Framework**: .NET (C#)
- **Database**: PostgreSQL
- **Architecture**: Controller-Service-Repository pattern
- **Authentication**: SHA-256 password hashing

### Development Standards
- Clean, minimal code with only necessary comments
- Alphabetical ordering where possible
- Use enums instead of strings
- Organized folder structure

## Project Structure

```
portal-app/     # Frontend React application
portal-api/     # Backend .NET API
```

## Application Features

### Authentication System
- **Login Page**: Username and password authentication
- **Password Security**: SHA-256 hashing (passwords never stored in plain text)
- **User Management**: Secure user account system with database storage

### Main Navigation
Landing page displays: **"Welcome to NAAC Finance"** (accessible only after login)

Sidebar navigation with 7 options:
1. **Welcome** - Main landing page
2. **Table A** - Numerical data table
3. **Table B** - Animal names table
4. **Table C** - Correlated data pairs
5. **Figure 1** - Column sum calculations
6. **Figure 2** - Animal distribution bar chart
7. **Figure 3** - XY scatter plot

### Database Tables

#### Users Table
- **Columns**: UserId, Username, PasswordHash, CreatedDate, LastLogin
- **Security**: Passwords hashed using SHA-256 before storage
- **Purpose**: User authentication and account management

### Data Tables

#### Table A
- **Columns**: A, B, C, D, E (5 columns)
- **Rows**: 5 rows of data
- **Data Type**: Random numbers
- **Source**: TableA in backend database

#### Table B
- **Columns**: A, B, C, D, E (5 columns)
- **Rows**: 5 rows of data
- **Data Type**: Random animal names (bird, dog, cat, etc.)
- **Source**: TableB in backend database

#### Table C
- **Columns**: A, B (2 columns)
- **Rows**: 20 rows of data
- **Data Type**: Positively correlated numbers (0-100 range)
- **Source**: TableC in backend database

### Visualizations

#### Figure 1: Column Summations
- Calculates and displays the sum of each column in Table A
- Shows 5 different calculated values

#### Figure 2: Animal Distribution Chart
- Bar chart visualization of animal frequency from Table B
- Displays count/distribution of each animal type

#### Figure 3: Correlation Scatter Plot
- XY scatter plot with Column A values on X-axis
- Column B values on Y-axis (from Table C)
- Visualizes the positive correlation between the datasets

## Backend Architecture

### Authentication Components
- **AuthController.cs** - Handles login/logout endpoints
- **AuthService.cs** - Manages authentication logic and password hashing
- **UserRepository.cs** - Database operations for user management
- **SHA-256 Hashing Library** - Secure password hashing implementation

### Base Classes
Three foundational files implementing the repository pattern:

1. **BaseController.cs** - Base controller with common API functionality
2. **BaseService.cs** - Base service layer for business logic
3. **BaseRepository.cs** - Base repository with CRUD operations for PostgreSQL

Future controllers, services, and repositories will inherit from these base classes.

### Security Features
- **Password Hashing**: SHA-256 algorithm for secure password storage
- **Session Management**: Secure user session handling
- **Authentication Middleware**: Route protection for authenticated users only

## User Flow

### Authentication Flow
1. **Login Page** - User enters username and password
2. **Password Validation** - Backend hashes input password and compares with stored hash
3. **Session Creation** - Successful login creates authenticated session
4. **Route Protection** - All application pages require valid authentication
5. **Logout** - Secure session termination

### Application Flow
1. User accesses login page
2. After successful authentication, user is redirected to main dashboard
3. All navigation and data access requires maintained authentication session

## Visualization Library
- Use a Python matplotlib-like library for generating charts and figures
- Integrate with the React frontend for seamless data visualization

## Security Considerations
- **No Plain Text Passwords**: All passwords hashed using SHA-256 before database storage
- **Secure Session Management**: Proper session handling and timeout
- **Authentication Required**: All application features protected behind login
- **Password Hashing Library**: Implement robust SHA-256 hashing with salt (recommended)  



