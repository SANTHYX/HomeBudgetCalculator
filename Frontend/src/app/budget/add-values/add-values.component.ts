import {Component, OnInit} from '@angular/core';
import {TokenService} from "../../services/token.service";
import {UserService} from "../../services/user.service";
import {Observable} from "rxjs";
import {UserDTO} from "../../DTO/UserDTO";
import {ValueService} from "../../services/value.service";
import {AddValuesDTO} from "../../DTO/AddValuesDTO";

@Component({
  selector: 'app-add-values',
  templateUrl: './add-values.component.html',
  styleUrls: ['./add-values.component.css']
})
export class AddValuesComponent implements OnInit {
  name: string;
  values: number;
  data: Observable<UserDTO>

  constructor(private tokenService: TokenService,
              private userService: UserService,
              private valueService: ValueService) {
  }

  ngOnInit(): void {
    this.data = this.userService.getUser(this.tokenService.getUser().sub)
  }

  addIncomes(id: string) {
    let income = new AddValuesDTO(id, this.name, this.values, new Date(Date.now()))
    this.valueService.addIncomes(income)
  }

  addExpenses(id: string) {
    let expense = new AddValuesDTO(id, this.name, this.values, new Date(Date.now()))
    this.valueService.addExpenses(expense)

  }
}
