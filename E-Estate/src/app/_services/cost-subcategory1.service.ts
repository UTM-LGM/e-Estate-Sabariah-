import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { CostSubcategory1 } from '../_model/costSubcategory1';

@Injectable({
  providedIn: 'root',
})
export class CostSubcategory1Service {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addCostSubCat(subcategory: CostSubcategory1): Observable<CostSubcategory1> {
    return this.http.post<CostSubcategory1>(this.baseUrl + '/costsubcategories1',subcategory);
  }

  getCostSubCat(): Observable<CostSubcategory1[]> {
    return this.http.get<CostSubcategory1[]>(this.baseUrl + '/costsubcategories1');
  }

  updateStatus(id:number):Observable<CostSubcategory1>{
    return this.http.put<CostSubcategory1>(this.baseUrl + '/costsubcategories1/updatestatus', id)
  }
}
