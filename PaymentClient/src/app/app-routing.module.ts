import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'; 
import { PaymentCreationComponent } from './components/payment-creation/payment-creation.component';
import { PaymentsListComponent } from './components/payments-list/payments-list.component';
import { PaymentSystemsListComponent } from './components/payment-systems-list/payment-systems-list.component';

const routes: Routes = [
  { path: '', component: PaymentSystemsListComponent },
  { path: 'creation/:id', component: PaymentCreationComponent },
  { path: 'payments-list/:id', component: PaymentsListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
