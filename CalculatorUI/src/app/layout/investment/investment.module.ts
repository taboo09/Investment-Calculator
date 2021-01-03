import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InvestmentRoutingModule } from './investment-routing.module';
import { InvestmentComponent } from './investment.component';
import { FormMatSharedModule } from '../core/form-mat-shared.module';
import { FormComponent } from './components/form/form.component';
import { ResultNumbersModule } from '../shared/components/result-numbers/result-numbers.module';
import { TitleComponent } from '../shared/components/title/title.component';


@NgModule({
  declarations: [InvestmentComponent, FormComponent, TitleComponent],
  imports: [
    CommonModule,
    InvestmentRoutingModule,
    FormMatSharedModule,
    ResultNumbersModule
  ]
})
export class InvestmentModule { }
