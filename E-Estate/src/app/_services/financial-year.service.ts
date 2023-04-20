import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { FinancialYear } from '../_model/financialYear';

@Injectable({
  providedIn: 'root',
})
export class FinancialYearService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAllFinancialYear(): Observable<FinancialYear[]> {
    return this.http.get<FinancialYear[]>(this.baseUrl + '/financialyears');
  }

  addFinancialYear(financialYear: FinancialYear): Observable<FinancialYear> {
    return this.http.post<FinancialYear>(this.baseUrl + '/financialyears',financialYear);
  }

  updateStatus(id: number): Observable<FinancialYear> {
    return this.http.put<FinancialYear>(this.baseUrl + '/financialyears/updatestatus' , id);
  }
}
