import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumAddTopicComponent } from './forum-add-topic.component';

describe('ForumAddTopicComponent', () => {
  let component: ForumAddTopicComponent;
  let fixture: ComponentFixture<ForumAddTopicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForumAddTopicComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ForumAddTopicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
