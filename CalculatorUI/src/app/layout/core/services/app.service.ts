import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  private calcUrl = environment.url + 'calc/';
  private baseUrl = environment.url;

  constructor(private http: HttpClient) { }
  
  getRresults(type: string, payload: any){
    return this.http.post<any>(this.calcUrl + type, payload);
  }

  getAppVersion(){
    return this.http.get<any>(this.baseUrl + 'app/version/');
  }

  upload(file: FormData) {
    return this.http.post<any>(this.baseUrl + 'files', file);  
  }
}
