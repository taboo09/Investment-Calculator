import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-files-info',
  templateUrl: './files-info.component.html',
  styleUrls: ['./files-info.component.scss']
})
export class FilesInfoComponent implements OnInit, OnChanges {
  dataSource!: MatTableDataSource<any>;

  @Input() data:any[] = [];

  displayedColumns: string[] = ['index', 'fileName', 'market', 'years', 'createdAt', 'fileInfo'];

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
    this.dataSource = new MatTableDataSource(this.data);

    console.log(this.data)
  }

  ngOnInit(): void {
    console.log()
  }

}
