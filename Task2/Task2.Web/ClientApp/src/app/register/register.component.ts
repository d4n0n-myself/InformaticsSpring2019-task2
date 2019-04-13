import { Component, OnInit } from '@angular/core';
import {HttpService} from "../services/httpService/http.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  username: string;
  password: string;

  ngOnInit() {
  }

  Update() {
    this.httpService.register(this.username, this.password);
    location.replace('/');
  }
}
