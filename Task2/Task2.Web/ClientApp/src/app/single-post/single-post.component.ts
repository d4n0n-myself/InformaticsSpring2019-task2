import {HttpService, Post, PostComment} from "../services/httpService/http.service";
import {AuthenticationService} from "../services/authentication/authentication.service";
import {Component, OnInit} from "@angular/core";

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrls: ['./single-post.component.css']
})
export class SinglePostComponent implements OnInit {

  constructor(private httpService: HttpService, private auth:AuthenticationService) { }

  post : Post;
  comments : PostComment[];

  commentText: string;

  addComment() {
    this.httpService.addComment(this.commentText, this.post.id);
  }
  ngOnInit() {
    this.httpService.getPost(localStorage.getItem('post')).subscribe(result => {
      this.post = result;
    });
    this.httpService.getCommentsForPost(localStorage.getItem('post')).subscribe(result => {
      this.comments = result;
    })
  }

  deletePost() {
    this.httpService.deletePost(this.post.title);
  }
}
