import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { PaymentSystem } from 'src/app/models/payment-system';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-payment-systems-list',
  templateUrl: './payment-systems-list.component.html',
  styleUrls: ['./payment-systems-list.component.css'],
})
export class PaymentSystemsListComponent implements OnInit, OnDestroy {
  public currencyTypeFilter: string = 'All';
  public paymentSystemsList: PaymentSystem[] = [];

  private subs = new Subscription();

  constructor(private readonly paymentService: PaymentService) {}

  ngOnInit(): void {
    this.subs.add(
      this.paymentService
        .getAllPaymentSystems()
        .subscribe((res: PaymentSystem[]) => {
          this.paymentSystemsList = res;
          this.paymentService.pSystems = res;
        })
    );
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  public filterChanged(): void {
    if (this.currencyTypeFilter === 'Not Crypto') {
      this.paymentSystemsList = this.paymentService.pSystems.filter(
        (p) => !p.currencies.filter((c) => c.isCrypto).length
      );
      console.log(this.paymentSystemsList);
    } else if (this.currencyTypeFilter === 'Crypto') {
      this.paymentSystemsList = this.paymentService.pSystems.filter(
        (p) => p.currencies.filter((c) => c.isCrypto).length
      );
    } else {
      this.paymentSystemsList = this.paymentService.pSystems;
    }
  }
}
