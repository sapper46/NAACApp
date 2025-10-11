import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

import Login from './pages/Login';
import Dashboard from './pages/Dashboard';
import Welcome from './pages/Welcome';
import TableA from './pages/TableA';
import TableB from './pages/TableB';
import TableC from './pages/TableC';
import Figure1 from './pages/Figure1';
import Figure2 from './pages/Figure2';
import Figure3 from './pages/Figure3';
import { apiService } from './services/apiService';

const ProtectedRoute: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  return apiService.isAuthenticated() ? <>{children}</> : <Navigate to="/login" />;
};

const App: React.FC = () => {
  return (
    <div className="App" data-bs-theme="dark">
      <Router>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/" element={
            <ProtectedRoute>
              <Dashboard />
            </ProtectedRoute>
          }>
            <Route index element={<Welcome />} />
            <Route path="welcome" element={<Welcome />} />
            <Route path="table-a" element={<TableA />} />
            <Route path="table-b" element={<TableB />} />
            <Route path="table-c" element={<TableC />} />
            <Route path="figure-1" element={<Figure1 />} />
            <Route path="figure-2" element={<Figure2 />} />
            <Route path="figure-3" element={<Figure3 />} />
          </Route>
        </Routes>
      </Router>
    </div>
  );
};

export default App;