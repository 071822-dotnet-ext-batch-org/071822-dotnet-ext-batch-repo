import { Component, OnInit } from '@angular/core';
import { CalculatorServiceService } from '../calculator-service.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {

  constructor(private calcServ: CalculatorServiceService) { }

  ngOnInit(): void {
  }

  calcAddNumbers(x: number, y: number): void {
    this.calcServ.addNumbers(x, y);
  }

  calcAddNumbersReturnSum(x: number, y: number): number {
    const sum = this.calcServ.addNumbersReturnSum(x, y);
    return sum;
  }




}
