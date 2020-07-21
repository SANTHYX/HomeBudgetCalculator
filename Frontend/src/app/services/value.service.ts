import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {AddValuesDTO} from "../DTO/AddValuesDTO";
import {IncomeDTO} from "../DTO/IncomeDTO";
import {ExpenseDTO} from "../DTO/ExpenseDTO";

const api = 'http://localhost:8080/'
const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
}

@Injectable({
  providedIn: 'root'
})
export class ValueService {
  incomesList: Array<IncomeDTO>
  expensesList: Array<ExpenseDTO>
  totalExpense: number = 0
  totalIncome: number = 0
  constructor(private http: HttpClient) {
  }

  addExpenses(val: AddValuesDTO) {
    this.expensesList.push(new ExpenseDTO(val.budgetId, val.title, val.value, val.date))
    this.http.post<AddValuesDTO>(api + 'Expenses/',
      this.stringify(val), httpOptions).subscribe()
    this.totalExpense = +this.totalExpense + +val.value
  }

  addIncomes(val: AddValuesDTO) {
    this.incomesList.push(new IncomeDTO(val.budgetId, val.title, val.value, val.date))
    this.http.post<AddValuesDTO>(api + 'Incomes/',
      this.stringify(val), httpOptions).subscribe( )



    this.totalIncome = +this.totalIncome + +val.value
  }

  stringify(val: AddValuesDTO): string {
    return '{"budgetId":"' + val.budgetId + '",' +
      '"title":"' + val.title + '",' +
      '"value":' + val.value + ',' +
      '"date":"' + val.date.toISOString() + '"}'
  }

  get totalBudget(){
    return +this.totalIncome - +this.totalExpense
  }

  deleteIncome(ids: string) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: ids,
      },
    };
    return this.http.delete(api + 'Incomes/', options)
  }

  deleteExpense(ids: string) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: ids,
      },
    };
    return this.http.delete(api + 'Expenses/', options)
  }
}

