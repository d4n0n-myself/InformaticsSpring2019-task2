import {Component, OnInit} from '@angular/core';
import {Comment, HttpService, Post} from "../services/httpService/http.service";
import {AuthenticationService} from "../services/authentication/authentication.service";
import {DomSanitizer, SafeResourceUrl} from '@angular/platform-browser';
import {Router} from "@angular/router";

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrls: ['./single-post.component.css']
})
export class SinglePostComponent implements OnInit {

  constructor(private httpService: HttpService, private auth: AuthenticationService, private _sanitizer: DomSanitizer, private router: Router) {
  }

  post: Post;

  commentText: string;

  role: string;

  safeUrl: SafeResourceUrl;

  comments: Array<Comment>;


  addComment() {
    this.httpService.addComment(this.commentText, this.post.id);
  }

  ngOnInit() {
    this.httpService.getPost(localStorage.getItem('post')).subscribe(result => {
      this.post = result;
      this.safeUrl = this._sanitizer.bypassSecurityTrustResourceUrl(this.post.videoUrl);
      this.httpService.getCommentsForPost(this.post.id).subscribe(result => {
        this.comments = result as Comment[];
      });
    });
    this.role = this.auth.getUserRole();
  }

  deletePost() {
    this.httpService.deletePost(this.post.title);
    location.replace('/posts')
  }
}
