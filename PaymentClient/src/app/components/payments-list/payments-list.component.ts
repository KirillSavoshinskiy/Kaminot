import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Payment } from 'src/app/models/payment';
import { PaymentSystem } from 'src/app/models/payment-system';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-payments-list',
  templateUrl: './payments-list.component.html',
  styleUrls: ['./payments-list.component.css'],
})
export class PaymentsListComponent implements OnInit, OnDestroy {
  public paymentsStateFilter: string = 'All';
  public initialPayments: Payment[] = [];
  public payments: Payment[] = [];
  private subs = new Subscription();

  constructor(
    private readonly route: ActivatedRoute,
    private readonly paymentService: PaymentService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!this.paymentService.pSystems.length) {
      this.subs.add(
        this.paymentService
          .getAllPaymentSystems()
          .subscribe((res: PaymentSystem[]) => {
            this.paymentService.pSystems = res;
            this.initialPayments =
              this.paymentService.pSystems.find((s) => s.id === id)?.payments ??
              [];
            this.payments = this.initialPayments;
          })
      );
    } else {
      this.initialPayments =
        this.paymentService.pSystems.find((s) => s.id === id)?.payments ?? [];
      this.payments = this.initialPayments;
    }
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  public filterChanged(): void {
    if (this.paymentsStateFilter !== 'All') {
      this.payments = this.initialPayments.filter(
        (p) => p.status === this.paymentsStateFilter
      );
    } else {
      this.payments = this.initialPayments;
    }
  }
}
