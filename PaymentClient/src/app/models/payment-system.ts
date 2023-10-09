import { Currency } from './currency';
import { Payment } from './payment';

export interface PaymentSystem {
  id: number;
  name: string;
  description: string;
  currencies: Currency[];
  payments: Payment[];
}
