import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalculatorServiceService {

  constructor() { }

  addNumbers(x: number, y: number): void {
    const sum = x + y;
  }

  addNumbersReturnSum(x: number, y: number): number {
    const sum = x + y;
    return sum;
  }
}
