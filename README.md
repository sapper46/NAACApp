# NAAC Finance Portal

A comprehensive financial data portal built with React TypeScript frontend and .NET Web API backend with PostgreSQL database.

## Features

- **Secure Authentication**: SHA-256 password hashing with JWT token-based authentication
- **Dark Theme**: Bootstrap 5 dark theme throughout the application
- **Data Tables**: Three data tables (TableA: numerical, TableB: animals, TableC: correlated data)
- **Visualizations**: Column calculations, bar charts, and scatter plots
- **Responsive Design**: Mobile-friendly interface with sidebar navigation

## Technology Stack

### Frontend
- React 18 with TypeScript
- React Router for navigation
- Bootstrap 5 with dark theme
- Chart.js for data visualization
- Axios for API communication

### Backend
- .NET 8 Web API
- Entity Framework Core with PostgreSQL
- JWT Authentication
- BCrypt for password hashing
- Swagger/OpenAPI documentation

### Database
- PostgreSQL with Entity Framework migrations
- Seeded data for testing and development

## Project Structure

```
FinanceWork/
├── portal-app/          # React frontend application
│   ├── src/
│   │   ├── components/  # Reusable React components
│   │   ├── pages/       # Page components
│   │   ├── services/    # API service layer
│   │   └── types/       # TypeScript type definitions
│   └── public/          # Static assets
├── portal-api/          # .NET Web API backend
│   ├── Controllers/     # API controllers
│   ├── Services/        # Business logic layer
│   ├── Repositories/    # Data access layer
│   ├── Models/          # Data models and DTOs
│   └── Data/            # Entity Framework context
└── docs/                # Project documentation
```

## Quick Start

### Prerequisites
- Node.js 18+ and npm
- .NET 8 SDK
- PostgreSQL 12+

### Installation

1. **Clone and setup the project:**
   ```bash
   # Run the setup script
   setup.bat
   ```

2. **Configure the database:**
   - Ensure PostgreSQL is running
   - Create database: `naac_finance`
   - Update connection string in `portal-api/appsettings.json` if needed

3. **Start the backend API:**
   ```bash
   run-backend.bat
   ```
   API will be available at: http://localhost:5000

4. **Start the frontend application:**
   ```bash
   run-frontend.bat
   ```
   Application will be available at: http://localhost:3000

### Default Login Credentials
- **Username:** admin
- **Password:** admin123

## API Endpoints

### Authentication
- `POST /api/auth/login` - User login
- `POST /api/auth/logout` - User logout

### Data Access (Requires Authentication)
- `GET /api/data/tablea` - Get numerical data table
- `GET /api/data/tableb` - Get animal data table
- `GET /api/data/tablec` - Get correlated data pairs
- `GET /api/data/columnsums` - Get column sum calculations
- `GET /api/data/animalcounts` - Get animal count statistics

## Application Pages

1. **Login Page** - Secure authentication with username/password
2. **Welcome** - Main dashboard welcome page
3. **Table A** - Displays 5x5 numerical data table
4. **Table B** - Displays 5x5 animal names table
5. **Table C** - Displays 2x20 correlated numerical data
6. **Figure 1** - Column sum calculations from Table A
7. **Figure 2** - Bar chart of animal distribution from Table B
8. **Figure 3** - Scatter plot of correlated data from Table C

## Architecture

### Backend Architecture
- **Controller-Service-Repository Pattern**
- **Base Classes**: `BaseController`, `BaseService`, `BaseRepository`
- **Dependency Injection**: Services registered in Program.cs
- **Authentication Middleware**: JWT token validation
- **CORS Configuration**: Configured for React app

### Frontend Architecture
- **Component-Based**: Reusable React components
- **Route Protection**: Authentication required for all pages
- **State Management**: React hooks for local state
- **API Service Layer**: Centralized API communication
- **TypeScript**: Type-safe development

## Security Features

- **Password Hashing**: BCrypt for secure password storage
- **JWT Tokens**: Secure authentication with 7-day expiration
- **Route Protection**: All data endpoints require authentication
- **CORS**: Configured to allow requests from React app only
- **Input Validation**: Server-side validation for all inputs

## Database Schema

### Users Table
- UserId (Primary Key)
- Username (Unique)
- PasswordHash (BCrypt hashed)
- CreatedDate
- LastLogin

### Data Tables
- **TableA**: 5 numerical columns (A-E) with 5 rows
- **TableB**: 5 string columns (A-E) with animal names and 5 rows
- **TableC**: 2 numerical columns (A-B) with 20 rows of correlated data

## Development

### Adding New Features
1. **Backend**: Create models, add to DbContext, create repository/service methods, add controller endpoints
2. **Frontend**: Create TypeScript types, add API calls to service, create/update components

### Database Migrations
```bash
cd portal-api
dotnet ef migrations add MigrationName
dotnet ef database update
```

### Testing
- Backend: Swagger UI available at http://localhost:5000/swagger
- Frontend: React development tools for debugging

## Troubleshooting

### Common Issues
1. **Database Connection**: Verify PostgreSQL is running and connection string is correct
2. **CORS Errors**: Ensure backend is running on port 5000 and frontend on port 3000
3. **Authentication Issues**: Check JWT configuration and token storage in localStorage
4. **Package Installation**: Run `npm install` in portal-app and `dotnet restore` in portal-api

### Logs
- Backend: Console logs and error messages
- Frontend: Browser developer console

## Future Enhancements

- User registration and role-based access
- Data export functionality
- Real-time data updates
- Advanced filtering and search
- Audit logging
- Email notifications
- Multiple themes support

## License

This project is licensed under the MIT License.

## Support

For issues and questions, please refer to the project documentation or create an issue in the repository.