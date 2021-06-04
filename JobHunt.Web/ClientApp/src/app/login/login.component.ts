import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../models/user';
import { AuthService } from '../services/auth.service';
import { CompanyService } from '../services/company.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: string;
  password: string;
  logintype: number = 1;

  credentialsInvalid: boolean = false;

  constructor(
    private userService: UserService, 
    private router: Router,
    private companyService: CompanyService,
    private authService: AuthService) { }

  ngOnInit() {
    // this.username = "john.doe";
    // this.password = "password";
    // this.logintype = 1;
    // this.login();
  }

  login = () => {
    this.credentialsInvalid = false;

    // if login type is User, authenticate against UserService
    if (this.logintype == 1) {
      this.userService.login(this.username, this.password)
        .subscribe(userData => {
          if (userData != null){
            this.authService.setupUser(userData);
            this.router.navigateByUrl("user/dashboard");
          }
          else {
            this.credentialsInvalid = true;
          }
        })
    }
    // else if login type is Company, authenticate against CompanyService
    else {
      this.companyService.login(this.username, this.password)
        .subscribe(companyData => {
          if (companyData != null){
            this.authService.setupCompany(companyData);
            this.router.navigateByUrl("company/dashboard");
          }
          else {
            this.credentialsInvalid = true;
          }
        })
    }
  }

  goToRegister = () => {
    this.router.navigateByUrl("register");
  }
}
