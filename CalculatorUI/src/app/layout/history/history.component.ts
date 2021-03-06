import { Component, OnInit, ViewChild } from '@angular/core';
import { NotificationType } from 'src/app/shared/models';
import { MessageService } from 'src/app/shared/services/message.service';
import { AppService } from '../core/services/app.service';
import { UploadComponent } from './components/upload/upload.component';
import { FileDb } from './models';

const SIZE = 5;

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {
  loading: boolean = false;
  files: FileDb[] = [];
  start = 0;
  prev:boolean = false;
  next:boolean = true;

  @ViewChild('upload', {static: false}) upload!: UploadComponent;

  constructor(private appService: AppService,
    private messageService: MessageService) { }

  ngOnInit(): void {
    this.getFiles(0);
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

  getFiles(start: number){
    this.loading = true;

    this.appService.getFiles(SIZE, start)
      .subscribe(files => {

        this.files = files.length > 0 ? files : this.files;

        // set next
        this.next = files.length < 5 ? false : true;

        this.loading = false;        
      }, error => {
        this.loading = false;
      })
  }

  setPage(x: number){
    if (x === -1 && this.start > 0){
      this.start = this.start - 5;
      this.prev = this.start === 0 ? false : true;
      this.getFiles(this.start);
    } 
    if (x === 1){
      this.start = this.start + 5;
      this.prev = true;
      this.getFiles(this.start);
    }
  }

  fileData(fileId: number){
    console.log(fileId)
  }

}
