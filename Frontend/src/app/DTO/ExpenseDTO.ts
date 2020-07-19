import {Guid} from "guid-typescript";

export class ExpenseDTO {
  Id: Guid
  Title: string
  Value: number
  Date: Date
}
