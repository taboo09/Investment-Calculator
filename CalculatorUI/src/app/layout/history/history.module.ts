import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HistoryRoutingModule } from './history-routing.module';
import { HistoryComponent } from './history.component';
import { TitleModule } from '../shared/components/title/title.module';
import { LoadingOverlayModule } from 'src/app/shared/modules/loading-overlay/loading-overlay.module';
import { UploadComponent } from './components/upload/upload.component';
import { FormMatSharedModule } from '../core/form-mat-shared.module';
import { MatTooltipModule } from '@angular/material/tooltip';
import { PopoverModule } from 'ngx-smart-popover';


@NgModule({
  declarations: [HistoryComponent, UploadComponent],
  imports: [
    CommonModule,
    HistoryRoutingModule,
    TitleModule,
    LoadingOverlayModule,
    FormMatSharedModule,
    MatTooltipModule,
    PopoverModule
  ]
})
export class HistoryModule { }
