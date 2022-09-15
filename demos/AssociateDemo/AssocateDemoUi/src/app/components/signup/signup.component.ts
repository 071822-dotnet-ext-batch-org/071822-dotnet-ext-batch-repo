import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(public auth: AuthService) { }

  ngOnInit(): void {
  }

  signup(): void {
    this.auth.loginWithRedirect({
      screen_hint: 'signup' 
    });
  }
}
