import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
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
      .post<User>(this._baseApiUrl + "/api/user/login", request);
  }

  register = (username: string, password: string, firstName: string, lastName: string, bio: string, email: string) => {
    var request = {
      "username": username,
      "password": password,
      "firstName": firstName,
      "lastName": lastName,
      "bio": bio,
      "email": email
    };

    return this.http
      .post(this._baseApiUrl + "/api/user/register", request);
  }

  getUserData = (userId: number) => {
    return this.http
      .get<User>(this._baseApiUrl + "/api/user/" + userId);
  }
}
