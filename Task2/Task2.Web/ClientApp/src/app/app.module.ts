import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import {JwtHelperService, JwtModule} from "@auth0/angular-jwt";
import {routes} from "./app.routes";
import {LoginComponent} from "./login/login.component";
import {AuthGuardService} from "./services/authGuard/auth-guard.service";
import {AuthenticationService} from "./services/authentication/authentication.service";
import {SinglePostComponent} from "./single-post/single-post.component";
import {PostsListComponent} from "./posts-list/posts-list.component";
import {AddPostComponent} from "./add-post/add-post.component";
import {HomeLayoutComponent} from "./home-layout/home-layout.component";
import {LoginLayoutComponent} from "./login-layout/login-layout.component";
import {RegisterComponent} from "./register/register.component";
import { BuySubscriptionComponent } from './buy-subscription/buy-subscription.component';
import {RepliesComponent} from "./replies/replies.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    SinglePostComponent,
    PostsListComponent,
    AddPostComponent,
    HomeLayoutComponent,
    LoginLayoutComponent,
    RegisterComponent,
    BuySubscriptionComponent,
    RepliesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes),
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return 'getToken';
        }
      }
    }),
  ],
  providers: [ AuthGuardService, AuthenticationService, JwtHelperService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
