import { Component, Input, OnInit } from '@angular/core';
import { ResponseBase } from '../../models';

@Component({
  selector: 'app-result-numbers',
  templateUrl: './result-numbers.component.html',
  styleUrls: ['./result-numbers.component.scss']
})
export class ResultNumbersComponent implements OnInit {
  
  @Input() type:string = 'investement';
  @Input() results!: ResponseBase;

  constructor() { }

  ngOnInit(): void {
  }

}
