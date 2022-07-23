import { Component, OnInit } from '@angular/core';
import { User } from './models/user.model';
import { UsersService } from './service/users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'users';
  users: User[]=[];
  user: User = {
    id: '',
    userName: '',
    userSurname: '',
    userAge: ''
  }

  constructor(private usersService: UsersService) {

  }
  ngOnInit(): void {
    this.getAllUsers();
  }

  getAllUsers() {
    this.usersService.getAllUsers()
    .subscribe(
      response => {
        this.users = response;
      }
    );
  }

  onSubmit() {
    this.usersService.addUser(this.user)
    .subscribe(
      response => {
        this.getAllUsers();
        this.user = {
          id: '',
          userName: '',
          userSurname: '',
          userAge: ''
        }
      }
    )
  }

  deleteUser(id: string) {
    this.usersService.deleteUser(id)
    .subscribe(
      response =>{
        this.getAllUsers();
      }
    )
  }
}
