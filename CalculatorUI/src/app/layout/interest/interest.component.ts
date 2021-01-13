import { Component, OnInit } from '@angular/core';
import { InterestModel } from './models';

@Component({
  selector: 'app-interest',
  templateUrl: './interest.component.html',
  styleUrls: ['./interest.component.scss']
})
export class InterestComponent implements OnInit {
  newInterestModel!: InterestModel;
  loading: boolean = false;

  constructor() { }

  ngOnInit(): void {
    this.newInterestModel = {
      StartPrincipal: 0,
      PeriodYears: 0,
      InterestRate: 0,
      ContributionValue: 0,
      InterestPeriod: 1,
      CompoundPeriod: 0,
      InflationRate: 0,
      TaxRate: 0
    }
  }

  getFormValues(interestModel: InterestModel){
    console.log(interestModel)
  }

}