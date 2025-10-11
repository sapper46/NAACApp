@echo off
echo Setting up NAAC Finance Portal...

echo.
echo Installing frontend dependencies...
cd portal-app
call npm install
if %errorlevel% neq 0 (
    echo Error installing frontend dependencies
    pause
    exit /b 1
)

echo.
echo Restoring backend dependencies...
cd ..\portal-api
call dotnet restore
if %errorlevel% neq 0 (
    echo Error restoring backend dependencies
    pause
    exit /b 1
)

echo.
echo Setup complete!
echo.
echo To run the application:
echo 1. Start PostgreSQL service
echo 2. Run 'run-backend.bat' to start the API
echo 3. Run 'run-frontend.bat' to start the React app
echo.
echo Default login: admin / admin123
pause