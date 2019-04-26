import { Component, OnInit } from '@angular/core';
import {HttpService, LoginModel} from "../services/httpService/http.service";
import {Router} from "@angular/router";
import {DelayService} from "../services/delay/delay.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private httpService: HttpService, public router: Router, private delay: DelayService) {
  }

  username: string;
  password: string;

  ngOnInit() {
  }

  async Update() {
    this.httpService.logIn(this.username, this.password).subscribe(result => {
      let model: LoginModel = result;
      localStorage.setItem('token', model.token);
    }, error  => {
      alert('Invalid credentials');
      console.log(error.error);
    });
    await this.delay.delay(1000);
    this.router.navigate(['/']);
  }

  RedirectToRegister() {
    this.router.navigate(["/register"])
  }
}
