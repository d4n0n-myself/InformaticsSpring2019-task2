import { Component, OnInit } from '@angular/core';
import {HttpService} from "../services/httpService/http.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-buy-subscription',
  templateUrl: './buy-subscription.component.html',
  styleUrls: ['./buy-subscription.component.css']
})
export class BuySubscriptionComponent implements OnInit {

  constructor(private http: HttpService, public router: Router) {
  }

  roles = new Array<Role>();

  //надо как-то наполнить метод для покупки подписки
  // buySubscribtion(id: number) {
  // }
  ngOnInit() {
    this.http.getPrices().subscribe(result => {
      this.roles = result as Role[];
    });
  }

  buySubscription(id: number) {
    this.http.buySubscription(id).subscribe(result => {
      localStorage.setItem('token',result.token);
    });
    this.router.navigate(['/posts']);
  }
}

export interface Role {
  name: string;
  price: number;
}
