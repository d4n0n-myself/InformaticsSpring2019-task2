import { Injectable, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import {Observable} from "rxjs";
import {WeatherForecast} from "../../fetch-data/fetch-data.component";

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  httpOptions = {headers: {'Authorization': localStorage.getItem('token')}};

  getPosts() : Observable<Post[]> {
    return this.http.get<Post[]>(`${this.baseUrl}Post/Get`, this.httpOptions);
  }

  logIn(username: string, password: string) {
    let url = `${this.baseUrl}Token/GetToken?username=${username}&password=${password}`;
    return this.http.get<LoginModel>(url).subscribe(result => {
      localStorage.setItem('token', result.token);
    })
  }

  getForecast(): Observable<WeatherForecast[]> {
    let url = `${this.baseUrl}SampleData/WeatherForecasts`;
    return this.http.get<WeatherForecast[]>(url, this.httpOptions)
  }
}

interface LoginModel {
  token: string;
}

export interface Post {
  id: string,
  title: string,
  videoUrl: string,
  fileLink: string
}
