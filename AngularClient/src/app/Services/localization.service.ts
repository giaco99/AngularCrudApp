import { Injectable } from '@angular/core';
import { HttpClient } from  '@angular/common/http';
import { ThisReceiver } from '@angular/compiler';
import { environment } from 'src/environments/environment';
import { Person } from '../Models/Person.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocalizationService {

  apiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  //chiamata get all'api che torna tutte le persone dal db
  GetDistinctProvinces(): Observable<string[]>{  
    return this.http.get<string[]>(this.apiUrl + '/api/Localization');
  }

  GetMunicipalitiesFromProvince(province: string): Observable<string[]>{
    return this.http.get<string[]>(this.apiUrl + '/api/Localization/' + province);
  }
}
