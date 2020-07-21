import {Component, OnInit} from '@angular/core';
import {ValueService} from "../../../services/value.service";

@Component({
  selector: 'app-history-expenses',
  templateUrl: './history-expenses.component.html',
  styleUrls: ['./history-expenses.component.css']
})
export class HistoryExpensesComponent implements OnInit {
  constructor(public valueService: ValueService) {
  }

  ngOnInit(): void {
  }
}
