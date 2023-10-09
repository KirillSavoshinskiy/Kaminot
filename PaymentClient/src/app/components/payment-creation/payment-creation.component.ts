import { Component, OnDestroy } from '@angular/core';
import { Validators, NonNullableFormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Currency } from 'src/app/models/currency';
import { Payment } from 'src/app/models/payment';
import { PaymentSystem } from 'src/app/models/payment-system';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-payment-creation',
  templateUrl: './payment-creation.component.html',
  styleUrls: ['./payment-creation.component.css'],
})
export class PaymentCreationComponent implements OnDestroy {
  public paymentForm = this.fb.group({
    name: ['', [Validators.required]],
    description: ['', [Validators.required]],
    amount: [null, [Validators.required]],
    currency: this.fb.control<number | null>(null, Validators.required),
  });
  public currencies: Currency[] = [];
  private subs = new Subscription();
  private paymentSystemId: number;

  constructor(
    private fb: NonNullableFormBuilder,
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly paymentService: PaymentService
  ) {
    this.paymentSystemId = Number(this.route.snapshot.paramMap.get('id'));

    if (!this.paymentService.pSystems.length) {
      this.subs.add(
        this.paymentService
          .getAllPaymentSystems()
          .subscribe((res: PaymentSystem[]) => {
            this.paymentService.pSystems = res;
            this.currencies =
              this.paymentService.pSystems.find(
                (p) => p.id === this.paymentSystemId
              )?.currencies ?? [];
          })
      );
    } else {
      this.currencies =
        this.paymentService.pSystems.find((p) => p.id === this.paymentSystemId)
          ?.currencies ?? [];
    }
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  public submitForm(): void {
    this.subs.add(
      this.paymentService
        .createPayment({
          paymentSystemId: this.paymentSystemId,
          name: this.paymentForm.get('name')?.value ?? '',
          description: this.paymentForm.get('description')?.value ?? '',
          amount: Number(this.paymentForm.get('amount')?.value) ?? 0,
          currency:
            this.currencies.find(
              (c) => c.id == this.paymentForm.get('currency')?.value
            ) ?? null,
        })
        .subscribe((res: Payment) => {
          this.paymentService.pSystems
            .find((p) => (p.id === this.paymentSystemId))
            ?.payments.push(res); 
          this.router.navigate(['payments-list', this.paymentSystemId]);
        })
    );
  }
}
