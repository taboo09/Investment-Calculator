import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit, OnChanges {
  dataSource!: MatTableDataSource<any>;

  @Input() type: string = '';
  @Input() data:any[] = [];

  @Input() isMonthly: boolean = false;

  displayedColumns: string[] = ['index', 'startPrincipal', 'startBalance', 'interest', 'endBalance', 'endPrincipal'];

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
    this.createColumns();

    this.dataSource = new MatTableDataSource(this.data);
  }

  ngOnInit(): void {
    
  }

  createColumns(){
    switch (this.type) {
      case 'investment':
        break;
      
      case 'interest':
        if (this.displayedColumns[this.displayedColumns.length - 1] !== 'tax')
          this.displayedColumns.push('tax');
        break;

      default:
        break;
    }
  }

  isItMonthly(x: number){
    return this.isMonthly && x % 12 === 0;
  }

}
