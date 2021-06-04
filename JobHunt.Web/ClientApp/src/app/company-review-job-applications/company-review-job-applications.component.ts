import { Component, OnInit } from '@angular/core';
import { CompanyJobApplications } from '../models/company-job-application';
import { User } from '../models/user';
import { AuthService } from '../services/auth.service';
import { JobService } from '../services/job.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-company-review-job-applications',
  templateUrl: './company-review-job-applications.component.html',
  styleUrls: ['./company-review-job-applications.component.css']
})
export class CompanyReviewJobApplicationsComponent implements OnInit {

  jobApplications: CompanyJobApplications[];

  constructor(
    private authService: AuthService,
    private jobService: JobService,
    private userService: UserService) { }

  ngOnInit() {
    this.authService.checkIfCompanyIsLoggedIn();
    this.getCompanyJobApplications();
  }

  private getCompanyJobApplications = () => {
    this.jobService.getCompanyJobApplications(this.authService.getCompanyData().id)
      .subscribe(resp => {
        this.jobApplications = resp.jobApplications;
        
        this.fetchUserData();

      })
  }

  private fetchUserData = () => {
    for (let i = 0; i < this.jobApplications.length; i ++) {
      this.userService.getUserData(this.jobApplications[i].userId)
        .subscribe(resp => {
          for (let j = 0; j < this.jobApplications.length; j ++) {
            if (this.jobApplications[j].userId == resp.id) {
              this.jobApplications[j].user = resp;
            }
          }
        })
    }
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

  approveJobApplication = (jobApplicationId: number) => {
    this.jobService.approveJobApplication(jobApplicationId)
      .subscribe(resp => {
        // refresh job applications
        this.getCompanyJobApplications();
      })
  }

  declineJobApplication = (jobApplicationId: number) => {
    this.jobService.declineJobApplication(jobApplicationId)
      .subscribe(resp => {
        // refresh job applications
        this.getCompanyJobApplications();
      })
  }
}
