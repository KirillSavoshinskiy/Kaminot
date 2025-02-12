import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentSystemsListComponent } from './payment-systems-list.component';

describe('PaymentSystemsListComponent', () => {
  let component: PaymentSystemsListComponent;
  let fixture: ComponentFixture<PaymentSystemsListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PaymentSystemsListComponent]
    });
    fixture = TestBed.createComponent(PaymentSystemsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
