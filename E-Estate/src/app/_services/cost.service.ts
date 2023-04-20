import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { Cost } from '../_model/cost';

@Injectable({
  providedIn: 'root',
})
export class CostService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addCostItem(cost: Cost): Observable<Cost> {
    return this.http.post<Cost>(this.baseUrl + '/costs', cost);
  }

  getCostItem(): Observable<Cost[]> {
    return this.http.get<Cost[]>(this.baseUrl + '/costs');
  }

  getDirectMatureCostCategory(): Observable<Cost[]> {
    return this.http.get<Cost[]>(this.baseUrl + '/costs/getcostcategoryM');
  }

  getDirectMatureSubCategory1(): Observable<Cost[]> {
    return this.http.get<Cost[]>(this.baseUrl + '/costs/getcostsubcategory1M');
  }

  getDirectMatureSubCategory2(): Observable<Cost[]> {
    return this.http.get<Cost[]>(this.baseUrl + '/costs/getcostsubcategory2M');
  }

  getDirectMatureSubCategory2IM(): Observable<Cost[]> {
    return this.http.get<Cost[]>(this.baseUrl + '/costs/getcostsubcategory2IM');
  }

  getIndirectCost(): Observable<Cost[]> {
    return this.http.get<Cost[]>(this.baseUrl + '/costs/getcostindirect');
  }

  updateStatus(id:number):Observable<Cost>{
    return this.http.put<Cost>(this.baseUrl + '/costs/updatestatus', id)
  }
}
