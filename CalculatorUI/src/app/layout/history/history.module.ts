import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HistoryRoutingModule } from './history-routing.module';
import { HistoryComponent } from './history.component';
import { TitleModule } from '../shared/components/title/title.module';
import { LoadingOverlayModule } from 'src/app/shared/modules/loading-overlay/loading-overlay.module';


@NgModule({
  declarations: [HistoryComponent],
  imports: [
    CommonModule,
    HistoryRoutingModule,
    TitleModule,
    LoadingOverlayModule
  ]
})
export class HistoryModule { }
