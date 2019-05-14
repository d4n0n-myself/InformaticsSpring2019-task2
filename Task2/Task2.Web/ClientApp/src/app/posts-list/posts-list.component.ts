import {Component, OnInit} from '@angular/core';
import {Genre, HttpService, Post} from "../services/httpService/http.service";
import {Router} from "@angular/router";
import {DelayService} from "../services/delay/delay.service";
// import $ from "jquery";
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

  //this.all_posts.filter(p => this.genre(p.genre)===this.selected_genres.filter(g=>g.selected===true).pop().name );

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
  searchTextt: string ="";
  selected_count: number = 0;
  selected_genres = this.genres;

  // Data Object to List Games
  // games = [
  //   {
  //     name: 'Chess',
  //     id: 1,
  //     selected: true
  //   },
  //   {
  //     name: 'Ludo',
  //     id: 2,
  //     selected: false
  //   },
  //   {
  //     name: 'Snakes & Ladders',
  //     id: 3,
  //     selected: false
  //   },
  //   {
  //     name: 'Carrom',
  //     id: 4,
  //     selected: false
  //   },
  //   {
  //     name: 'Scrabble',
  //     id: 5,
  //     selected: false
  //   },
  //   {
  //     name: 'Monopoly',
  //     id: 6,
  //     selected: true
  //   },
  //   {
  //     name: 'Uno',
  //     id: 7,
  //     selected: false
  //   }
  // ];

  all_posts = new Array<Post>();

  posts = new Array<Post>().map(item => item);

  async ngOnInit() {
    console.log('receiving posts...');

    await this.httpService.getPosts().subscribe(result => {
      this.all_posts = result as Post[];
      this.posts = this.all_posts;
      // this.getSelected();
        // (result as Post[]).filter(p => this.genre(p.genre)===this.genres.filter(g=>g.selected===true).pop().name )
        // this.all_posts.filter(p => this.genre(p.genre)===this.selected_genres.filter(g=>g.selected===true).pop().name )

    });

    await this.delay.delay(150);
  }

  goToPost(title: string) {
    localStorage.setItem('post', title);
    this.router.navigate(['/single']);
  }

  genre(num : number) {
    return Genre[num];
  }

  // Getting Selected Games and Count
  getSelected() {


    this.selected_genres = this.genres.filter(s => {
      return s.selected;
    });
    // $('input.example').on('change', function() {
    //   $('input.example').not(this).prop('checked', false);
    // });
    // this.selected_count = this.selected_genres.length;

    // else if (this.selected_genres.some(g=>g.name==="All"))
    // {
    //   this.posts = this.all_posts;
    //   this.genres = this.genres.filter(g => {
    //          g.selected = true;
    //          return true;
    //        });
    //   this.selected_genres = this.genres.filter(g => {
    //     g.selected = true;
    //     return true;
    //   });
    // }
    if (this.selected_genres.length>0)
    {
      this.posts=this.all_posts.filter(p => this.genre(p.genre)===this.selected_genres.filter(g=>g.selected===true).pop().name );

      // this.selected_genres.forEach(value => this.posts.concat(this.all_posts.filter(p=>this.genre(p.genre)===value.name)));
      // for (let i=0; i<this.selected_genres.length; i++)
      // {
      //   this.posts.concat(this.all_posts.filter(p=>this.genre(p.genre)===this.selected_genres[i].name)
      //   )
      // }
    }


    // this.posts =
      //   // (result as Post[]).filter(p => this.genre(p.genre)===this.genres.filter(g=>g.selected===true).pop().name )
      //   this.all_posts.filter(p => this.genre(p.genre)===this.genres.filter(g=>g.selected===true).pop().name )



    if (this.selected_genres.length === 0)
      this.posts = new Array<Post>();
    //alert(this.selected_games);

      // this.posts = this.posts.filter(p => {
      //   return this.selected_games.filter(g=>{return g.genre===p.genre});});

  }

  // Clearing All Selections
  // clearSelection() {
  //   this.searchText = "";
  //   this.genres = this.genres.filter(g => {
  //     g.selected = false;
  //     return true;
  //   });
  //   // this.getSelected();
  //   this.posts= new Array<Post>();
  //   this.getSelected()
  // }

  //Delete Single Listed Game Tag
  deleteGame(id: number) {
    this.searchText = "";
    this.searchTextt = "";
    this.genres = this.genres.filter(g => {
      if (g.id == id)
        g.selected = false;

      return true;
    });
    this.getSelected();

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
