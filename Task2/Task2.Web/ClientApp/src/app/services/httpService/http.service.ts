import {Injectable, Inject} from '@angular/core'
import {HttpClient} from '@angular/common/http'
import {Observable} from "rxjs";
import {Role} from "../../buy-subscription/buy-subscription.component";
import {DelayService} from "../delay/delay.service";

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private delay: DelayService) {
    this.baseUrl = baseUrl;
  }

  receivedPosts = new Array<Post>();
  httpOptions = {headers: {'Authorization': localStorage.getItem('token')}};

  addComment(text: string, postId: string) {
    var url = `${this.baseUrl}Comment/Add?text=${text}&postId=${postId}`;
    this.http.post(url, null, this.httpOptions).subscribe(result => {
    });
  }

  addPost(title: string, genre: string, performer: string, video: string, file: string) {
    var url = `${this.baseUrl}Post/Add?fileLink=${file}&video=${video}&title=${title}&genre=${genre}&performer=${performer}`;
    this.http.post(url, null, this.httpOptions).subscribe(() => {

    }, error => {
      alert(error.message)
    })
  }

  buySubscription(newRole: number): Observable<LoginModel> {
    let url = `${this.baseUrl}User/ChangeRole?userLogin=${localStorage.getItem('user')}&newRole=${newRole}`;
    return this.http.post<LoginModel>(url, null, this.httpOptions);
  }

  deletePost(postTitle: string) {
    this.http.post(`${this.baseUrl}Post/Delete?title=${postTitle}`, null, this.httpOptions).subscribe(result => {
    });
  }

  getComments(): Observable<Comment[]> {
    return this.http.get<Comment[]>(`${this.baseUrl}Comment/GetAll`, this.httpOptions);
  }

  getCommentsForPost(postId: string): Observable<Comment[]> {
    let url = `${this.baseUrl}Comment/Get?postId=${postId}`;
    return this.http.get<Comment[]>(url, this.httpOptions)
  }

  getPost(title: string): Observable<Post> {
    let url = `${this.baseUrl}Post/GetPost?title=${title}`;
    return this.http.get<Post>(url, this.httpOptions);
  }

  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(`${this.baseUrl}Post/Get`, this.httpOptions);
  }

  getPrices(): Observable<Role[]> {
    return this.http.get<Role[]>('url', this.httpOptions);
  }

  logIn(username: string, password: string) {
    let url = `${this.baseUrl}Token/Login?username=${username}&password=${password}`;
    this.http.get<LoginModel>(url).subscribe(result => {
      let model: LoginModel = result;
      localStorage.setItem('token', model.token);
      localStorage.setItem('user', model.login);
    }, error => {
      alert('Invalid credentials');
      console.log(error.error);
    });
  }

  register(username: string, password: string) {
    let url = `${this.baseUrl}Token/Register?username=${username}&password=${password}`;
    return this.http.post<LoginModel>(url, null).subscribe(result => {
      localStorage.setItem('token', result.token);
      localStorage.setItem('user', result.login);
    }, error => {
      alert('Failed to register a new user!');
      console.log(error.error);
    })
  }
}

export interface LoginModel {
  token: string;
  login: string;
}

export interface Post {
  id: string;
  title: string;
  videoUrl: string;
  fileLink: string;
  performer: string;
  genre: Genre;
}

export interface Comment {
  userLogin: string,
  text: string
}

export enum Genre {
  Rock = 1,
  Jazz = 2,
  Blues = 3,
  HeavyMetal = 4,
  Indy = 5,
  Other = 6
}
