import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { FieldClone } from '../_model/fieldClone';

@Injectable({
  providedIn: 'root',
})
export class FieldCloneService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addFieldClone(clone: FieldClone[]):Observable<FieldClone[]>{
    return this.http.post<FieldClone[]>(this.baseUrl + '/fieldclones', clone);
  }
}
