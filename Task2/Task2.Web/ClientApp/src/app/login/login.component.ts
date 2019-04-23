import { Component, OnInit } from '@angular/core';
import {HttpService, LoginModel} from "../services/httpService/http.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private httpService: HttpService, public router:Router) {
  }

  username: string;
  password: string;

  ngOnInit() {
  }

  async Update() {
    this.httpService.logIn(this.username, this.password).subscribe(result => {
      let model : LoginModel = result;
      localStorage.setItem('token', model.token);
    }, error => {
      console.log("errLogin");
    });
    await this.delay(1000);
    this.router.navigate(['/']);
  }

  delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
  }

  RedirectToRegister() {
    this.router.navigate(["/register"])
  }
}
