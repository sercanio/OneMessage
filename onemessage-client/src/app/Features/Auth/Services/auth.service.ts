import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from '../Models/LoginResponse';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {}

  login(data: any) {
    return this.http.post<LoginResponse>('http://localhost:60805/api/Auth/Login', data)
      .pipe(tap((result) => {
        document.cookie = `accessToken=${result.accessToken.token}`;
      }));
  }
}
