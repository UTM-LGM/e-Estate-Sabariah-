import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { CostSubcategory2 } from '../_model/costSubcategory2';

@Injectable({
  providedIn: 'root',
})
export class CostSubcategory2Service {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addCostSubCat(subcategory: CostSubcategory2): Observable<CostSubcategory2> {
    return this.http.post<CostSubcategory2>(this.baseUrl + '/costsubcategories2',subcategory);
  }

  getCostSubCat(): Observable<CostSubcategory2[]> {
    return this.http.get<CostSubcategory2[]>(this.baseUrl + '/costsubcategories2');
  }

  updateStatus(id:number):Observable<CostSubcategory2>{
    return this.http.put<CostSubcategory2>(this.baseUrl + '/costsubcategories2/updatestatus', id)
  }
}
