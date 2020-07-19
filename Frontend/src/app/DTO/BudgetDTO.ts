import {Guid} from "guid-typescript";
import {IncomeDTO} from "./IncomeDTO";
import {ExpenseDTO} from "./ExpenseDTO";

export class BudgetDTO {
  id: Guid
  BudgetAmount: number
  TotalIncome: number
  TotalExpense: number
  Incomes: Array<IncomeDTO>
  Expenses: Array<ExpenseDTO>
}
