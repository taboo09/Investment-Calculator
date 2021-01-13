import { Component, OnInit } from '@angular/core';
import { AppService } from '../core/services/app.service';
import { InterestSchedule } from '../shared/models/InterestSchedule';
import { InterestModel, InterestRes } from './models';

@Component({
  selector: 'app-interest',
  templateUrl: './interest.component.html',
  styleUrls: ['./interest.component.scss']
})
export class InterestComponent implements OnInit {
  newInterestModel!: InterestModel;
  loading: boolean = false;
  type: string = 'interest';
  results!: InterestRes;
  interestSchedule: InterestSchedule[] = [];
  period = 'Annually';

  constructor(private appService: AppService) { }

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

  getFormValues(interestModel: InterestModel){
    this.loading = true;

    this.appService.getRresults('interest', interestModel)
      .subscribe(results => {
        this.createObjects(results);

        this.loading = false;
      }, error => {
        this.loading = false;
      })
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