import {Component, Input} from '@angular/core';
import {Calculation} from "../../../core/models/calculation.model";
import moment from "moment";
import {Operations} from "../../../core/enums/operations";

@Component({
  selector: 'app-calculation-result-card',
  standalone: true,
  imports: [],
  templateUrl: './calculation-result-card.component.html',
  styleUrl: './calculation-result-card.component.scss'
})
export class CalculationResultCardComponent {
  @Input() calculationResult: Calculation = {
    id: 0,
    calculatedAt: moment(),
    result: 0,
    secondNumber: 0,
    firstNumber: 0,
    operation: Operations.Addition
  };
}
