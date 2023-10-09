import { Currency } from "./currency";

export interface Payment {
    id: number; 
    name: string;
    description: string;
    amount: number;
    currency: Currency;
    status: string;
}