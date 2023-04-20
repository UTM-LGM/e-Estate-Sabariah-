import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { Estate } from '../_model/estate';

@Injectable({
  providedIn: 'root',
})
export class EstateService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getEstate(): Observable<Estate[]> {
    return this.http.get<Estate[]>(this.baseUrl + '/estates');
  }

  getOneEstate(id: number): Observable<Estate> {
    return this.http.get<Estate>(this.baseUrl + '/estates/' + id);
  }

  addEstate(estate: Estate): Observable<Estate> {
    return this.http.post<Estate>(this.baseUrl + '/estates', estate);
  }

  updateStatus(id: number): Observable<Estate> {
    return this.http.put<Estate>(this.baseUrl + '/estates/updatestatus', id);
  }
}
