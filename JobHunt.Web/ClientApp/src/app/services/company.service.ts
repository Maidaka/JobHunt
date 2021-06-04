import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from '../models/company';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private _baseApiUrl = "https://localhost:44379";

  private userData: User = null;

  constructor(
    private http: HttpClient,
    private router: Router) { }

  login = (username: string, password: string) => {

    var request = {
      "username": username,
      "password": password
    };

    return this.http
      .post<Company>(this._baseApiUrl + "/api/company/login", request);
  }

  register = (username: string, password: string, name: string, description: string) => {
    var request = {
      "username": username,
      "password": password,
      "name": name,
      "description": description
    };

    return this.http
      .post(this._baseApiUrl + "/api/company/register", request);
  }
}
