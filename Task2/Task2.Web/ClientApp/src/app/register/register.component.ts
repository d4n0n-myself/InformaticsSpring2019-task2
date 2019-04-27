import { Component, OnInit } from '@angular/core';
import {HttpService} from "../services/httpService/http.service";
import {Router} from "@angular/router";
import {DelayService} from "../services/delay/delay.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private httpService: HttpService, public router: Router, private delay: DelayService) {
  }

  username: string;
  password: string;

  ngOnInit() {
  }

  async Update() {
    this.httpService.register(this.username, this.password);
    await this.delay.delay(1000);
    this.router.navigate(['/choose-subscription']);
  }
}
