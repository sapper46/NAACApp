module.exports = {
  apps: [{
    name: 'naac-finance-frontend',
    script: 'serve',
    env: {
      PM2_SERVE_PATH: '/var/www/html',
      PM2_SERVE_PORT: 3000,
      PM2_SERVE_SPA: 'true',
      PM2_SERVE_HOMEPAGE: '/index.html'
    },
    env_production: {
      NODE_ENV: 'production',
      REACT_APP_API_URL: 'https://ec2-18-188-55-197.us-east-2.compute.amazonaws.com/api'
    }
  }]
};