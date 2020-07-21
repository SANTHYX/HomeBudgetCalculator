import { Component, OnInit } from '@angular/core';
import {ValueService} from "../../services/value.service";

@Component({
  selector: 'app-expense-history',
  templateUrl: './expense-history.component.html',
  styleUrls: ['./expense-history.component.css']
})
export class ExpenseHistoryComponent implements OnInit {

  constructor(public valueService: ValueService) { }

  ngOnInit(): void {
  }

  delete(id: string) {
    this.valueService.expensesList = this.valueService.expensesList.filter(value => value.id != id)
    this.valueService.deleteExpense(id).subscribe()
  }
}
