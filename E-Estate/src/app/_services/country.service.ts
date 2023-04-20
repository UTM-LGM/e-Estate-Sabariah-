import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { Country } from '../_model/country';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addCountry(country: Country): Observable<Country> {
    return this.http.post<Country>(this.baseUrl + '/countries', country);
  }

  getCountry(): Observable<Country[]> {
    return this.http.get<Country[]>(this.baseUrl + '/countries');
  }

  updateStatus(id:number):Observable<Country>{
    return this.http.put<Country>(this.baseUrl + '/countries/updatestatus', id);
  }
}
