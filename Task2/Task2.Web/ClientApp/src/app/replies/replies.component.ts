import {Component, OnInit} from "@angular/core";
import {HttpService} from "../services/httpService/http.service";
import {PostComment as Comment} from "../services/httpService/http.service";

@Component({
  selector: 'app-replies',
  templateUrl: './replies.component.html',
  styleUrls: ['./replies.component.css']
})
export class RepliesComponent implements OnInit {

  comments: Array<Comment>;

  constructor(private http: HttpService) {
  }

  ngOnInit() {
    this.http.getComments().subscribe(result => {
      this.comments = result as Comment[];
    });
  }
}
