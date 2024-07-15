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
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  viewProviders: [provideIcons({ radixEyeClosed, radixEyeOpen })],
})
export class RegisterComponent {
  registerForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
    userName: new FormControl('', [Validators.required]),
  });

  passwordVisibility = false;
  loadingText!: string;

  constructor(
    private authService: AuthService,
    private router: Router,
    private formBuilder: FormBuilder,
    protected httpErrorService: HttpErrorService
  ) {
    this.loadingText = 'Registering...';
  }

  get email(): AbstractControl<string | null> | null {
    return this.registerForm.get('email');
  }

  get password(): AbstractControl<string | null> | null {
    return this.registerForm.get('password');
  }

  get userName(): AbstractControl<string | null> | null {
    return this.registerForm.get('userName');
  }

  get avatarURL(): AbstractControl<string | null> | null {
    return this.registerForm.get('avatarURL');
  }

  togglePasswordVisibility(): void {
    this.passwordVisibility = !this.passwordVisibility;
  }

  get isPasswordVisible(): string {
    return this.passwordVisibility ? 'text' : 'password';
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      this.authService.register(this.registerForm.value).subscribe({
        next: (data: any) => {
          if (data?.id) {
            this.router.navigate(['/login']); // Redirect to login page
          } else {
            console.error('Registration failed:', data?.message || 'Unknown error');
          }
        },
        error: (err) => {
          console.error('Registration request failed:', err);
        },
      });
    }
  }

  resetForm(): void {
    this.registerForm.reset();
  }
}
