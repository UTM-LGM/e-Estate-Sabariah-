import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { MembershipType } from '../_model/membership';

@Injectable({
  providedIn: 'root',
})
export class MembershipService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAllMembership(): Observable<MembershipType[]> {
    return this.http.get<MembershipType[]>(this.baseUrl + '/memberships');
  }

  addMembership(membership: MembershipType): Observable<MembershipType> {
    return this.http.post<MembershipType>(this.baseUrl + '/memberships',membership);
  }

  updateStatus(id: number): Observable<MembershipType> {
    return this.http.put<MembershipType>(this.baseUrl + '/memberships/updatestatus' , id);
  }
}
