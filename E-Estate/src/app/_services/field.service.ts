import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { Field } from '../_model/field';
import { FieldClone } from '../_model/fieldClone';

@Injectable({
  providedIn: 'root',
})
export class FieldService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addField(field: Field): Observable<Field> {
    return this.http.post<Field>(this.baseUrl + '/fields', field);
  }

  getField(): Observable<Field[]> {
    return this.http.get<Field[]>(this.baseUrl + '/fields');
  }

  getOneField(id: number): Observable<Field> {
    return this.http.get<Field>(this.baseUrl + '/fields/' + id);
  }

  updateField(field: Field): Observable<Field> {
    return this.http.put<Field>(this.baseUrl + '/fields/' + field.id, field);
  }

  addClone(clone:FieldClone):Observable<FieldClone>{
    return this.http.post<FieldClone>(this.baseUrl + '/fields/addclone', clone)
  }

  deleteClone(cloneId:number,fieldId:number):Observable<FieldClone>{
    return this.http.delete<FieldClone>(this.baseUrl + '/fields/deleteclone/' + cloneId + '/' + fieldId)
  }

  updateStatus(id: number): Observable<Field> {
    return this.http.put<Field>(this.baseUrl + '/fields/updatestatus', id);
  }
}
