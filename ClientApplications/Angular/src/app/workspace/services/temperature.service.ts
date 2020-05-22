import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TemperatureService {

  constructor(private httpClient:HttpClient) { }

  public GetData(lon:number,lat:number):Observable<any>
  {
    return this.httpClient.get(`${environment.API.URL}/Data`,{
      params: new HttpParams().append('lon',lon.toString()).append('lat',lat.toString())
    });
  }
}
