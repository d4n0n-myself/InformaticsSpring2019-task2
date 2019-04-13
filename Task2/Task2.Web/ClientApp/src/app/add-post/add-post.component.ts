import { Component, OnInit } from '@angular/core';
import {HttpService} from "../services/httpService/http.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit {

  constructor(private http:HttpService, public router: Router) { }

  ngOnInit() {
  }

  title:string;
  video:string;
  file:string;

  Add()
  {
    this.http.addPost(this.title, this.video, this.file);
    this.router.navigate(["/posts"])
  }
}
