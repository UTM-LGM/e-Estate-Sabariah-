import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { State } from '../_model/state';

@Injectable({
  providedIn: 'root',
})
export class StateService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getState(): Observable<State[]> {
    return this.http.get<State[]>(this.baseUrl + '/states');
  }

  addState(state: State): Observable<State> {
    return this.http.post<State>(this.baseUrl + '/states', state);
  }

  updateStatus(id:number):Observable<State>{
    return this.http.put<State>(this.baseUrl + '/states/updatestatus' , id);
  }
}
