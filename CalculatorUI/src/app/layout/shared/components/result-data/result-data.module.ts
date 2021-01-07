import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResultDataComponent } from './result-data.component';
import { TableComponent } from './components/table/table.component';
import { LineChartComponent } from './components/line-chart/line-chart.component';
import { HighchartsChartModule } from 'highcharts-angular';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [ResultDataComponent, TableComponent, LineChartComponent],
  imports: [
    CommonModule,
    MatCardModule,
    HighchartsChartModule
  ],
  exports: [ResultDataComponent]
})
export class ResultDataModule { }
