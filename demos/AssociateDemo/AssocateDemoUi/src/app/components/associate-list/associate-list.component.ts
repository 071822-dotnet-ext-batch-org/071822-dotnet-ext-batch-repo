import { Component, OnInit } from '@angular/core';
import { AssociateServiceService } from 'src/app/Services/associate-service.service';
import { Associate } from './../../Models/Associate';

@Component({
  selector: 'app-associate-list',
  templateUrl: './associate-list.component.html',
  styleUrls: ['./associate-list.component.css']
})
export class AssociateListComponent implements OnInit {

  associates?: Associate[] = [];

  constructor(private ASService: AssociateServiceService) { }

  ngOnInit(): void {
    this.getAssociates()
  }

  getAssociates(): void {
    this.ASService.getAssociates()
      .subscribe(associates => this.associates = associates);
  }


}
