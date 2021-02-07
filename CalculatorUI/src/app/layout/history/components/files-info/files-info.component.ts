import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-files-info',
  templateUrl: './files-info.component.html',
  styleUrls: ['./files-info.component.scss']
})
export class FilesInfoComponent implements OnInit, OnChanges {
  dataSource!: MatTableDataSource<any>;

  pageNumber: number = 0;

  @Input() data:any[] = [];
  @Input() prev!:boolean;
  @Input() next!:boolean;
  @Output() page = new EventEmitter<number>();
  @Output() fileId = new EventEmitter<number>();

  displayedColumns: string[] = ['index', 'fileName', 'market', 'years', 'createdAt', 'fileInfo'];

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
    this.dataSource = new MatTableDataSource(this.data);
  }

  ngOnInit(): void {
  }

  changePage(x: number){
    this.pageNumber += x * 5;

    this.page.emit(x);
  }

  pickFile(id: number){
    this.fileId.emit(id);
  }
}
