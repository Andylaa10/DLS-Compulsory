import {inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {apiEndpoint} from "../constrains/constraint";
import {Observable} from "rxjs";
import {Calculation} from "../models/calculation.model";
import {AddCalculationDto} from "../dtos/addCalculation.dto";

@Injectable({
  providedIn: 'root'
})
export class CalculationService {
  private _httpClient: HttpClient = inject(HttpClient);

  constructor() {
    this.getAllCalculations().subscribe(r => {
      console.log(r);
    })
  }
  getAllCalculations(): Observable<Calculation[]> {
    return this._httpClient.get<Calculation[]>(`${apiEndpoint.CalculationEndPoint.getCalculations}`);
  }

  getCalculationById(calId: number): Observable<Calculation> {
    return this._httpClient.get<Calculation>(`${apiEndpoint.CalculationEndPoint.getCalculationById}/${calId}`);
  }

  addCalculation(addCalculationDto: AddCalculationDto): Observable<Calculation>{
    return this._httpClient.post<Calculation>(`${apiEndpoint.CalculationEndPoint.addCalculation}/`, addCalculationDto);
  }
}
