import { Component, OnInit } from '@angular/core';
import { PaymentSystem } from 'src/app/models/payment-system';

@Component({
  selector: 'app-payment-systems-list',
  templateUrl: './payment-systems-list.component.html',
  styleUrls: ['./payment-systems-list.component.css'],
})
export class PaymentSystemsListComponent implements OnInit {
  public currencyTypeFilter: string = 'All';

  public paymentSystemsList: PaymentSystem[] = [];

  public source: PaymentSystem[] = [
    {
      id: 1,
      name: 'PayPal',
      description: 'description',
      currency: [
        { id: 1, name: 'BYN', isCrypto: false },
        { id: 1, name: 'BYN', isCrypto: false },
      ],
    },
    {
      id: 1,
      name: 'Crypto',
      description: 'description',
      currency: [
        { id: 1, name: 'USDT', isCrypto: true },
        { id: 1, name: 'EHT', isCrypto: true },
      ],
    },
  ];

  ngOnInit(): void {
    this.paymentSystemsList = this.source;
  }

  public filterChanged(): void {
    if (this.currencyTypeFilter === 'Not Crypto') {
      this.paymentSystemsList = this.source.filter((p) =>
        p.currency.filter((c) => !c.isCrypto).length
      );
    } else if (this.currencyTypeFilter === 'Crypto') {
      this.paymentSystemsList = this.source.filter((p) =>
        p.currency.filter((c) => c.isCrypto).length
      );
    } else {
      this.paymentSystemsList = this.source;
    }
  }
}
