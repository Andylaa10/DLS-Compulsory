import {inject, Injectable} from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {apiEndpoint} from "../constrains/constraint";

@Injectable({
  providedIn: 'root'
})
export class AdditionService {

  private _http: HttpClient = inject(HttpClient);

  constructor() {
  }
  addition(num1: number, num2: number): Observable<number>{
    return this._http.get<number>(`${apiEndpoint.AdditionEndPoint.addition}/${num1}/${num2}`);
  }

}
