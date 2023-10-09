import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaymentSystem } from '../models/payment-system';
import { Observable } from 'rxjs';
import { CreatePayment } from '../models/create-payment';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  public pSystems: PaymentSystem[] = [];

  constructor(private readonly httpClient: HttpClient) { }

  public getAllPaymentSystems(): Observable<PaymentSystem[]>{
    return this.httpClient.get<PaymentSystem[]>("https://localhost:7290/payment-system/get-all");
  }

  public createPayment(payment: CreatePayment): Observable<any> {
    return this.httpClient.post("https://localhost:7290/payment-system/create-payment", payment);
  }
}
