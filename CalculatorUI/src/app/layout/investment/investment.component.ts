import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppService } from '../core/services/app.service';
import { Investment, InvestmentRes, Period } from './models';

@Component({
  selector: 'app-investment',
  templateUrl: './investment.component.html',
  styleUrls: ['./investment.component.scss']
})
export class InvestmentComponent implements OnInit {
  type: string = 'investment';
  // change to any for a reuseable component
  newInvestment!: Investment;
  results!: InvestmentRes;

  constructor(private fb: FormBuilder,
              private appService: AppService) { }

  ngOnInit(): void {
    this.newInvestment = {
      StartPrincipal: 0,
      PeriodYears: 0,
      InterestRate: 0,
      ContributionValue: 0,
      PeriodInvestment: 0
    };

    this.results = {
      endBalance: 0,
      startPrincipal: 0,
      totalContribution: 0,
      totalInterest: 0,
      totalTax: 0,
      inflationAdjustment: 0,
      interestSchedule: []
    }
  }

  getFormValues(investment: Investment){

    if(investment.PeriodInvestment === Period.Month) {
      this.appService.getRresults('investment', investment)
        .subscribe(results => {

          this.results = results;
        })
    }
    else {
      this.appService.getRresults('interest', investment)
        .subscribe(results => {

          this.results = results;
        })
    }
  }
}
