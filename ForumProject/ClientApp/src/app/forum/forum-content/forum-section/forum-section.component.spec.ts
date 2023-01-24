import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumSectionComponent } from './forum-section.component';

describe('ForumSectionComponent', () => {
  let component: ForumSectionComponent;
  let fixture: ComponentFixture<ForumSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForumSectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ForumSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
