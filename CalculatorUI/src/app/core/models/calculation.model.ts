import {Operations} from "../enums/operations";
import moment from "moment";

export interface Calculation {
  id: number;
  firstNumber: number;
  secondNumber: number;
  operation: Operations;
  result: number,
  calculatedAt: moment.Moment;
}
