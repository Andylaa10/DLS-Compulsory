import {inject, Injectable} from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {apiEndpoint} from "../constrains/constraint";

@Injectable({
  providedIn: 'root'
})
export class AdditionService {

  private _httpClient: HttpClient = inject(HttpClient);
  addition(num1: number, num2: number): Observable<number>{
    return this._httpClient.get<number>(`${apiEndpoint.AdditionEndPoint.addition}/${num1}/${num2}`);
  }

}
