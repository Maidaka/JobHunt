import { User } from "./user";

export class CompanyJobApplications {
    id: number;
    userId: number;
    userFullName: string;
    jobId: number;
    jobTitle: string;
    jobDescription: string;
    companyName: string;
    status: number;

    user: User;
}