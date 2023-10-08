import { Currency } from "./currency";

export interface PaymentSystem {
    id: number;
    name: string;
    description: string;
    currency: Currency[]
}
