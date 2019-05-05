import {Component, Input, OnInit} from '@angular/core';
import {HttpService, Post} from "../services/httpService/http.service";
import {DelayService} from "../services/delay/delay.service";

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrls: ['./single-post.component.css']
})
export class SinglePostComponent implements OnInit {

  constructor(private httpService: HttpService, private delay : DelayService) { }


  comment: string;
  post = new Post();
  comments = new Array<Comment>();

  ngOnInit() {
    this.httpService.getPost(localStorage.getItem('post')).subscribe(result => {
      this.post = result;
    });

    console.log('receiving comments...')
    this.httpService.getComments(this.post.id).subscribe(result => {
      this.comments = result;
    });
    this.delay.delay(150);

  }

  Add()
  {
    console.log(this.comment);
    this.httpService.addComment(this.comment, this.post.id);
  }
}
