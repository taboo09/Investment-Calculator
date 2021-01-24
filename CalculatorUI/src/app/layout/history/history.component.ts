import { Component, OnInit, ViewChild } from '@angular/core';
import { NotificationType } from 'src/app/shared/models';
import { MessageService } from 'src/app/shared/services/message.service';
import { AppService } from '../core/services/app.service';
import { UploadComponent } from './components/upload/upload.component';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {
  loading: boolean = false;

  @ViewChild('upload', {static: false}) upload!: UploadComponent;

  constructor(private appService: AppService,
    private messageService: MessageService) { }

  ngOnInit(): void {
  }

  fileUploaded(file: any){
    this.loading = true;

    let formData:FormData = new FormData();
    formData.append('file', file.file);
    formData.append('info', JSON.stringify(file.fileInfo));

    this.appService.upload(formData)
      .subscribe(res => {

        this.upload.removeFile();

        // display notification
        let messageInfo = {
          MessageInfo: res.message,
          Notification: NotificationType.Message
        };

        this.messageService.displayMessage(messageInfo);

        this.loading = false;

      }, err => {
        console.log(err);
        this.loading = false;
      })
  }

}
