import { Component, OnDestroy, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppUserService } from '../../AppUser/Services/app-user.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { BehaviorSubject, Subscription } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-searchbar',
  standalone: true,
  templateUrl: './search-contact.component.html',
  styleUrls: ['./search-contact.component.scss'],
  imports: [CommonModule, ReactiveFormsModule],
})
export class SearchbarComponent implements OnInit, OnDestroy {
  protected searchForm = new FormGroup({
    searchTerm: new FormControl(''),
  });

  protected $searchResult = new BehaviorSubject<any>(null);
  private searchResultSubscription: Subscription = new Subscription();
  protected showNoUserFound = false;

  constructor(
    private http: HttpClient,
    private appUserService: AppUserService
  ) {}

  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.searchResultSubscription.unsubscribe();
  }

  onSearch() {
    const searchTerm = this.searchForm.get('searchTerm')?.value;
    if (searchTerm) {
      const searchObj = {
        sort: [
          {
            field: 'userName',
            dir: 'asc',
          },
        ],
        filter: {
          field: 'userName',
          operator: 'eq',
          value: searchTerm,
        },
      };
      this.searchResultSubscription = this.appUserService
        .searchAppUser(searchObj)
        .subscribe((result) => {
          if (result.items.length) {
            this.$searchResult.next(result.items[0]);
            console.log(result.items[0]);
            
            this.showNoUserFound = false;
          } else {
            this.$searchResult.next(null);
            this.showNoUserFound = true;
          }
        });
    }
  }

  addContact(userId: string) {
    const contactObj = {
      appUserID: userId,
    };
    this.appUserService.createContact(contactObj).subscribe((result) => {
      console.log(result);
    });
  }
}
