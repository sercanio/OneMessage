import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './Shared/Components/header/header.component';
import { MessagesComponent } from './Features/Message/Components/Messages/messages.component';
import { AuthService } from './Features/Auth/Services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, MessagesComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'onemessage-client';

  constructor(private authService: AuthService) {}
}
