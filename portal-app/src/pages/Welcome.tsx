import React from 'react';

const Welcome: React.FC = () => {
  return (
    <div 
      className="container-fluid vh-100 d-flex align-items-center justify-content-center position-relative"
      style={{
        backgroundImage: 'url(/background.jpg)',
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        backgroundRepeat: 'no-repeat',
        minHeight: '100vh'
      }}
    >
      {/* Dark overlay for better text readability */}
      <div 
        className="position-absolute top-0 start-0 w-100 h-100"
        style={{
          backgroundColor: 'rgba(0, 0, 0, 0.4)',
          zIndex: 1
        }}
      ></div>
      
      {/* Content card with 25% margins */}
      <div 
        className="position-relative"
        style={{ 
          zIndex: 2,
          width: '50%', // 25% margins on each side = 50% content width
          margin: '25% auto'
        }}
      >
        <div className="card bg-dark text-white shadow-lg border-secondary">
          <div className="card-body p-5 text-center">
            <h1 className="display-4 card-title mb-4">Welcome to NAAC Finance</h1>
            <p className="lead card-text mb-4">Your comprehensive financial data portal</p>
            <hr className="my-4 border-secondary" />
            <p className="card-text">Navigate through the sidebar to access tables and financial figures.</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Welcome;