import { Component, OnInit } from '@angular/core';
import {UserService} from "../services/user.service";
import {TokenService} from "../services/token.service";
import {ValueService} from "../services/value.service";

@Component({
  selector: 'app-incomes',
  templateUrl: './incomes.component.html',
  styleUrls: ['./incomes.component.css']
})
export class IncomesComponent implements OnInit {

  constructor(private userService: UserService,
              private tokenService: TokenService,
              public valueService: ValueService) { }

  ngOnInit(): void {
    this.userService.getUser(this.tokenService.getUser().sub).subscribe(
      value => {
        this.valueService.incomesList = value.budget.incomes.sort((a, b) => {
          return <any>new Date(a.date) - <any>new Date(b.date);
        });
        this.valueService.incomesList.forEach(val => this.valueService.totalIncome += val.value)
      }
    )
  }

}
