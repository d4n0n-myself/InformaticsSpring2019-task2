import {Component, OnInit} from '@angular/core';
import {AuthenticationService} from "../services/authentication/authentication.service";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  constructor(public auth: AuthenticationService) {
  }

  isExpanded = false;
  role: string;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  signOut() {
    localStorage.removeItem('token');
    location.reload();
  }

  ngOnInit(): void {
    this.role = this.auth.getUserRole();
  }
}
