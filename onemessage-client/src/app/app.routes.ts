import { Routes } from '@angular/router';
import { LoginComponent } from './Features/Auth/Components/login/login.component';
import { RegisterComponent } from './Features/Auth/Components/register/register.component';
import { MessagesComponent } from './Features/Message/Components/Messages/messages.component';
import { HomeComponent } from './Core/Components/home/home.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'messages', component: MessagesComponent },
];
