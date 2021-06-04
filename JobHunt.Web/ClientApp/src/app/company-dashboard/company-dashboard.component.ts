import { Component, OnInit } from '@angular/core';
import { CompanyJob } from '../models/company-job';
import { AuthService } from '../services/auth.service';
import { JobService } from '../services/job.service';

@Component({
  selector: 'app-company-dashboard',
  templateUrl: './company-dashboard.component.html',
  styleUrls: ['./company-dashboard.component.css']
})
export class CompanyDashboardComponent implements OnInit {

  companyJobs: CompanyJob[];

  constructor(
    private authService: AuthService,
    private jobService: JobService) { }

  ngOnInit() {
    this.authService.checkIfCompanyIsLoggedIn();
    this.getCompanyJobs();
  }

  private getCompanyJobs = () => {
    this.jobService.getCompanyJobs(this.authService.getCompanyData().id)
      .subscribe(resp => {
        this.companyJobs = resp.jobs;
      });
  }

  printJobStatus = (jobStatus: number) => {
    if (jobStatus == 1) return "Open";
    if (jobStatus == 2) return "Closed";
  }

  closeJob = (jobId: number) => {
    this.jobService.closeJob(jobId)
      .subscribe(resp => {
        // refresh jobs after closing this job
        this.getCompanyJobs();
      });
  }
}
