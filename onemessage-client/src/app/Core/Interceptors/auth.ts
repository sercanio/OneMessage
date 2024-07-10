import {
    HttpInterceptorFn,
    HttpRequest,
    HttpStatusCode,
  } from '@angular/common/http';
  import { inject } from '@angular/core';
//   import { AuthService } from '../services/auth/auth.service';
  import { catchError, throwError } from 'rxjs';
  
  export const authInterceptor: HttpInterceptorFn = (
    req: HttpRequest<any>,
    next
  ) => {
    // const authService = inject(AuthService);  
    if (typeof document !== 'undefined') {
  
      req = req.clone({
        withCredentials: true,
      });
  
      function getAccessToken(): string | undefined {
        return document.cookie
          .split('; ')
          .find((row) => row.startsWith('accessToken'))
          ?.split('=')[1];
      }
  
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${getAccessToken()}`
        },
        withCredentials: true,
      });
    }
  
    return next(req).pipe(
      catchError((error) => {
        if (error.status === HttpStatusCode.Unauthorized) {
          console.log('Unauthorized, refreshing token...');
        //   authService.refreshAccesstoken();
        }
        return throwError(() => error);
      })
    );
  };
  