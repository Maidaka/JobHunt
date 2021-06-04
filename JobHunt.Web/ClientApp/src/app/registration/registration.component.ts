import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from '../models/company';
import { User } from '../models/user';
import { CompanyService } from '../services/company.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  logintype: number = 1;
  user: User = new User;
  company: Company = new Company;

  registrationSuccesful: boolean = false;

  constructor(
    private userService: UserService,
    private companyService: CompanyService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  register = () => {
    // if login type is User, authenticate against UserService
    if (this.logintype == 1) {
      this.userService.register(this.user.username, this.user.password, this.user.firstName, this.user.lastName, this.user.bio, this.user.email)
        .subscribe(userData => {
          this.registrationSuccesful = true
        })
    }
    // else if login type is Company, authenticate against CompanyService
    else {
      this.companyService.register(this.company.username, this.company.password, this.company.name, this.company.description)
        .subscribe(companyData => {
          this.registrationSuccesful = true
        })
    }
  }
  
  goToLogin = () => {
    this.router.navigateByUrl("");
  }

}
