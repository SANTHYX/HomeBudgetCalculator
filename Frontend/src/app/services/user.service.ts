import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {UserDTO} from "../DTO/UserDTO";
import {Observable} from "rxjs";

const api = 'http://localhost:8080/'

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) {
  }

  getUser(username: string): Observable<UserDTO> {
    return this.http.get<UserDTO>(api + 'Users/' + username, {responseType: "json"})
  }

  postBudget(username: string) {
    return this.http.post(api + 'Budgets/',
      {UserLogin: username}, {responseType: "json"})
  }
}
