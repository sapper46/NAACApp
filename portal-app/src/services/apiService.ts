import { LoginRequest, LoginResponse, TableARow, TableBRow, TableCRow, User } from '../types';

const API_BASE_URL = process.env.REACT_APP_API_URL || 'http://localhost:5000/api';

class ApiService {
  private getHeaders(): Record<string, string> {
    const headers: Record<string, string> = {
      'Content-Type': 'application/json',
    };
    
    const token = localStorage.getItem('token');
    if (token) {
      headers['Authorization'] = `Bearer ${token}`;
    }
    
    return headers;
  }

  async login(credentials: LoginRequest): Promise<LoginResponse> {
    const response = await fetch(`${API_BASE_URL}/auth/login`, {
      method: 'POST',
      headers: this.getHeaders(),
      body: JSON.stringify(credentials),
    });
    
    const result = await response.json();
    if (result.success && result.token) {
      localStorage.setItem('token', result.token);
      localStorage.setItem('user', JSON.stringify(result.user));
    }
    
    return result;
  }

  async logout(): Promise<void> {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
  }

  getCurrentUser(): User | null {
    const userStr = localStorage.getItem('user');
    return userStr ? JSON.parse(userStr) : null;
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }

  async getTableA(): Promise<TableARow[]> {
    const response = await fetch(`${API_BASE_URL}/data/tablea`, {
      headers: this.getHeaders(),
    });
    return response.json();
  }

  async getTableB(): Promise<TableBRow[]> {
    const response = await fetch(`${API_BASE_URL}/data/tableb`, {
      headers: this.getHeaders(),
    });
    return response.json();
  }

  async getTableC(): Promise<TableCRow[]> {
    const response = await fetch(`${API_BASE_URL}/data/tablec`, {
      headers: this.getHeaders(),
    });
    return response.json();
  }
}

export const apiService = new ApiService();