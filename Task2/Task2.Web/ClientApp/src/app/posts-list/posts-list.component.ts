import { Component, OnInit } from '@angular/core';
import {HttpService, Post} from "../services/httpService/http.service";

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.css']
})
export class PostsListComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  posts = new Array<Post>();

  ngOnInit() {
    this.httpService.getPosts().subscribe(result => {
      this.posts = result;
    });
  }
}
