import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { InterestSchedule } from '../../models/InterestSchedule';

@Component({
  selector: 'app-result-data',
  templateUrl: './result-data.component.html',
  styleUrls: ['./result-data.component.scss']
})
export class ResultDataComponent implements OnInit, OnChanges {

  @Input() dataList: InterestSchedule[] = [];
  @Input() period: string = '';

  chartData: InterestSchedule[] = [];

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
    this.createChartData();
  }

  ngOnInit(): void {
    
  }

  createChartData(){
    // reset array
    this.chartData = [];

    if (this.period.toUpperCase() === 'MONTH'){
      for (let i = 1; i <= this.dataList.length; i++) {
        if (i % 12 === 0){
          this.chartData.push(this.dataList[i - 1]);
        }
      }
    }
    else {
      this.chartData = this.dataList;
    }
  }
}
