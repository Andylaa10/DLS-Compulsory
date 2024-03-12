import {Operations} from "../enums/operations";

export interface AddCalculationDto {
  firstNumber: number;
  secondNumber: number;
  Operation: Operations;
}
