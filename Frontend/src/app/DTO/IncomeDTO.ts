export class IncomeDTO {
  constructor(budgetId: string, title: string, value: number, date: Date) {
    this.id = budgetId;
    this.title = title;
    this.value = value;
    this.date = date;
  }

  id: string
  title: string
  value: number
  date: Date
}
