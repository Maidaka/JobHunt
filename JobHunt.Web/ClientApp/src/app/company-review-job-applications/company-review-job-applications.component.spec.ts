import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyReviewJobApplicationsComponent } from './company-review-job-applications.component';

describe('CompanyReviewJobApplicationsComponent', () => {
  let component: CompanyReviewJobApplicationsComponent;
  let fixture: ComponentFixture<CompanyReviewJobApplicationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompanyReviewJobApplicationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompanyReviewJobApplicationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
