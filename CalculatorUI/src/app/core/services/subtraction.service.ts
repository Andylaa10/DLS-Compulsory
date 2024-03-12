import {inject, Injectable} from '@angular/core';
import {Observable} from "rxjs";
import {apiEndpoint} from "../constrains/constraint";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class SubtractionService {
  private _httpClient: HttpClient = inject(HttpClient);
  subtraction(num1: number, num2: number): Observable<number>{
    return this._httpClient.get<number>(`${apiEndpoint.SubtractionEndPoint.subtraction}/${num1}/${num2}`);
  }}
