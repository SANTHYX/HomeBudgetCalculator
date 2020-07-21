import {Component, OnInit} from '@angular/core';
import {RouterOutlet} from "@angular/router";
import {TokenService} from "./services/token.service";
import {fader} from './anumations';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [
    fader
  ]
})
export class AppComponent implements OnInit {
  title = 'Frontend';

  constructor(private tokenService: TokenService) {
  }

  get loggedIn() {
    return this.tokenService.getUser()
  }

  ngOnInit(): void {
  }

  prepareRoute(outlet: RouterOutlet) {
    return outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'];
  }
}
