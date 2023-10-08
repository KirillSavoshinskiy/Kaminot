import { Component, OnInit } from '@angular/core';
import { Payment } from 'src/app/models/payment';

@Component({
  selector: 'app-payments-list',
  templateUrl: './payments-list.component.html',
  styleUrls: ['./payments-list.component.css'],
})
export class PaymentsListComponent implements OnInit {
  public paymentsStateFilter: string = 'All';
  public source: Payment[] = [
    {
      id: 1,
      paymentSystemId: 1,
      name: 'Name1',
      description: 'description',
      sum: 100,
      currency: { id: 1, name: 'USD', isCrypto: false },
      status: 'In progress',
    },
    {
      id: 1,
      paymentSystemId: 1,
      name: 'Name2',
      description: 'description',
      sum: 1003,
      currency: { id: 1, name: 'USD', isCrypto: false },
      status: 'Finished',
    },
    {
      id: 1,
      paymentSystemId: 1,
      name: 'Name3',
      description: 'description',
      sum: 100,
      currency: { id: 1, name: 'USD', isCrypto: false },
      status: 'Active',
    },
    {
      id: 1,
      paymentSystemId: 1,
      name: 'Name4',
      description: 'description',
      sum: 100,
      currency: { id: 1, name: 'USD', isCrypto: false },
      status: 'In progress',
    }, 
  ];
  public payments: Payment[] = this.source;

  ngOnInit(): void {}

  public filterChanged(): void {
    if (this.paymentsStateFilter !== 'All') {
      this.payments = this.source.filter(
        (p) => p.status === this.paymentsStateFilter
      );
    } else {
      this.payments = this.source;
    }
  }
}
