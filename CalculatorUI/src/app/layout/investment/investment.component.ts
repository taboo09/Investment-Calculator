import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppService } from '../core/services/app.service';
import { InterestSchedule } from '../shared/models/InterestSchedule';
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
  interestSchedule: InterestSchedule[] = [];
  period: string = '';

  constructor(private fb: FormBuilder,
              private appService: AppService) { }

  ngOnInit(): void {
    this.newInvestment = {
      StartPrincipal: 0,
      PeriodYears: 0,
      InterestRate: 0,
      ContributionValue: 0,
      PeriodInvestment: 1
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
    this.period = Period[investment.PeriodInvestment];
    
    if(investment.PeriodInvestment === Period.Month) {
      this.appService.getRresults('investment', investment)
        .subscribe(results => {
          this.createObjects(results);
        })
    }
    else {
      this.appService.getRresults('interest', investment)
        .subscribe(results => {
          this.createObjects(results);
        })
    }
  }

  private createObjects(results: any){
    this.results.endBalance = results.endBalance;
    this.results.startPrincipal = results.startPrincipal;
    this.results.totalContribution = results.totalContribution;
    this.results.totalInterest = results.totalInterest;
    this.results.totalTax = results.totalTax;
    this.results.inflationAdjustment = results.inflationAdjustment;

    this.interestSchedule = results.interestSchedule;
  }
}
