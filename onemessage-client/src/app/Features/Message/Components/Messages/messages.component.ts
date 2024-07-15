import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageListComponent } from '../MessagesList/messages-list.component';
import { MessageDetailComponent } from '../MessageDetails/message-details.component';
import { MessageService } from '../../Services/message.service';
import { SearchbarComponent } from '../../../SearchContact/Components/search-contact.component';

@Component({
  selector: 'app-messages',
  standalone: true,
  imports: [CommonModule, MessageListComponent, MessageDetailComponent, SearchbarComponent],
  templateUrl: './messages.component.html',
})
export class MessagesComponent {
  selectedContact: any = null;

  constructor(private messageService: MessageService) {}

  onSelectContact(contact: any) {
    this.selectedContact = contact;
  }
}
