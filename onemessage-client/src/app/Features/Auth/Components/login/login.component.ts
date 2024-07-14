import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../Services/auth.service';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { radixEyeClosed, radixEyeOpen } from '@ng-icons/radix-icons';
import { HttpErrorService } from '../../../../Core/Services/http-error/http-error.service';

@Component({
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgIconComponent,
    RouterModule,
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  viewProviders: [provideIcons({ radixEyeClosed, radixEyeOpen })],
})
export class LoginComponent {
  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });

  passwordVisibility = false;
  loadingText!: string;

  constructor(
    private authService: AuthService,
    private router: Router,
    private formBuilder: FormBuilder,
    protected httpErrorService: HttpErrorService
  ) {
    this.authService.userSubject.subscribe((user) => {
      if (!!user) {
        this.router.navigateByUrl('/');
      }
    });
    this.loadingText = 'Logging in...';
  }

  get email(): AbstractControl<string | null> | null {
    return this.loginForm.get('email');
  }

  get password(): AbstractControl<string | null> | null {
    return this.loginForm.get('password');
  }

  togglePasswordVisibility(): void {
    this.passwordVisibility = !this.passwordVisibility;
  }

  get isPasswordVisible(): string {
    return this.passwordVisibility ? 'text' : 'password';
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      this.authService.login(this.loginForm.value).subscribe({
        next: (data: any) => {
          if (data?.accessToken) {
            this.router.navigate(['/']); // Redirect to home page
          } else {
            console.error('Login failed:', data?.message || 'Unknown error');
          }
        },
        error: (err) => {
          console.error('Login request failed:', err);
          // this.httpErrorService.handleError(err); // Assuming you have a method to handle errors
        },
      });
    }
  }

  resetForm(): void {
    this.loginForm.reset();
  }
}
