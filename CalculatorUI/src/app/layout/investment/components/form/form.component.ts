import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Investment } from '../../models';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {
  investmentForm!: FormGroup;

  @Input() investment!: Investment;
  @Output() formValues = new EventEmitter<Investment>();

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.investmentForm = this.fb.group({
      startPrincipal: [this.investment.StartPrincipal,  [Validators.required, Validators.min(0),  Validators.max(999999999)]],
      periodYears: [this.investment.PeriodYears, [Validators.required, Validators.min(0),  Validators.max(100)]],
      interestRate: [this.investment.InterestRate, [Validators.required, Validators.min(0),  Validators.max(10000)]],
      contribution: [this.investment.ContributionValue, [Validators.required, Validators.min(0),  Validators.max(999999999)]],
      period: this.investment.PeriodInvestment
    });
  }

  getResults(formValues: any){
    this.investment = this.mapToInvestment(formValues);

    this.formValues.emit(this.investment);
  }

  private mapToInvestment(values: any): Investment{
    var investment = new Investment();
    
    investment.StartPrincipal = Math.round(+values.startPrincipal * 100) / 100,
    investment.PeriodYears = parseInt(values.periodYears),
    investment.InterestRate = Math.round(+values.interestRate * 100) / 100,
    investment.ContributionValue = Math.round(+values.contribution * 100) / 100,
    investment.PeriodInvestment = +values.period

    return investment;
  }

}
