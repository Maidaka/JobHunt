import { Component, OnInit } from '@angular/core';
import { CompanyJobApplications } from '../models/company-job-application';
import { AuthService } from '../services/auth.service';
import { JobService } from '../services/job.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit {

  jobApplications: CompanyJobApplications[];

  constructor(
    private authService: AuthService,
    private jobService: JobService) { }

  ngOnInit() {
    this.authService.checkIfUserIsLoggedIn();
    this.getUserJobApplications();
  }

  private getUserJobApplications = () => {
    this.jobService.getUserJobApplications(this.authService.getUserData().id)
      .subscribe(resp => {
        this.jobApplications = resp.jobApplications;
      })
  }

  printJobApplicationStatus = (jobApplicationStatus: number) => {
    if (jobApplicationStatus == 1) return "Submitted";
    if (jobApplicationStatus == 2) return "Approved";
    if (jobApplicationStatus == 3) return "Declined";
  }

  getJobApplicationStatusLabel = (status: number) => {
    if (status == 1) return "submitted-label";
    if (status == 2) return "approved-label";
    if (status == 3) return "declined-label";
  }
}
