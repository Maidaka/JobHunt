import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { JobService } from '../services/job.service';

@Component({
  selector: 'app-company-post-new-job',
  templateUrl: './company-post-new-job.component.html',
  styleUrls: ['./company-post-new-job.component.css']
})
export class CompanyPostNewJobComponent implements OnInit {

  jobTitle: string;
  jobDescription: string;
  creationSuccessful: boolean = false;

  constructor(
    private authService: AuthService,
    private router: Router,
    private jobService: JobService) { }

  ngOnInit() {
    this.authService.checkIfCompanyIsLoggedIn();
  }

  postNewJob = () => {
    this.jobService.postNewJob(this.jobTitle, this.jobDescription, this.authService.getCompanyData().id)
      .subscribe(resp => this.creationSuccessful = true);
  }

  goToDashboard = () => {
    this.router.navigateByUrl("company/dashboard");
  }
}
