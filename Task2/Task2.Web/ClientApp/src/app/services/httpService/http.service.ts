import { Injectable, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  httpOptions = {headers: {'Authorization': localStorage.getItem('token')}};

  addPost(title: string, video: string, file: string) {
    var url = `${this.baseUrl}Post/Add?fileLink=${file}&video=${video}&title=${title}`;
    this.http.post(url, null).subscribe();
  }

  getPost(title:string) : Observable<Post> {
    var url = `${this.baseUrl}Post/GetPost?title=${title}`;
    return this.http.get<Post>(url);
  }

  getPosts() : Observable<Post[]> {
    return this.http.get<Post[]>(`${this.baseUrl}Post/Get`, this.httpOptions);
  }

  logIn(username: string, password: string) : Observable<LoginModel> {
    let url = `${this.baseUrl}Token/Login?username=${username}&password=${password}`;
    return this.http.get<LoginModel>(url);
  }

  register(username: string, password: string) {
    let url = `${this.baseUrl}Token/Register?username=${username}&password=${password}`;
    return this.http.post<LoginModel>(url, null).subscribe(result => {
      localStorage.setItem('token', result.token);
    }, error => {
      console.log("errorr");
    })
  }
}

export interface LoginModel {
  token: string;
}

export class Post {
  constructor() {

  }

  id: string;
  title: string;
  videoUrl: string;
  fileLink: string
}
