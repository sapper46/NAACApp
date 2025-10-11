export interface User {
  userId: number;
  username: string;
  createdDate: Date;
  lastLogin?: Date;
}

export interface LoginRequest {
  username: string;
  password: string;
}

export interface LoginResponse {
  success: boolean;
  token?: string;
  user?: User;
  message?: string;
}

export interface TableARow {
  id: number;
  columnA: number;
  columnB: number;
  columnC: number;
  columnD: number;
  columnE: number;
}

export interface TableBRow {
  id: number;
  columnA: string;
  columnB: string;
  columnC: string;
  columnD: string;
  columnE: string;
}

export interface TableCRow {
  id: number;
  columnA: number;
  columnB: number;
}

export interface ColumnSums {
  columnA: number;
  columnB: number;
  columnC: number;
  columnD: number;
  columnE: number;
}

export interface AnimalCount {
  animal: string;
  count: number;
}

export enum NavigationItem {
  Welcome = 'Welcome',
  TableA = 'Table A',
  TableB = 'Table B',
  TableC = 'Table C',
  Figure1 = 'Figure 1',
  Figure2 = 'Figure 2',
  Figure3 = 'Figure 3'
}