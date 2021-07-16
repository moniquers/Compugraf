import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private _httpClient: HttpClient) { }

  private _url = `${environment.apiUrl}/Person`

  getAllPerson() {
    return this._httpClient.get<Person[]>(`${this._url}`);
  }

  getPersonById(id: number) {
    return this._httpClient.get<Person>(`${this._url}/${id}`);
  }

  createPerson(personForm: Person): Observable<any> {
    return this._httpClient.post(`${this._url}`, personForm);
  }

  updatePerson(personForm: Person): Observable<any> {
    return this._httpClient.put(`${this._url}/${personForm.id}`, personForm);
  }

  deletePerson(id: number): Observable<any> {
    return this._httpClient.delete(`${this._url}/${id}`);
  }

  getAddressByZipCode(zipCode: any){
    return this._httpClient.get<any>(`https://viacep.com.br/ws/${zipCode}/json/`);
  }
}
