import { Component, Input, OnInit } from '@angular/core';
@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {

  @Input() title!: string;
  title1 = '';
  title2 = '';

  constructor() { }

  ngOnInit(): void {
    this.splitTitle(this.title);
  }

  splitTitle(title: string){
    var arr = title.split(' ');

    this.title1 = arr[0];

    this.title2 = arr.slice(1).join(' ');
  }

}
