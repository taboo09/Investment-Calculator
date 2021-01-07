import { Component, Input, OnInit } from '@angular/core';
import { InterestSchedule } from '../../models/InterestSchedule';

@Component({
  selector: 'app-result-data',
  templateUrl: './result-data.component.html',
  styleUrls: ['./result-data.component.scss']
})
export class ResultDataComponent implements OnInit {

  @Input() dataList: InterestSchedule[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
