import { Component, OnInit } from '@angular/core';
import {HttpService, Post} from "../services/httpService/http.service";
import {Router} from "@angular/router";
import {DelayService} from "../services/delay/delay.service";

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.css']
})
export class PostsListComponent implements OnInit {

  constructor(private httpService: HttpService, public router: Router, private delay : DelayService) {}

  posts = new Array<Post>();

  ngOnInit() {
    console.log('receiving posts...')
    this.httpService.getPosts().subscribe(result => {
      this.posts = result;
    });
    this.delay.delay(150);
  }




  goToPost(title : string) {
    localStorage.setItem('post', title);
    this.router.navigate(['/single']);
  }
}
