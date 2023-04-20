import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { FieldProduction } from '../_model/fieldProduction';

@Injectable({
  providedIn: 'root',
})
export class FieldProductionService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addProduction(production: FieldProduction[]):Observable<FieldProduction[]> {
    return this.http.post<FieldProduction[]>(this.baseUrl + '/fieldproductions', production);
  }

  getAllProduction():Observable<FieldProduction[]>{
    return this.http.get<FieldProduction[]>(this.baseUrl + '/fieldproductions');
  }

  updateProduction(production:FieldProduction):Observable<FieldProduction>{
    return this.http.put<FieldProduction>(this.baseUrl + '/fieldproductions/updatestatus', production)
  }
}
