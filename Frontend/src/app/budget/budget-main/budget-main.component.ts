import {Component, OnInit} from "@angular/core";
import {Label} from "ng2-charts";
import {ChartType} from "chart.js";
import {TokenService} from "../../services/token.service";
import {UserService} from "../../services/user.service";
import {Observable} from "rxjs";
import {UserDTO} from "../../DTO/UserDTO";
import {ValueService} from "../../services/value.service";

@Component({
  selector: 'app-budget-main',
  templateUrl: './budget-main.component.html',
  styleUrls: ['./budget-main.component.css']
})
export class BudgetMainComponent implements OnInit {
  donutlabels: Label[] = ['Wydatki', 'Przychody']
  donutType: ChartType = 'doughnut'
  data: Observable<UserDTO>

  ngOnInit(): void {
    this.data = this.userService.getUser(this.tokenService.getUser().sub)
    this.valueService.expensesList = []
    this.valueService.incomesList = []
    this.valueService.totalExpense = 0
    this.valueService.totalIncome = 0
    this.userService.getUser(this.tokenService.getUser().sub).subscribe(
      value => {
        if(value.budget.expenses){
          this.valueService.expensesList = value.budget.expenses
            .filter(value1 => {
              let date = new Date(Date.now())
              date.setDate(1)
              return new Date(value1.date) >= date;
            })
            .sort((a, b) => {
              return <any>new Date(a.date) - <any>new Date(b.date);
            });
          this.valueService.expensesList.forEach(val => this.valueService.totalExpense += val.value)
        }

        this.valueService.incomesList = value.budget.incomes
          .filter(value1 => {
            let date = new Date(Date.now())
            date.setDate(1)
            return new Date(value1.date) >= date;
          })
          .sort((a, b) => {
          return <any>new Date(a.date) - <any>new Date(b.date);
        });
        this.valueService.incomesList.forEach(val => this.valueService.totalIncome += val.value)
      }
    )
  }

  constructor(private tokenService: TokenService,
              private userService: UserService,
              public valueService: ValueService) {
  }

  donutDat() {
    return [[this.valueService.totalExpense, this.valueService.totalIncome]]
  }
}
