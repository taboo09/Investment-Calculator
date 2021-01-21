import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';

const ACCEPTED_EXTENSIONS = ['xlsx', 'xls', 'csv', 'json'];

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent implements OnInit {
  file: string = '';
  upload_error: boolean = false;
  exts = { extensions: ACCEPTED_EXTENSIONS };

  @Output() fileUploaded = new EventEmitter<File>();

  @ViewChild("fileUpload", {static: false}) fileUpload!: ElementRef;

  constructor() { }

  ngOnInit(): void {
  }

  fileChange(event: any) {
    let fileList: FileList = event.target.files;

    if (fileList.length > 0 && fileList[0].size > 10){
      this.file = fileList[0].name;

      this.upload_error = false;
    } else {
      this.upload_error = true;
    }
  }

  uploadFile(){
    let fileList: FileList = this.fileUpload.nativeElement.files;

    this.fileUploaded.emit(fileList[0]);
  }

  removeFile(){
    this.fileUpload.nativeElement.value = '';
    this.file = '';
    this.upload_error = false;
  }
}
