import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { featherFacebook } from '@ng-icons/feather-icons';
import { bootstrapTwitterX } from '@ng-icons/bootstrap-icons';
import { AuthService } from '../../../Features/Auth/Services/auth.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule, NgIconComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
  viewProviders: [provideIcons({ featherFacebook, bootstrapTwitterX })],
})
export class HeaderComponent {
  isMenuOpen: boolean = false;
  userEmail: string = '';
  userName: string = '';
  authenticated: boolean = false;

  constructor(
    private authService: AuthService,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {
    this.authService.userSubject.subscribe((user) => {
      this.userEmail = user?.firstName || user?.email || '';
      this.authenticated = !!user;
    });
  }

  toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen;
  }

  closeMenu(): void {
    this.isMenuOpen = false;
  }

  logOut(): void {
    this.authService.logout();
    this.authenticated = false;
  }
}
