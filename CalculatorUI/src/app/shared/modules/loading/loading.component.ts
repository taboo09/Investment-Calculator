import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.scss']
})
export class LoadingComponent implements OnInit {

  // small or large
  @Input() size: string = 'small';

  constructor() { }

  ngOnInit(): void {
  }

}
