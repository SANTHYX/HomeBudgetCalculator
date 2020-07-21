import {Component, OnInit} from '@angular/core';
import {AuthorizationService} from "../services/authorization.service";
import {TokenService} from "../services/token.service";
import {UserTokenDTO} from "../DTO/UserTokenDTO";
import {LoginDTO} from "../DTO/LoginDTO";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: boolean = true;
  login: string;
  password: string;
  email: string;
  lastName: string;
  firstName: string;

  constructor(private authService: AuthorizationService,
              private tokenService: TokenService) {
  }

  ngOnInit(): void {
  }

  logIn() {
    this.authService.login(new LoginDTO(this.login, this.password)).subscribe(
      data => {
      }, err => {
        this.tokenService.saveToken(err.error.text)
        let token: UserTokenDTO = JSON
          .parse(atob((err.error.text).split('.')[1]))
        this.tokenService.saveUser(token)
      }
    )
    window.location.reload()
  }

  changeForm() {
    this.loginForm = !this.loginForm
  }

  register() {

  }
}
