import {Component, OnInit} from '@angular/core';
import {AuthorizationService} from "../services/authorization.service";
import {TokenService} from "../services/token.service";
import {UserTokenDTO} from "../DTO/UserTokenDTO";
import {LoginDTO} from "../DTO/LoginDTO";
import {RegisterDTO} from "../DTO/RegisterDTO";
import {UserService} from "../services/user.service";
import {finalize} from "rxjs/operators";

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
              private tokenService: TokenService,
              private userService: UserService) {
  }

  ngOnInit(): void {
  }

  logIn() {
    this.authService.login(new LoginDTO(this.login, this.password))
      .subscribe(
        data => {
        }, err => {
          this.tokenService.saveToken(err.error.text)
          let token: UserTokenDTO = JSON
            .parse(atob((err.error.text).split('.')[1]))
          this.tokenService.saveUser(token)
        }
      )
  }

  changeForm() {
    this.loginForm = !this.loginForm
  }

  async register() {
    this.authService.register(new RegisterDTO(this.firstName, this.lastName, this.login, this.password, this.email))
      .pipe(finalize(() => {
        this.userService.postBudget(this.login).subscribe()
      }))
      .subscribe()
    window.location.reload()
  }
}
