import {Component, OnInit} from '@angular/core';
import {HttpService} from "../services/httpService/http.service";
import {Router} from "@angular/router";
import {AuthenticationService} from "../services/authentication/authentication.service";

@Component({
  selector: 'app-buy-subscription',
  templateUrl: './buy-subscription.component.html',
  styleUrls: ['./buy-subscription.component.css']
})
export class BuySubscriptionComponent implements OnInit {

  constructor(private http: HttpService, public router: Router, private auth: AuthenticationService) {
  }

  roles = new Array<Role>();
  role: string;
  //надо как-то наполнить метод для покупки подписки
  // buySubscribtion(id: number) {
  // }
  ngOnInit() {
    this.http.getPrices().subscribe(result => {
      this.roles = result as Role[];
    });
    this.role = this.auth.getUserRole()
  }

  buySubscription(id: number) {
    this.http.buySubscription(id).subscribe(result => {
      localStorage.setItem('token', result.token);
    });
    this.continue();
  }

  continue() {
    this.router.navigate(['/posts']);
  }
}

export interface Role {
  name: string;
  price: number;
}
