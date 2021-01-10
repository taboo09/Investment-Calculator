import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingOverlayComponent } from './loading-overlay.component';
import { LoadingModule } from '../loading/loading.module';



@NgModule({
  declarations: [LoadingOverlayComponent],
  imports: [
    CommonModule,
    LoadingModule
  ],
  exports: [
    LoadingOverlayComponent
  ]
})
export class LoadingOverlayModule { }
