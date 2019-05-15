import {Injectable} from '@angular/core';
import {JwtHelperService} from "@auth0/angular-jwt";

@Injectable()
export class AuthenticationService {
  constructor(public jwtHelper: JwtHelperService) {
    this.jwtHelper = jwtHelper;
  }

  redirectUrl: string;

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  public getUserRole(): string {
    const token = localStorage.getItem('token');
    let decodedToken = this.jwtHelper.decodeToken(token);
    return decodedToken['Role'];
  }
}
