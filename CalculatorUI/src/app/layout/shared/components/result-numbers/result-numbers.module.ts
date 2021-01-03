import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ResultNumbersComponent } from "./result-numbers.component";
import { MatCardModule } from '@angular/material/card';
import { PieChartComponent } from './components/pie-chart/pie-chart.component';
import { HighchartsChartModule } from 'highcharts-angular';

@NgModule({
  declarations: [ResultNumbersComponent, PieChartComponent],
  imports: [
    CommonModule,
    MatCardModule,
    HighchartsChartModule
  ],
  exports: [ResultNumbersComponent]
})
export class ResultNumbersModule { }