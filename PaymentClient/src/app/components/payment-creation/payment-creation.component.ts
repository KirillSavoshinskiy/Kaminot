import { Component } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  NonNullableFormBuilder,
} from '@angular/forms';

@Component({
  selector: 'app-payment-creation',
  templateUrl: './payment-creation.component.html',
  styleUrls: ['./payment-creation.component.css'],
})
export class PaymentCreationComponent {
  public paymentForm = this.fb.group({
    paymentName: ['', [Validators.required]],
    description: ['', [Validators.required]],
    sum: ['', [Validators.required]],
    currency: this.fb.control<string | null>(null, Validators.required),
    state: this.fb.control<string | null>(null, Validators.required),
  });

  constructor(private fb: NonNullableFormBuilder) {}

  submitForm(): void {
    console.log('submit', this.paymentForm.value);
  }
}
