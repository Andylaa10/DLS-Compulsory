import {Component, inject, signal} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatIcon} from "@angular/material/icon";
import {MatButton} from "@angular/material/button";
import {AdditionService} from "../../core/services/addition.service";
import {SubtractionService} from "../../core/services/subtraction.service";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    MatFormFieldModule, MatInputModule, MatIcon, ReactiveFormsModule, MatButton
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  private _additionService: AdditionService = inject(AdditionService);
  private _subtractionService: SubtractionService = inject(SubtractionService);

  calcGroup: FormGroup = new FormGroup({
    firstNumber: new FormControl('', Validators.required),
    secondNumber: new FormControl('', Validators.required),
  });

  result = signal(0);

  getFirstNumberForm(): number{
    return this.calcGroup.controls['firstNumber'].value;
  }

  getSecondNumberForm(): number{
    return this.calcGroup.controls['secondNumber'].value;
  }

  addition(){
    const firstNumber = this.getFirstNumberForm();
    const secondNumber = this.getSecondNumberForm();
    this._additionService.addition(firstNumber, secondNumber).subscribe(result => {
      this.result.set(result);
      this.resetForm();
    })
  }

  subtraction(){
    const firstNumber = this.getFirstNumberForm();
    const secondNumber = this.getSecondNumberForm();
    this._subtractionService.subtraction(firstNumber, secondNumber).subscribe(result => {
      this.result.set(result);
      this.resetForm();
    })
  }
  resetForm(){
    this.calcGroup.reset();
  }

}
