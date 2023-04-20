import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { CostCategory } from '../_model/costCategory';

@Injectable({
  providedIn: 'root',
})
export class CostCategoryService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addCostCat(category: CostCategory): Observable<CostCategory> {
    return this.http.post<CostCategory>(this.baseUrl + '/costcategories',category);
  }

  getCostCat(): Observable<CostCategory[]> {
    return this.http.get<CostCategory[]>(this.baseUrl + '/costcategories');
  }

  updateStatus(id:number):Observable<CostCategory>{
    return this.http.put<CostCategory>(this.baseUrl + '/costcategories/updatestatus', id)
  }
}
