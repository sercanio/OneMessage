import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from '../Models/LoginResponse';
import { BehaviorSubject, from, Observable, of, switchMap, tap } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public userSubject = new BehaviorSubject<any>(null);
  constructor(private router: Router, private http: HttpClient) {
    this.getUserFromAuth().subscribe((user) => {
      this.userSubject.next(user);
    });
  }

  login(data: any) {
    return this.http
      .post<LoginResponse>('http://localhost:60805/api/Auth/Login', data)
      .pipe(
        tap((result) => {
          document.cookie = `accessToken=${result.accessToken.token}`;
        }),
        tap((result) => {
          this.getUserFromAuth().subscribe({
            next: (member) => {
              this.userSubject.next(member);
              this.userSubject.value;
              // window.location.href = `/${member?.memberSetting.language}`;
            },
          });
        })
      );
  }

  public logout(): void {
    this.getAccessToken().subscribe((accessToken) => {
      if (accessToken) {
        this.revokeToken().subscribe(() => {
          console.log('Token revoked successfully');
          this.deleteAccessToken();
          this.userSubject.next(null);
          this.router.navigateByUrl('/');
        });
      } else {
        console.error('Access token not found');
      }
    });
  }

  public getAccessToken(): Observable<string | null> {
    return from(
      new Promise<string | null>(async (resolve) => {
        if (typeof document !== 'undefined') {
          const accessToken = await this.getToken('accessToken');
          resolve(accessToken);
        } else {
          resolve(null);
        }
      })
    );
  }

  private deleteAccessToken(): void {
    document.cookie = 'accessToken =; expires = Thu, 01 Jan 1970 00:00:00 UTC;';
  }

  private async getToken(name: string): Promise<string> {
    const value = `; ${await document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop()?.split(';').shift() || '';
    return '';
  }

  private revokeToken(): Observable<any> {
    return this.http.put<any>(
      'http://localhost:60805/api/Auth/RevokeToken',
      null
    );
  }

  public getUserFromAuth(): Observable<any> {
    return this.getAccessToken().pipe(
      switchMap((accessToken) => {
        if (!accessToken) {
          return of(null);
        }
        return this.http.get<any>(
          'http://localhost:60805/api/Users/GetFromAuth'
        );
      })
    );
  }

  public refreshAccesstoken(): void {
    this.http
      .get<any>('http://localhost:60805/api/Auth/RefreshToken')
      .subscribe((response) => {
        this.storeAccessToken(response.token);
        this.refreshuserSubject();
        console.log("AccessToken Refreshed");
        
      });
  }

  private storeAccessToken(token: string): void {
    document.cookie = `accessToken=${token}`;
  }

  public refreshuserSubject(): void {
    this.getUserFromAuth().subscribe({
      next: (member) => {
        this.userSubject.next(member);
      },
    });
  }
}
