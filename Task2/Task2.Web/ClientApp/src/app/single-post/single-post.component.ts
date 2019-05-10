import {Component, OnInit} from '@angular/core';
import {HttpService, Post} from "../services/httpService/http.service";
import {AuthenticationService} from "../services/authentication/authentication.service";
import {DomSanitizer, SafeResourceUrl} from '@angular/platform-browser';

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrls: ['./single-post.component.css']
})
export class SinglePostComponent implements OnInit {

  constructor(private httpService: HttpService, private auth:AuthenticationService, private _sanitizer: DomSanitizer) { }

  post : Post;

  commentText: string;

  safeUrl: SafeResourceUrl;

  addComment() {
    this.httpService.addComment(this.commentText);
  }
  ngOnInit() {
    this.httpService.getPost(localStorage.getItem('post')).subscribe(result => {
      this.post = result;
      this.safeUrl = this._sanitizer.bypassSecurityTrustResourceUrl(this.post.videoUrl)
    });
    console.log(this.auth.getUserRole())
  }

  deletePost() {
    this.httpService.deletePost(this.post.title);
  }
}
