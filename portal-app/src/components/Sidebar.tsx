import React from 'react';
import { Link, useLocation } from 'react-router-dom';
import { NavigationItem } from '../types';
import { apiService } from '../services/apiService';

const Sidebar: React.FC = () => {
  const location = useLocation();
  const user = apiService.getCurrentUser();

  const navigationItems = [
    { path: '/welcome', label: NavigationItem.Welcome, icon: 'bi-house' },
    { path: '/table-a', label: NavigationItem.TableA, icon: 'bi-table' },
    { path: '/table-b', label: NavigationItem.TableB, icon: 'bi-table' },
    { path: '/table-c', label: NavigationItem.TableC, icon: 'bi-table' },
    { path: '/figure-1', label: NavigationItem.Figure1, icon: 'bi-calculator' },
    { path: '/figure-2', label: NavigationItem.Figure2, icon: 'bi-bar-chart' },
    { path: '/figure-3', label: NavigationItem.Figure3, icon: 'bi-scatter-chart' },
  ];

  const handleLogout = () => {
    apiService.logout();
    window.location.href = '/login';
  };

  return (
    <div className="d-flex flex-column flex-shrink-0 p-3 bg-dark border-end" style={{ width: '280px', height: '100vh' }}>
      <div className="mb-3 mb-md-0 me-md-auto text-white text-decoration-none">
        <h4 className="mb-0">NAAC Finance</h4>
        {user && <small className="text-muted">Welcome, {user.username}</small>}
      </div>
      <hr />
      <ul className="nav nav-pills flex-column mb-auto">
        {navigationItems.map((item) => (
          <li key={item.path} className="nav-item">
            <Link
              to={item.path}
              className={`nav-link ${location.pathname === item.path ? 'active' : 'text-white'}`}
            >
              <i className={`${item.icon} me-2`}></i>
              {item.label}
            </Link>
          </li>
        ))}
      </ul>
      <hr />
      <div className="dropdown">
        <button
          className="btn btn-outline-secondary dropdown-toggle w-100"
          type="button"
          data-bs-toggle="dropdown"
          aria-expanded="false"
        >
          Account
        </button>
        <ul className="dropdown-menu">
          <li><button className="dropdown-item" onClick={handleLogout}>Logout</button></li>
        </ul>
      </div>
    </div>
  );
};

export default Sidebar;