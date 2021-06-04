import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from '../models/company';
import { GetCompanyJobApplicationsResponse } from '../models/responses/get-company-job-applications-response';
import { GetCompanyJobsResponse } from '../models/responses/get-company-jobs-response';
import { SearchJobResponse } from '../models/responses/search-job-response';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private _baseApiUrl = "https://localhost:44379";

  constructor(private http: HttpClient) { }

  searchJobs = (userId: number) => {
    return this.http
      .get<SearchJobResponse>(this._baseApiUrl + "/api/job/search/" + userId);
  }

  postNewJob = (title: string, description: string, companyId: number) => {
    var request = {
      "title": title,
      "description": description,
      "companyId": companyId
    };

    return this.http
      .post(this._baseApiUrl + "/api/job", request);
  }

  getCompanyJobs = (companyId: number) => {
    return this.http
      .get<GetCompanyJobsResponse>(this._baseApiUrl + "/api/job/company/" + companyId);
  }

  getCompanyJobApplications = (companyId: number) => {
    return this.http
      .get<GetCompanyJobApplicationsResponse>(this._baseApiUrl + "/api/job/jobapplication/" + companyId);
  }

  getUserJobApplications = (userId: number) => {
    return this.http
      .get<GetCompanyJobApplicationsResponse>(this._baseApiUrl + "/api/job/jobapplication/user/" + userId);
  }

  createNewJobApplication = (userId: number, jobId: number) => {
    var request = {
      "userId": userId,
      "jobId": jobId
    }

    return this.http
      .post(this._baseApiUrl + "/api/job/jobapplication", request);
  }

  closeJob = (jobId: number) => {
    return this.http
      .get(this._baseApiUrl + "/api/job/" + jobId + "/close");
  }

  approveJobApplication = (jobApplicationId: number) => {
    return this.http
      .get(this._baseApiUrl + "/api/job/jobapplication/" + jobApplicationId + "/approve");
  }

  declineJobApplication = (jobApplicationId: number) => {
    return this.http
      .get(this._baseApiUrl + "/api/job/jobapplication/" + jobApplicationId + "/decline");
  }
}
