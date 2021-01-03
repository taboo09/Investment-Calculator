import { Component, Input, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.scss']
})
export class PieChartComponent implements OnInit {
  Highcharts = Highcharts;
  chartOptions!: {};

  @Input() principal: number = 0;
  @Input() interest: number = 0;

  constructor() { }

  ngOnInit(): void {
    this.createPieChart();
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
          name: 'Principal',
          y: this.principal,
          sliced: true,
          selected: true,
          color: '#001f3f'
        }, 
        {
          name: 'Interest',
          y: this.interest,
          color: '#de6006'
        }
      ] 
    }],
    credits: {
        enabled: false
      }
    };
  }

}
