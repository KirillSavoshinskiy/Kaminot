import { Currency } from "./currency";

export interface Payment {
    id: number;
    paymentSystemId: number;
    name: string;
    description: string;
    sum: number;
    currency: Currency;
    status: string;
}