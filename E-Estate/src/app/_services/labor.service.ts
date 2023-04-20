import { ObserversModule } from '@angular/cdk/observers';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { Labor } from '../_model/labor';

@Injectable({
  providedIn: 'root',
})
export class LaborService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addLabor(labor: Labor): Observable<Labor> {
    return this.http.post<Labor>(this.baseUrl + '/labors', labor);
  }

  getLabor(): Observable<Labor[]> {
    return this.http.get<Labor[]>(this.baseUrl + '/labors');
  }

  deleteLabor(id: number): Observable<Labor> {
    return this.http.delete<Labor>(this.baseUrl + '/labors/' + id);
  }
}
