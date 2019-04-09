import {HomeComponent} from "./home/home.component";
import {CounterComponent} from "./counter/counter.component";
import {FetchDataComponent} from "./fetch-data/fetch-data.component";
import {LoginComponent} from "./login/login.component";
import {AuthGuardService} from "./services/authGuard/auth-guard.service";
import {SinglePostComponent} from "./single-post/single-post.component";
import {PostsListComponent} from "./posts-list/posts-list.component";

export const routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: 'counter', component: CounterComponent, canActivate: [AuthGuardService]},
  {path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuardService]},
  {path: 'login', component: LoginComponent},
  {path: 'single', component: SinglePostComponent},
  {path: 'posts', component: PostsListComponent}
];
