import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {IncomesComponent} from "./incomes/incomes.component";
import {ExpenseComponent} from "./expense/expense.component";
import {BudgetComponent} from "./budget/budget.component";


const routes: Routes = [
  {path: 'incomes', component: IncomesComponent},
  {path: 'expenses', component: ExpenseComponent, data: {animation: 'isRight'}},
  {path: '', component: BudgetComponent, data: {animation: 'isLeft'}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
