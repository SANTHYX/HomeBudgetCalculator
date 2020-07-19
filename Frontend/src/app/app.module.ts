import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NavbarComponent} from './navbar/navbar.component';
import {BudgetComponent} from './budget/budget.component';
import {ExpenseComponent} from './expense/expense.component';
import {IncomesComponent} from './incomes/incomes.component';
import {BudgetMainComponent} from './budget/budget-main/budget-main.component';
import {ChartsModule} from "ng2-charts";

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    BudgetComponent,
    ExpenseComponent,
    IncomesComponent,
    BudgetMainComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
