import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";

const api = 'http://localhost:8080/'
const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
}

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  constructor(private http: HttpClient) {
  }

  login(user) {
    return this.http.post(api + 'SignIn',
      user, httpOptions)
  }

  register(user) {
    return this.http.post(api + 'Users',
      user, httpOptions)
  }
}
