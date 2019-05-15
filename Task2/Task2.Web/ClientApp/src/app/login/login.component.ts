import {Component, OnInit} from '@angular/core';
import {HttpService} from "../services/httpService/http.service";
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
    await this.httpService.logIn(this.username, this.password);
    await this.delay.delay(300);
    location.replace('/posts');
  }

  RedirectToRegister() {
    this.router.navigate(["/register"])
  }
}
