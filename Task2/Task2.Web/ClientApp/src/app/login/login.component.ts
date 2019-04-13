import { Component, OnInit } from '@angular/core';
import {HttpService} from "../services/httpService/http.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private httpService: HttpService, private router:Router) {
  }

  username: string;
  password: string;

  ngOnInit() {
  }

  Update() {
    this.httpService.logIn(this.username, this.password);
    location.replace('/');
  }

  RedirectToRegister() {
    this.router.navigate(["/register"])
  }
}
