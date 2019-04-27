import {LoginComponent} from "./login/login.component";
import {AuthGuardService} from "./services/authGuard/auth-guard.service";
import {SinglePostComponent} from "./single-post/single-post.component";
import {PostsListComponent} from "./posts-list/posts-list.component";
import {HomeLayoutComponent} from "./home-layout/home-layout.component";
import {LoginLayoutComponent} from "./login-layout/login-layout.component";
import {RegisterComponent} from "./register/register.component";
import {AddPostComponent} from "./add-post/add-post.component";
import {BuySubscriptionComponent} from "./buy-subscription/buy-subscription.component";

export const routes = [
  {
    path: '', component: HomeLayoutComponent, canActivate: [AuthGuardService], children: [
      {path: '', pathMatch: 'full', redirectTo: '/posts'},
      {path: 'single', component: SinglePostComponent},
      {path: 'posts', component: PostsListComponent},
      {path: 'add-post', component: AddPostComponent},
      {path: 'subscribe', component: BuySubscriptionComponent}
    ]
  },
  {
    path: '', component: LoginLayoutComponent, children: [
      {path: 'login', component: LoginComponent},
      {path: 'register', component: RegisterComponent},
      {path: 'choose-subscription', component: BuySubscriptionComponent}
    ]
  }
];
