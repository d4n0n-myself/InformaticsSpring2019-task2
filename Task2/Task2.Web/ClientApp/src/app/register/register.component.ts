import { Component, OnInit } from '@angular/core';
import {HttpService} from "../services/httpService/http.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private httpService: HttpService, public router: Router) { }

  username: string;
  password: string;

  ngOnInit() {
  }

  async Update() {
    this.httpService.register(this.username, this.password);
    await this.delay(1000);
    this.router.navigate(['/']);
  }

  delay(ms: number) {
    console.log("hello delay");
    return new Promise( resolve => setTimeout(resolve, ms) );
  }
}
