import {Component, OnInit} from '@angular/core';
import {ValueService} from "../../services/value.service";

@Component({
  selector: 'app-incomes-history',
  templateUrl: './incomes-history.component.html',
  styleUrls: ['./incomes-history.component.css']
})
export class IncomesHistoryComponent implements OnInit {

  constructor(public valueService: ValueService) {
  }

  ngOnInit(): void {
  }

  delete(id: string) {
    this.valueService.incomesList = this.valueService.incomesList.filter(value => value.id != id)
    this.valueService.deleteIncome(id).subscribe()
  }
}
