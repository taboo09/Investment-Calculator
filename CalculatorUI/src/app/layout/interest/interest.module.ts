import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InterestRoutingModule } from './interest-routing.module';
import { InterestComponent } from './interest.component';
import { FormComponent } from './components/form/form.component';
import { FormMatSharedModule } from '../core/form-mat-shared.module';
import { TitleModule } from '../shared/components/title/title.module';
import { LoadingOverlayModule } from 'src/app/shared/modules/loading-overlay/loading-overlay.module';
import {MatSelectModule} from '@angular/material/select';
import { ResultNumbersModule } from '../shared/components/result-numbers/result-numbers.module';
import { ResultDataModule } from '../shared/components/result-data/result-data.module';


@NgModule({
  declarations: [InterestComponent, FormComponent],
  imports: [
    CommonModule,
    InterestRoutingModule,
    FormMatSharedModule,
    TitleModule,
    LoadingOverlayModule,
    ResultNumbersModule,
    ResultDataModule,
    MatSelectModule
  ]
})
export class InterestModule { }
