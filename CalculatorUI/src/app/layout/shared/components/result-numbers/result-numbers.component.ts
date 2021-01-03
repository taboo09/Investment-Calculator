import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-result-numbers',
  templateUrl: './result-numbers.component.html',
  styleUrls: ['./result-numbers.component.scss']
})
export class ResultNumbersComponent implements OnInit {
  
  @Input() type:string = 'investement';
  @Input() results: any = undefined;

  constructor() { }

  ngOnInit(): void {
  
  }

}
