import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';

import {TokenService} from "./token.service";


const tokenHeader = 'Authorization';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private token: TokenService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler){
    let authReq = req;
    const token = this.token.getToken()
    if (token != null) {
      authReq = req.clone({
        headers: req.headers.set(tokenHeader, 'Bearer ' + token)})
    }
    return next.handle(authReq)
  }
}

export const authInterceptorProviders  = [
  {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}
]
