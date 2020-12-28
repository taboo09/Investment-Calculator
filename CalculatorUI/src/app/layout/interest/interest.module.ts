import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InterestRoutingModule } from './interest-routing.module';
import { InterestComponent } from './interest.component';


@NgModule({
  declarations: [InterestComponent],
  imports: [
    CommonModule,
    InterestRoutingModule
  ]
})
export class InterestModule { }
