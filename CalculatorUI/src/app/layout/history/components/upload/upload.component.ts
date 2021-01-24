import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FileInfo } from '../../models';

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
  uploadForm!: FormGroup;

  @Output() fileUploaded = new EventEmitter<any>();

  @ViewChild("fileUpload", {static: false}) fileUpload!: ElementRef;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
  }

  createForm(){
    this.uploadForm = this.fb.group({
      filename: [this.file.split('.')[0], [Validators.required, Validators.minLength(5), Validators.maxLength(32)]],
      fileinfo: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(1000)]],
      market: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(32)]],
      period: [0, [Validators.required, Validators.min(0),  Validators.max(300)]]
    });
  }

  fileChange(event: any) {
    let fileList: FileList = event.target.files;

    if (fileList.length > 0 && fileList[0].size > 10){
      this.file = fileList[0].name;

      this.createForm();

      this.upload_error = false;
    } else {
      this.upload_error = true;
      this.file = '';
    }
  }

  uploadFile(formValues: any){
    let fileList: FileList = this.fileUpload.nativeElement.files;

    this.fileUploaded.emit({
        file: fileList[0],
        fileInfo: this.createFileInfo(formValues)
      }
    );
  }

  removeFile(){
    this.uploadForm.reset();
    this.fileUpload.nativeElement.value = '';
    this.file = '';
    this.upload_error = false;
  }

  createFileInfo(formValues: any): FileInfo{
    return {
      Filename: formValues.filename,
      Market: formValues.market,
      Period:  formValues.period,
      Fileinfo: formValues.fileinfo
    }
  }
}
