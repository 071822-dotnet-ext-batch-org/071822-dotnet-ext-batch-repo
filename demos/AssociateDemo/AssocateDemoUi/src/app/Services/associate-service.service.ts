import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Associate } from './../Models/Associate';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AssociateServiceService {

  constructor(private http: HttpClient) { }

  private rootUrl = 'https://localhost:7163';

  public getAssociates(): Observable<Associate[]>{
    return this.http.get<Associate[]>(this.rootUrl + '/api/Associate');
  }
}
