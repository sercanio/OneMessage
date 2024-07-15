import {
  Component,
  Input,
  OnInit,
  OnChanges,
  SimpleChanges,
  OnDestroy,
  ViewChild,
  ElementRef,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageService } from '../../Services/message.service';
import { NgxSpinnerComponent, NgxSpinnerService } from 'ngx-spinner';
import { BehaviorSubject } from 'rxjs';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-message-detail',
  standalone: true,
  imports: [CommonModule, NgxSpinnerComponent, ReactiveFormsModule],
  templateUrl: './message-details.component.html',
})
export class MessageDetailComponent implements OnInit, OnChanges {
  @Input() contact: any;

  protected messageForm = new FormGroup({
    messageText: new FormControl(''),
  });

  protected $messages = new BehaviorSubject<any[]>([]);

  constructor(
    private messageService: MessageService,
    private spinner: NgxSpinnerService
  ) {}

  ngOnInit() {
    this.loadMessages();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['contact']) {
      this.loadMessages();
    }
  }

  protected loadMessages() {
    if (!this.contact || !this.contact.id) return;
    this.spinner.show();
    this.messageService.getMessages(this.contact.id).subscribe(
      (data: any) => {
        const allMessages = [
          ...(data.sentMessages || []),
          ...(data.receivedMessages || []),
        ];
        this.$messages.next(allMessages);
        this.spinner.hide();
      },
      (error: any) => {
        console.error('Error fetching messages:', error);
        this.spinner.hide();
      }
    );
  }

  protected sendMessage(contactId: string) {
    const messageObj = {
      receiverId: contactId,
      content: this.messageForm.get('messageText')?.value,
    };

    this.messageService.createMessage(messageObj).subscribe((response) => {
      if(response.id){
        this.loadMessages();
      }
    });
  }
}
