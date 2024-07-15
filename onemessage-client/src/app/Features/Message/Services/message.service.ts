import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  private apiUrl = 'http://localhost:60805/api/Messages';

  constructor(private http: HttpClient) {}

  public getMessages(contactId: string): Observable<any[]> {
    return this.http.get<any[]>(
      `${this.apiUrl}/GetListByAppUserId?PageIndex=0&PageSize=10&appUserId=${contactId}`
    );
  }

  public createMessage(requestBody: any): Observable<any> {
    return this.http.post<any>(
      'http://localhost:60805/api/Messages',
      requestBody
    );
  }
}
