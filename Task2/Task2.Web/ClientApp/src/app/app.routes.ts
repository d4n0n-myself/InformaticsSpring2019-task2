import {HomeComponent} from "./home/home.component";
import {CounterComponent} from "./counter/counter.component";
import {FetchDataComponent} from "./fetch-data/fetch-data.component";
import {LoginComponent} from "./login/login.component";
import {AuthGuardService} from "./services/authGuard/auth-guard.service";
import {SinglePostComponent} from "./single-post/single-post.component";
import {PostsListComponent} from "./posts-list/posts-list.component";
import {HomeLayoutComponent} from "./home-layout/home-layout.component";
import {LoginLayoutComponent} from "./login-layout/login-layout.component";
import {RegisterComponent} from "./register/register.component";
import {AddPostComponent} from "./add-post/add-post.component";

export const routes = [
  {
    path: '', component: HomeLayoutComponent, canActivate: [AuthGuardService], children: [
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'counter', component: CounterComponent},
      {path: 'fetch-data', component: FetchDataComponent,},
      {path: 'single', component: SinglePostComponent},
      {path: 'posts', component: PostsListComponent},
      {path:'add-post',component:AddPostComponent}
    ]
  },
  {
    path: '', component: LoginLayoutComponent, children: [
      {path: 'login', component: LoginComponent},
      {path: 'register', component: RegisterComponent}
    ]
  }
];
