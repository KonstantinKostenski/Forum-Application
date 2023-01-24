import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopicWithRepliesComponent } from './topic-with-replies.component';

describe('TopicWithRepliesComponent', () => {
  let component: TopicWithRepliesComponent;
  let fixture: ComponentFixture<TopicWithRepliesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopicWithRepliesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopicWithRepliesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
