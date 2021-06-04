import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(private authService: AuthService) {

  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  isCompanyLoggedIn() {
    return this.authService.getCompanyData() != null;
  }

  isUserLoggedIn() {
    return this.authService.getUserData() != null;
  }

  isUserOrCompanyLoggedIn() {
    return this.isUserLoggedIn() || this.isCompanyLoggedIn();
  }

  logOut() {
    this.authService.logOut();
  }
}
