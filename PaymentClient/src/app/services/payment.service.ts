import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaymentSystem } from '../models/payment-system';
import { Observable } from 'rxjs';
import { CreatePayment } from '../models/create-payment';
import { Payment } from '../models/payment';

@Injectable({
  providedIn: 'root',
})
export class PaymentService {
  private baseUrl = 'https://localhost:7290/';
  public pSystems: PaymentSystem[] = [];

  constructor(private readonly httpClient: HttpClient) {}

  public getAllPaymentSystems(): Observable<PaymentSystem[]> {
    return this.httpClient.get<PaymentSystem[]>(
      this.baseUrl + 'payment-system/get-all'
    );
  }

  public createPayment(payment: CreatePayment): Observable<Payment> {
    return this.httpClient.post<Payment>(
      this.baseUrl + 'payment-system/create-payment',
      payment
    );
  }

  public processPayment(payment: Payment): Observable<string> {
    return this.httpClient.post<string>(
      this.baseUrl + 'payment-system/process-payment',
      payment
    );
  }
}
