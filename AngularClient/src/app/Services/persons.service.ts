import { Injectable } from '@angular/core';
import { HttpClient } from  '@angular/common/http';
import { ThisReceiver } from '@angular/compiler';
import { environment } from 'src/environments/environment';
import { Person } from '../Models/Person.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonsService {

  apiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  //chiamata get all'api che torna tutte le persone dal db
  GetAllPersons(): Observable<Person[]>{  
    return this.http.get<Person[]>(this.apiUrl + '/api/Person');
  }

  AddPerson(addPerson: Person):Observable<Person>{
    //il guid verrà settato dalla web api come il codice fiscale
    addPerson.id= '00000000-0000-0000-0000-000000000000';
    return this.http.post<Person>(this.apiUrl + '/api/Person',addPerson);
  }

  GetPersonById(id: string): Observable<Person>{
    return this.http.get<Person>(this.apiUrl + '/api/Person/' + id);
  }

  UpdatePerson(id: string,updatedPerson: Person): Observable<Person>
  {
    return this.http.put<Person>(this.apiUrl + '/api/Person/' + id,updatedPerson);
  }

  DeletePersonById(id: string): Observable<Person>
  {
    return this.http.delete<Person>(this.apiUrl + '/api/Person/' + id);
  }
}
