import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { CropCategory } from '../_model/cropCategory';

@Injectable({
  providedIn: 'root',
})
export class CropCategoryService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getCrop(): Observable<CropCategory[]> {
    return this.http.get<CropCategory[]>(this.baseUrl + '/cropcategories');
  }

  addCrop(crop: CropCategory): Observable<CropCategory> {
    return this.http.post<CropCategory>(this.baseUrl + '/cropcategories', crop);
  }

  updateStatus(id: number): Observable<CropCategory> {
    return this.http.put<CropCategory>(this.baseUrl + '/cropcategories/updatestatus' , id);
  }
}
