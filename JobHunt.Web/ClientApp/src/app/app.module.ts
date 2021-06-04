import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LoginComponent } from './login/login.component';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { RegistrationComponent } from './registration/registration.component';
import { CompanyDashboardComponent } from './company-dashboard/company-dashboard.component';
import { CompanyPostNewJobComponent } from './company-post-new-job/company-post-new-job.component';
import { CompanyReviewJobApplicationsComponent } from './company-review-job-applications/company-review-job-applications.component';
import { UserSearchJobsComponent } from './user-search-jobs/user-search-jobs.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    UserDashboardComponent,
    RegistrationComponent,
    CompanyDashboardComponent,
    CompanyPostNewJobComponent,
    CompanyReviewJobApplicationsComponent,
    UserSearchJobsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'user/dashboard', component: UserDashboardComponent },
      { path: 'user/searchjobs', component: UserSearchJobsComponent },
      { path: 'company/dashboard', component: CompanyDashboardComponent },
      { path: 'company/newjob', component: CompanyPostNewJobComponent },
      { path: 'company/reviewjobapplications', component: CompanyReviewJobApplicationsComponent },
      { path: 'register', component: RegistrationComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
