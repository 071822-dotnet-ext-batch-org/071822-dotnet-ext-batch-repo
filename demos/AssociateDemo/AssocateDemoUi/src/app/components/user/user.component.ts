import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  profileJson: string = "";

  constructor(public auth: AuthService) { }

  ngOnInit(): void {
    this.auth.user$.subscribe( profile =>
      (this.profileJson = JSON.stringify(profile, null, 2))
    );
  }
}
