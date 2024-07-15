import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageService } from '../../Services/message.service';
import { AuthService } from '../../../Auth/Services/auth.service';

@Component({
  selector: 'app-message-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './messages-list.component.html',
})
export class MessageListComponent implements OnInit {
  contacts: any[] = [];
  selectedContact: any = null; // Add a property to store the selected contact
  @Output() contactSelected = new EventEmitter<any>();

  constructor(
    private authService: AuthService,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.authService.appUserSubject.subscribe((appUser) => {
      if (appUser) {
        this.contacts = appUser.contacts;
        console.log(this.contacts);
      }
    });
    
  }

  protected selectContact(contact: any): void {
    this.selectedContact = contact; // Update the selectedContact property
    this.contactSelected.emit(contact);
  }
}
