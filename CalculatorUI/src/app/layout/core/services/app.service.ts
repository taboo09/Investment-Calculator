import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  private url = environment.url + 'calc/';

  constructor(private http: HttpClient) { }
  
  getRresults(type: string, payload: any){
    return this.http.post<any>(this.url + type, payload);
  }
}
