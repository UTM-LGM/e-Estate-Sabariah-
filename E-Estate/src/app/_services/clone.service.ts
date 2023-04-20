import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { Clone } from '../_model/clone';

@Injectable({
  providedIn: 'root',
})
export class CloneService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getClone(): Observable<Clone[]> {
    return this.http.get<Clone[]>(this.baseUrl + '/clones');
  }

  addClone(clone: Clone): Observable<Clone> {
    return this.http.post<Clone>(this.baseUrl + '/clones', clone);
  }
  
  updateStatus(id: number): Observable<Clone> {
    return this.http.put<Clone>(this.baseUrl + '/clones/updatestatus' , id);
  }
}
