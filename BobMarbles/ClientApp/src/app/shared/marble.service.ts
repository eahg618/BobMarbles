import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Marble } from './marble.model';

@Injectable({
  providedIn: 'root'
})
export class MarbleService {


  constructor(private http: HttpClient) { }

  readonly _baseUrl = "https://localhost:7046/api/Marbles";//desarrollo
  formData: Marble = new Marble();
  list: Marble[] = [];
  postMarble() {
    return this.http.post(this._baseUrl, this.formData);
  }
  putMarble() {
    return this.http.put(this._baseUrl + "/" + this.formData.id, this.formData);
  }
  deleteMarble(id: number) {
    return this.http.delete(this._baseUrl + "/" + id);
  }
  refreshList() {
    this.http.get(this._baseUrl).toPromise().then(res => this.list = res as Marble[]);
  }
 
}
