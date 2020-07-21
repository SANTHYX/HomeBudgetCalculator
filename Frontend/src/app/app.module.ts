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
import {AddValuesComponent} from './budget/add-values/add-values.component';
import {BudgetHistoryComponent} from './budget/budget-history/budget-history.component';
import {HistoryIncomesComponent} from './budget/budget-history/history-incomes/history-incomes.component';
import {HistoryExpensesComponent} from './budget/budget-history/history-expenses/history-expenses.component';
import {LoginComponent} from './login/login.component';
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {authInterceptorProviders} from "./services/auth.interceptor";
import {IncomesHistoryComponent} from './incomes/incomes-history/incomes-history.component';
import {ExpenseHistoryComponent} from './expense/expense-history/expense-history.component';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    BudgetComponent,
    ExpenseComponent,
    IncomesComponent,
    BudgetMainComponent,
    AddValuesComponent,
    BudgetHistoryComponent,
    HistoryIncomesComponent,
    HistoryExpensesComponent,
    LoginComponent,
    IncomesHistoryComponent,
    ExpenseHistoryComponent
  ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        ChartsModule,
        FormsModule,
      HttpClientModule
    ],
  providers: [authInterceptorProviders, HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule {
}
