import {Component, OnInit} from '@angular/core';
import {ValueService} from "../../../services/value.service";

@Component({
  selector: 'app-history-incomes',
  templateUrl: './history-incomes.component.html',
  styleUrls: ['./history-incomes.component.css']
})
export class HistoryIncomesComponent implements OnInit {
  constructor(public valueService: ValueService) {
  }

  ngOnInit(): void {
  }

}
