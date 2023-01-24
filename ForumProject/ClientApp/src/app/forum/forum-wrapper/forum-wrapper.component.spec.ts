import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumWrapperComponent } from './forum-wrapper.component';

describe('ForumWrapperComponent', () => {
  let component: ForumWrapperComponent;
  let fixture: ComponentFixture<ForumWrapperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForumWrapperComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ForumWrapperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
