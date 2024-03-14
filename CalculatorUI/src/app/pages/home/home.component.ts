import {Component, inject, OnInit, signal} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatIcon} from "@angular/material/icon";
import {MatButton} from "@angular/material/button";
import {AdditionService} from "../../core/services/addition.service";
import {SubtractionService} from "../../core/services/subtraction.service";
import {Calculation} from "../../core/models/calculation.model";
import {
  CalculationResultCardComponent
} from "../../shared/components/calculation-result-card/calculation-result-card.component";
import {CalculationService} from "../../core/services/calculation.service";
import {AddCalculationDto} from "../../core/dtos/addCalculation.dto";
import {Operations} from "../../core/enums/operations";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    MatFormFieldModule, MatInputModule, MatIcon, ReactiveFormsModule, MatButton, CalculationResultCardComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  private _additionService: AdditionService = inject(AdditionService);
  private _subtractionService: SubtractionService = inject(SubtractionService);
  private _calculationService: CalculationService = inject(CalculationService);


  calcGroup: FormGroup = new FormGroup({
    firstNumber: new FormControl('', Validators.required),
    secondNumber: new FormControl('', Validators.required),
  });

  result = signal(0);

  calculations = signal<Calculation[]>([]);

  getFirstNumberForm(): number {
    return this.calcGroup.controls['firstNumber'].value;
  }

  getSecondNumberForm(): number {
    return this.calcGroup.controls['secondNumber'].value;
  }

  ngOnInit(): void {
    this.getCalculations();
  }

  addition() {
    const firstNumber = this.getFirstNumberForm();
    const secondNumber = this.getSecondNumberForm();
    this._additionService.addition(firstNumber, secondNumber).subscribe(result => {
      this.result.set(result);
      this.resetForm();
      const dto: AddCalculationDto = {
        firstNumber: firstNumber,
        secondNumber: secondNumber,
        result: result,
        Operation: Operations.Addition
      };
      this._calculationService.addCalculation(dto).subscribe(() => {
        console.log('Request sent')
      });
    });
    setTimeout(() => {
      this.getCalculations();
    }, 500)
  }

  subtraction() {
    const firstNumber = this.getFirstNumberForm();
    const secondNumber = this.getSecondNumberForm();
    this._subtractionService.subtraction(firstNumber, secondNumber).subscribe(result => {
      this.result.set(result);
      this.resetForm();

      const dto: AddCalculationDto = {
        firstNumber: firstNumber,
        secondNumber: secondNumber,
        result: result,
        Operation: Operations.Subtraction
      };
      this._calculationService.addCalculation(dto).subscribe(() => {
        console.log('Request sent')
      });
    });
    setTimeout(() => {
      this.getCalculations();
    }, 500)
  }

  resetForm() {
    this.calcGroup.reset();
  }

  getCalculations() {
    this._calculationService.getAllCalculations().subscribe(calculations => {
      this.calculations.set(calculations.reverse());
    });
  }

}
