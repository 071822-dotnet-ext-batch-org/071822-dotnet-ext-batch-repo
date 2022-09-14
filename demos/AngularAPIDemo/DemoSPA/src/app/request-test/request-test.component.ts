import { Component, OnInit } from '@angular/core';
import { CustomRequestService } from '../Services/custom-request.service';

@Component({
  selector: 'app-request-test',
  templateUrl: './request-test.component.html',
  styleUrls: ['./request-test.component.css']
})
export class RequestTestComponent implements OnInit {

  currentTime: any;
  todos: any;

  constructor(private CR: CustomRequestService) { }

  ngOnInit(): void {
  }

  displayTime()
  {
    this.CR.getTime().subscribe(data =>
      {
        this.currentTime = data;
        this.todos = null;
      })
  }

  displayTodos()
  {
    this.CR.getTodos().subscribe(data =>
      {
        this.todos = data;
        this.currentTime = null;
      })
  }
}
