export class AddValuesDTO {
  constructor(budgetId: string, title: string, value: number, date: Date) {
    this.budgetId = budgetId;
    this.title = title;
    this.value = value;
    this.date = date
  }
  budgetId: string
  title: string
  value: number
  date: Date
}
