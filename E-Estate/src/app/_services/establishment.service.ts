import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { Establishment } from '../_model/establishment';

@Injectable({
  providedIn: 'root',
})
export class EstablishmentService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getEstablishment(): Observable<Establishment[]> {
    return this.http.get<Establishment[]>(this.baseUrl + '/establishments');
  }

  addEstablishment(establishment: Establishment): Observable<Establishment> {
    return this.http.post<Establishment>(this.baseUrl + '/establishments',establishment);
  }

  updateStatus(id: number): Observable<Establishment> {
    return this.http.put<Establishment>(this.baseUrl + '/establishments/updatestatus' , id);
  }
}
