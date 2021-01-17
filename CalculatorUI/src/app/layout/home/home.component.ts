import { Component, HostListener, OnInit } from '@angular/core';
import menu_list from 'src/app/core/data/menu-list';

const title = 'investment calculator';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  menu: any;
  font_size:number = 200;
  title_arr: any = [];
  selected_title = '';
  selected_desc = '';

  @HostListener('window:resize', ['$event'])
  getScreenSize() {
    let scrWidth = window.innerWidth;
    
    this.calculateFontSize(scrWidth);
  }

  constructor() { }

  ngOnInit(): void {
    this.menu = menu_list.filter(x => x.link !== 'home');

    this.setTitle(title);

    this.selectItem(1);
  }

  calculateFontSize(screenWidth: number){
    
    if (screenWidth >= 1200) this.font_size = 300;
    else if (screenWidth <= 600) this.font_size = 200; 
    else {
      let p = (screenWidth - 600) / 6;

      this.font_size = 200 + p;
    }

  }

  setTitle(title: string){
    for (let i = 0; i < title.length; i++) {
      this.title_arr.push({ char: title[i], font: 1 });
    }

    this.title_arr[0].font = 1.05;
    this.title_arr[1].font = 1.5;
    this.title_arr[2].font = 1.95;
    this.title_arr[11].font = 1.95;
    this.title_arr[12].font = 1.5;
    this.title_arr[13].font = 1.05;

    this.title_arr = this.title_arr.map((x: { font: number; char: string; }) => {
      if(x.font > 1) {
        return {
          char: x.char.toUpperCase(),
          font: x.font
        };
      }
      return x;
    });
  }

  selectItem(i: number){
    this.selected_title = this.menu.find((x: { index: number; }) => x.index === i).title;
    this.selected_desc = this.menu.find((x: { index: number; }) => x.index === i).description;
  }

}
