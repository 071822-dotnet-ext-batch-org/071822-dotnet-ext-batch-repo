import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Time } from '../Models/time';

@Injectable({
  providedIn: 'root'
})

export class CustomRequestService {

  private ApiUrl = 'https://localhost:7269';

  constructor(private http: HttpClient) { }

  public getTime(): Observable<Time>
  {
    return this.http.get<Time>(this.ApiUrl + "/time");
  }

}
