import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import * as Highcharts from 'highcharts';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.scss']
})
export class LineChartComponent implements OnInit, OnChanges {
  Highcharts = Highcharts;
  chartOptions!: {};
  
  totalInterest: number[] = [];
  balance: number[] = [];
  principal: number[] = [];
  xIndexes: number[] = [];

  plotWidth: number = 0;

  @Input() data:any[] = [];

  constructor() { }

  ngOnInit(): void {
    this.createArrays();
    // this.setPlotWidth();
    this.createPieChart();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.createArrays();
    // this.setPlotWidth();
    this.createPieChart();    
  }

  createArrays(){
    this.balance = this.data.map(x => x.endBalance);
    this.principal = this.data.map(x => x.endPrincipal);
    this.totalInterest = this.data.map(x => x.totalInterest);

    this.xIndexes = Array.from(Array(this.data.length), (_,x) => x + 1);
  }

  // setPlotWidth() {
  //   var x = this.data.length;
  //   this.plotWidth = x <= 8 ? 700 : x <= 10 ? 900 : x;
  // }

  createPieChart() {
    this.chartOptions = {

    chart: {
      type: 'line',
      scrollablePlotArea: {
        minWidth: 700
      }
    },

    title: {
      style: {"display": "none"},
    },

    xAxis: {
      tickInterval: 1,
      tickWidth: 0,
      gridLineWidth: 1,
      categories: this.xIndexes,
      labels: {
        format: '{value:.,0f}yr'
      }
    },

    yAxis: [
    {
      title: {
        text: null
      },
      labels: {
        style: {"display": "none"},
        align: 'left',
        x: 3,
        y: 16,
        format: '{value}'
      },
      showFirstLabel: false
    }, 
    { // right y axis
      linkedTo: 0,
      gridLineWidth: 0,
      opposite: true,
      title: {
        text: null
      },
      labels: {
        align: 'right',
        x: -3,
        y: 16,
        format: '{value}'
      },
      showFirstLabel: false
    }
  ],

    legend: {
      align: 'left',
      verticalAlign: 'top',
      borderWidth: 0
    },

    tooltip: {
      shared: true,
      crosshairs: true
    },

    plotOptions: {
      series: {
        cursor: 'pointer',
        pointPlacement: 'off', // xAxis offset
        marker: {
          lineWidth: 1
        }
      }
    },

    series: [
      {
        name: 'Balance',
        lineWidth: 2,
        marker: {
          radius: 3
        },
        data: this.balance
      }, 
      {
        name: 'Principal',
        lineWidth: 2,
        marker: {
          radius: 3
        },
        data: this.principal
      }, 
      {
        name: 'Interest',
        lineWidth: 2,
        marker: {
          radius: 3
        },
        data: this.totalInterest
      }
    ]
    }
  }

}


// Xoverflow