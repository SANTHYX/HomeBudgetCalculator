import { Injectable } from '@angular/core';
import {UserTokenDTO} from "../DTO/UserTokenDTO";

const tokenKey = 'auth-token';
const userKey = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  constructor() { }

  signOut(){
    window.sessionStorage.clear()
  }

  saveToken(token:string){
    window.sessionStorage.removeItem(tokenKey)
    window.sessionStorage.setItem(tokenKey, token)
  }

  getToken(): string{
    return sessionStorage.getItem(tokenKey)
  }

  saveUser(user: UserTokenDTO){
    window.sessionStorage.removeItem(userKey)
    window.sessionStorage.setItem(userKey, JSON.stringify(user))

  }

  getUser(): UserTokenDTO{
    return JSON.parse(sessionStorage.getItem(userKey))
  }
}
