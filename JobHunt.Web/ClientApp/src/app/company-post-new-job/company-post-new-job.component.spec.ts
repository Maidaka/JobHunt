import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyPostNewJobComponent } from './company-post-new-job.component';

describe('CompanyPostNewJobComponent', () => {
  let component: CompanyPostNewJobComponent;
  let fixture: ComponentFixture<CompanyPostNewJobComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompanyPostNewJobComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompanyPostNewJobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
