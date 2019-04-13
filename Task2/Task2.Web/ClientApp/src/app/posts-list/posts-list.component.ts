import { Component, OnInit } from '@angular/core';
import {HttpService, Post} from "../services/httpService/http.service";
import {Local} from "protractor/built/driverProviders";
import {Router} from "@angular/router";

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.css']
})
export class PostsListComponent implements OnInit {

  constructor(private httpService: HttpService, public router: Router) { }

  posts = new Array<Post>();

  ngOnInit() {
    this.httpService.getPosts().subscribe(result => {
      this.posts = result;
    });
  }

  goToPost(title : string) {
    localStorage.setItem('post', title);
    this.router.navigate(['/single']);
  }
}
