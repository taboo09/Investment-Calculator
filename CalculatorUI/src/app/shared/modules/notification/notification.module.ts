import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotificationComponent } from './notification.component';
import { MessageService } from '../../services/message.service';


@NgModule({
  declarations: [NotificationComponent],
  imports: [
    CommonModule
  ],
  providers: [
    MessageService
  ],
  exports: [
    NotificationComponent
  ]
})
export class NotificationModule { }
