import { Component, Input, OnInit } from '@angular/core';
import { AppService } from '../layout/core/services/app.service';

const yearStart: number = 2021;

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
  period: string = '';
  version = '';

  constructor(private appService: AppService) { }

  ngOnInit(): void {
    this.getAppVersion();
  }

  setPeriod(){
    const yearNow = new Date().getFullYear();

    return yearNow > yearStart ? yearStart + ' - ' + yearNow : yearStart;
  }

  getAppVersion(){
    this.appService.getAppVersion()
      .subscribe(version => {
        this.version = version.appVersion;
      })
  }
}
