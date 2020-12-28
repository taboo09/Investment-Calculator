import { Component, Input, OnInit } from '@angular/core';

const yearStart: number = 2021;

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
  period: string = '';

  @Input() version: string | undefined;

  constructor() { }

  ngOnInit(): void {
    this.version = '1.0.0';
  }

  setPeriod(){
    const yearNow = new Date().getFullYear();

    return yearNow > yearStart ? yearStart + ' - ' + yearNow : yearStart;
  }
}
