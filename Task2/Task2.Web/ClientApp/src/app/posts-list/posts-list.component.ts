import { Component, OnInit } from '@angular/core';
import {HttpService, Post} from "../services/httpService/http.service";
import {Local} from "protractor/built/driverProviders";
import {Router} from "@angular/router";

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.css']
})
export class PostsListComponent implements OnInit {

  constructor(private httpService: HttpService, public router: Router) { }

   posts = new Array<Post>();
  // posts = [
  //   { title: 'Mr. Nice', videoUrl: 'https://www.youtube.com/watch?v=iAC1_a924H8', fileLink:'gfvdgfv' },
  //   { title: 'Nardhschsdvhcvdshvdshvco' },
  //   { title: 'Mr. Nice' },
  //   { title: 'Ndbvsgdvshvdhsarco' },
  //   { title: 'Mr. Nice' },
  //   { title: 'Nvdchvshvshcvdharco' },
  //   { title: 'Mr. Nice' },
  //   { title: 'Narhdchdsvchsvco' }
  // ];

  ngOnInit() {
    this.httpService.getPosts().subscribe(result => {
      this.posts = result;
    });
  }

  goToPost(title: string) {
    localStorage.setItem('post', title);
    this.router.navigate(['/single']);
  }
}
