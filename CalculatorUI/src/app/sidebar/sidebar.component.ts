import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import menu from '../core/data/menu-list';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  menu: any;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.menu = menu;
  }
  
}
