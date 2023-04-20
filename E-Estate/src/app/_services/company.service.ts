import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { Company } from '../_model/company';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getCompany(): Observable<Company[]> {
    return this.http.get<Company[]>(this.baseUrl + '/companies');
  }

  getOneCompany(id: number): Observable<Company> {
    return this.http.get<Company>(this.baseUrl + '/companies/' + id);
  }

  updateStatus(id: number, headers: HttpHeaders): Observable<Company> {
    return this.http.put<Company>(this.baseUrl + '/companies/updatestatus', id, { headers });
  }
}
