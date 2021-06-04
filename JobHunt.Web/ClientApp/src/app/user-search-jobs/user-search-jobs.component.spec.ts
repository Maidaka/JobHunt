import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserSearchJobsComponent } from './user-search-jobs.component';

describe('UserSearchJobsComponent', () => {
  let component: UserSearchJobsComponent;
  let fixture: ComponentFixture<UserSearchJobsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserSearchJobsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserSearchJobsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
