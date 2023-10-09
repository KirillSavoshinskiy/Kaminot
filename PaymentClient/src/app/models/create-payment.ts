import { Currency } from "./currency";

export interface CreatePayment {
    paymentSystemId: number; 
    name: string;
    description: string;
    amount: number;
    currency: Currency | null; 
}