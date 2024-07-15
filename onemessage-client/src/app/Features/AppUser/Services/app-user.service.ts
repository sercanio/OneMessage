import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AppUserService {
  constructor(private http: HttpClient) {}

  searchAppUser(requestBody: any): Observable<any> {
    return this.http.post<any>(
      'http://localhost:60805/api/AppUsers/GetDynamicAppUser?PageIndex=0&PageSize=10',
      requestBody
    );
  }

  createContact(requestBody: any): Observable<any> {
    return this.http.post<any>(
      'http://localhost:60805/api/AppUsers/CreateAppUserContact',
      requestBody
    );
  }
}
