import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import * as Highcharts from 'highcharts';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.scss']
})
export class PieChartComponent implements OnInit, OnChanges{
  Highcharts = Highcharts;
  chartOptions!: {};

  @Input() name1!: string;
  @Input() value1: number = 0;
  @Input() color1!: string;
  @Input() name2!: string;
  @Input() value2: number = 0;
  @Input() color2!: string;

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
    this.createPieChart();
  }

  ngOnInit(): void {
  }

  createPieChart(){
    this.chartOptions = {
      chart: {
        plotBackgroundColor: null,
        plotBorderWidth: null,
        plotShadow: false,
        type: 'pie',
        height: 180
      },
    title: {
        style: {"display": "none"},
        text: 'Breakdown'
      },
    tooltip: {
        pointFormat: '{series.name}: <b>{point.y}</b> <br> Percentage: <b>{point.percentage:.1f}%</b>'
      },
    dataLabels: {
        align: 'right'
      },
    plotOptions: {
        pie: {
          allowPointSelect: true,
          cursor: 'pointer',
          dataLabels: {
            enabled: true,
            format: '<b>{point.name}</b>: {point.percentage:.1f}%',
            distance: 10,
            style: {
              fontSize: '10px'
            }
          }
        }
      },
    series: [{
      name: 'Total',
      colorByPoint: true,
      data: [
        {
          name: this.name1,
          y: this.value1,
          sliced: true,
          selected: true,
          color: this.color1
        }, 
        {
          name: this.name2,
          y: this.value2,
          color: this.color2
        }
      ] 
    }],
    credits: {
        enabled: false
      }
    };
  }

}
