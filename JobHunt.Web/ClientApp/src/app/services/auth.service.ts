import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from '../models/company';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private userData: User = null;
  private companyData: Company = null;

  constructor(private router: Router) { }

  setupUser = (user: User) => {
    this.userData = user;
  }

  setupCompany = (company: Company) => {
    this.companyData = company;
  }

  getUserData = () => {
    return this.userData;
  }

  getCompanyData = () => {
    return this.companyData;
  }

  checkIfUserIsLoggedIn = () => {
    // if userData is null, that means user is not logged in so redirect to login
    if (this.userData == null) {
      this.router.navigateByUrl("");
    }
  }

  checkIfCompanyIsLoggedIn = () => {
    // if companyData is null, that means user is not logged in so redirect to login
    if (this.companyData == null) {
      this.router.navigateByUrl("");
    }
  }

  checkIfIsLoggedIn = () => {
    this.checkIfUserIsLoggedIn();
    this.checkIfCompanyIsLoggedIn();
  }

  logOut = () => {
    this.userData = null;
    this.companyData = null;
    this.router.navigateByUrl("");
  }
}
