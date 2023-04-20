import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { Town } from '../_model/town';

@Injectable({
  providedIn: 'root',
})
export class TownService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getTown(): Observable<Town[]> {
    return this.http.get<Town[]>(this.baseUrl + '/towns');
  }

  addTown(town: Town): Observable<Town> {
    return this.http.post<Town>(this.baseUrl + '/towns', town);
  }

  updateStatus(id: number): Observable<Town> {
    return this.http.put<Town>(this.baseUrl + '/towns/updatestatus' , id);
  }
}
