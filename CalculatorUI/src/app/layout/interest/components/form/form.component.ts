import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompoundPeriod, InterestModel } from '../../models';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {
  interestForm!: FormGroup;
  compoundPeriodList: any[] = [];

  @Input() interestModel!: InterestModel;
  @Output() formValues = new EventEmitter<InterestModel>();

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.createForm();

    this.enumToList();
  }

  createForm(){
    this.interestForm = this.fb.group({
      startPrincipal: [this.interestModel.StartPrincipal,  [Validators.required, Validators.min(0),  Validators.max(999999999)]],
      periodYears: [this.interestModel.PeriodYears, [Validators.required, Validators.min(0),  Validators.max(100)]],
      interestRate: [this.interestModel.InterestRate, [Validators.required, Validators.min(0),  Validators.max(10000)]],
      contribution: [this.interestModel.ContributionValue, [Validators.required, Validators.min(0),  Validators.max(999999999)]],
      interestPeriod: this.interestModel.InterestPeriod,
      compoundPeriod: this.interestModel.CompoundPeriod,
      inflationRate: [this.interestModel.InflationRate, [Validators.required, Validators.min(0),  Validators.max(999999999)]],
      taxRate: [this.interestModel.TaxRate, [Validators.required, Validators.min(0),  Validators.max(100)]]
    });
  }

  getResults(formValues: any){
    this.interestModel = this.mapToInterestModel(formValues);

    this.formValues.emit(this.interestModel);
  }

  enumToList(){
    let compoundPeriods = CompoundPeriod;

    this.compoundPeriodList = Object.keys(compoundPeriods)
      .filter(f => !isNaN(Number(f)))
      .map(key => ({ title: CompoundPeriod[Number(key)], value: Number(key) }));
  }

  private mapToInterestModel(values: any): InterestModel{
    var interestModel = new InterestModel();
    
    interestModel.StartPrincipal = Math.round(+values.startPrincipal * 100) / 100;
    interestModel.PeriodYears = parseInt(values.periodYears);
    interestModel.InterestRate = Math.round(+values.interestRate * 100) / 100;
    interestModel.ContributionValue = Math.round(+values.contribution * 100) / 100;
    interestModel.InterestPeriod = +values.interestPeriod;
    interestModel.CompoundPeriod = +values.compoundPeriod;
    interestModel.InflationRate = Math.round(+values.inflationRate * 100) / 100;
    interestModel.TaxRate = Math.round(+values.taxRate * 100) / 100;

    return interestModel;
  }

}
