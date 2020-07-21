import {Component, OnInit} from '@angular/core';
import {TokenService} from "../services/token.service";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private token: TokenService) {
  }

  get user() {
    return this.token.getUser().sub
  }

  ngOnInit(): void {
  }

  logOut() {
    this.token.signOut()
  }
}
