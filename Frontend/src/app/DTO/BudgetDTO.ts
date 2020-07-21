import {IncomeDTO} from "./IncomeDTO";
import {ExpenseDTO} from "./ExpenseDTO";

export class BudgetDTO {
  id: string
  budgetAmount: number
  totalIncome: number
  totalExpense: number
  incomes: Array<IncomeDTO>
  expenses: Array<ExpenseDTO>
}
