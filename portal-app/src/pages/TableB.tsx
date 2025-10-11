import React, { useEffect, useState } from 'react';
import { TableBRow } from '../types';
import { apiService } from '../services/apiService';

const TableB: React.FC = () => {
  const [data, setData] = useState<TableBRow[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchData = async () => {
      try {
        const result = await apiService.getTableB();
        setData(result);
      } catch (err) {
        setError('Failed to load table data');
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  if (loading) {
    return <div className="text-center">Loading...</div>;
  }

  if (error) {
    return <div className="alert alert-danger">{error}</div>;
  }

  return (
    <div className="container-fluid">
      <h2 className="mb-4">Table B - Animal Data</h2>
      <div className="table-responsive">
        <table className="table table-dark table-striped table-hover">
          <thead>
            <tr>
              <th scope="col">ID</th>
              <th scope="col">Column A</th>
              <th scope="col">Column B</th>
              <th scope="col">Column C</th>
              <th scope="col">Column D</th>
              <th scope="col">Column E</th>
            </tr>
          </thead>
          <tbody>
            {data.map((row) => (
              <tr key={row.id}>
                <td>{row.id}</td>
                <td>{row.columnA}</td>
                <td>{row.columnB}</td>
                <td>{row.columnC}</td>
                <td>{row.columnD}</td>
                <td>{row.columnE}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default TableB;