import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';


@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseUrl='https://localhost:7059/api/users';

  constructor(private http: HttpClient) { }

  //Get all users
  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl);
  }

  addUser(user:User):Observable<User> {
    user.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<User>(this.baseUrl,user);
  }

  deleteUser(id:string): Observable<User> {
    return this.http.delete<User>(this.baseUrl + '/' + id);
  }
}
