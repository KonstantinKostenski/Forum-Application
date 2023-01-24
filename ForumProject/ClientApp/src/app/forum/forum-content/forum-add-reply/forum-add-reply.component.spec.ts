import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumAddReplyComponent } from './forum-add-reply.component';

describe('ForumAddReplyComponent', () => {
  let component: ForumAddReplyComponent;
  let fixture: ComponentFixture<ForumAddReplyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForumAddReplyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ForumAddReplyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
