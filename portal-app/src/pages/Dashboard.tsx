import React from 'react';
import { Outlet } from 'react-router-dom';
import Sidebar from '../components/Sidebar';

const Dashboard: React.FC = () => {
  return (
    <div className="d-flex">
      <Sidebar />
      <main className="flex-grow-1 p-4">
        <Outlet />
      </main>
    </div>
  );
};

export default Dashboard;