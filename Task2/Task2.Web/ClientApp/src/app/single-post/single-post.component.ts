import {Component, OnInit} from '@angular/core';
import {HttpService, Post} from "../services/httpService/http.service";
import {AuthenticationService} from "../services/authentication/authentication.service";

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrls: ['./single-post.component.css']
})
export class SinglePostComponent implements OnInit {

  constructor(private httpService: HttpService, private auth:AuthenticationService) { }

  post : Post;

  commentText: string;

  addComment() {
    this.httpService.addComment(this.commentText);
  }
  ngOnInit() {
    this.httpService.getPost(localStorage.getItem('post')).subscribe(result => {
      this.post = result;
    });
    console.log(this.auth.getUserRole())
  }

  deletePost() {
    this.httpService.deletePost(this.post.title);
  }
}
