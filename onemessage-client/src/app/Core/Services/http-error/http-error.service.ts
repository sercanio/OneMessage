import { Injectable } from '@angular/core';
import { HttpError } from '../../Models/HttpError';

@Injectable({ providedIn: 'root' })
export class HttpErrorService {
  private error: HttpError | null = null;

  constructor() {}

  get httpError(): HttpError | null {
    return this.error;
  }
  
  set httpError(error: HttpError | null) {
    this.error = error;
  }
}
