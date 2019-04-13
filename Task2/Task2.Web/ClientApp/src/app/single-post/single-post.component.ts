import {Component, Input, OnInit} from '@angular/core';
import {HttpService, Post} from "../services/httpService/http.service";

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrls: ['./single-post.component.css']
})
export class SinglePostComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  post = new Post();

  ngOnInit() {
    this.httpService.getPost(localStorage.getItem('post')).subscribe(result => {
      this.post = result;
    });
  }
}
