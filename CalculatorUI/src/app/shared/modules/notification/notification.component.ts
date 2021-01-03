import { Component, OnInit } from '@angular/core';
import { Message, NotificationType } from '../../models';
import { MessageService } from '../../services/message.service';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit {

  message!: Message;
  type = 'danger';

  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
    this.getMessage();
  }

  getMessage(){
    this.messageService.MessageObs
      .subscribe(message => {
        this.message = message;

        if (this.message)
          this.type = this.message.Notification === NotificationType.Error ? 'danger' : 'warning'; 
        
      });
  }

  resetMessage(){
    this.messageService.displayMessage(undefined as unknown as Message)
  }

  displayNotificationType(type: number){
    return NotificationType[type];
  }
}
