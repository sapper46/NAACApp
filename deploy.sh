#!/bin/bash
# AWS Deployment Script for NAAC Finance

echo "Starting deployment..."

# Variables
APP_DIR="/home/ec2-user/naac-finance"
API_DIR="$APP_DIR/portal-api"
FRONTEND_DIR="$APP_DIR/portal-app"

# Stop existing processes
sudo systemctl stop naac-finance-api
pm2 stop naac-finance-frontend || true

# Navigate to app directory
cd $APP_DIR

# Pull latest changes
git pull origin main

# Backend deployment
echo "Deploying backend..."
cd $API_DIR
dotnet restore
dotnet build --configuration Release
dotnet publish -c Release -o /var/www/naac-finance-api

# Frontend deployment
echo "Deploying frontend..."
cd $FRONTEND_DIR
npm install
npm run build
sudo rm -rf /var/www/html/*
sudo cp -r build/* /var/www/html/

# Start services
sudo systemctl start naac-finance-api
pm2 start ecosystem.config.js --env production

# Restart nginx
sudo systemctl restart nginx

echo "Deployment completed successfully!"