import {Component, OnInit} from '@angular/core';
import {Genre, HttpService, Post} from "../services/httpService/http.service";
import {Router} from "@angular/router";
import {DelayService} from "../services/delay/delay.service";

declare var $: any;

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.css']
})
export class PostsListComponent implements OnInit {

  constructor(private httpService: HttpService, public router: Router, private delay: DelayService) {
    this.getSelected();
  }

  genres = [

    {
      name: 'Rock',
      genre: Genre.Rock,
      id: 1,
      selected: false
    },
    {
      name: 'Jazz',
      genre: Genre.Jazz,
      id: 2,
      selected: false
    },
    {
      name: 'Blues',
      genre: Genre.Blues,
      id: 3,
      selected: false
    },
    {
      name: 'HeavyMetal',
      genre: Genre.HeavyMetal,
      id: 4,
      selected: false
    },
    {
      name: 'Indy',
      genre: Genre.Indy,
      id: 5,
      selected: false
    },
    {
      name: 'Other',
      genre: Genre.Other,
      id: 6,
      selected: false
    }
  ];


  name: string;
  searchText: string = "";
  searchTextt: string = "";
  selected_count: number = 0;
  selected_genres = this.genres;

  all_posts = new Array<Post>();

  posts = new Array<Post>().map(item => item);

  async ngOnInit() {
    console.log('receiving posts...');

    await this.httpService.getPosts().subscribe(result => {
      this.all_posts = result as Post[];
      this.posts = this.all_posts;
    });

    await this.delay.delay(150);
  }

  goToPost(title: string) {
    localStorage.setItem('post', title);
    this.router.navigate(['/single']);
  }

  genre(num: number) {
    return Genre[num];
  }

  // Getting Selected Games and Count
  getSelected() {
    this.selected_genres = this.genres.filter(s => {
      return s.selected;
    });

    if (this.selected_genres.length > 0) {
      this.posts = this.all_posts.filter(p =>
        this.genre(p.genre) === this.selected_genres.filter(g => g.selected === true).pop().name);
    }

    if (this.selected_genres.length === 0)
      this.posts = this.all_posts;
  }

  //Clear term types by user
  clearFilter() {
    this.searchText = "";
    this.searchTextt = "";
  }

  showAllPosts() {
    this.posts = this.all_posts;
  }
}
