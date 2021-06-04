import { Component, OnInit } from '@angular/core';
import { CompanyJob } from '../models/company-job';
import { CompanyJobApplications } from '../models/company-job-application';
import { AuthService } from '../services/auth.service';
import { JobService } from '../services/job.service';

@Component({
  selector: 'app-user-search-jobs',
  templateUrl: './user-search-jobs.component.html',
  styleUrls: ['./user-search-jobs.component.css']
})
export class UserSearchJobsComponent implements OnInit {

  filteredCompanyJobs: CompanyJob[];
  jobs: CompanyJob[];

  constructor(
    private authService: AuthService,
    private jobService: JobService
  ) { }

  ngOnInit() {
    this.authService.checkIfUserIsLoggedIn();
    this.searchJobs();
  }

  private searchJobs = () => {
    this.jobService.searchJobs(this.authService.getUserData().id)
      .subscribe(resp => {
        this.jobs = resp.jobs;
        this.filteredCompanyJobs = this.jobs;
      })
  }

  printJobStatus = (jobStatus: number) => {
    if (jobStatus == 1) return "Open";
    if (jobStatus == 2) return "Closed";
  }

  onSearchKeywordsChange = (newSearchKeywords: string) => {
    if (!newSearchKeywords || !this.jobs || this.jobs.length == 0) {
      this.filteredCompanyJobs = this.jobs;
      return;
    }

    let keywords = newSearchKeywords.split(' ');
    let newFilteredJobs: CompanyJob[] = [];

    for (let i = 0; i < this.jobs.length; i ++) {
      let job = this.jobs[i];
      let jobTitleKeywords = job.title.split(' ');
      let jobDescriptionKeywords = job.description.split(' ');

      for (let j = 0; j < keywords.length; j ++) {
        if (jobTitleKeywords.find(x => x.toLowerCase() == keywords[j].toLowerCase())) {
          newFilteredJobs.push(job);
        }
        else if (jobDescriptionKeywords.find(x => x.toLowerCase() == keywords[j].toLowerCase())) {
          newFilteredJobs.push(job);
        }
      }
    }

    this.filteredCompanyJobs = newFilteredJobs;
  }

  submitJobApplication = (jobId: number) => {
    this.jobService.createNewJobApplication(this.authService.getUserData().id, jobId)
      .subscribe(resp => {
        this.filteredCompanyJobs.find(x => x.id == jobId).hasUserApplied = true;
      })
  }
}
