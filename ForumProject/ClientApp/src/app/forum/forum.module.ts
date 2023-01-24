import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ForumWrapperComponent } from './forum-wrapper/forum-wrapper.component';
import { ForumSectionComponent } from './forum-content/forum-section/forum-section.component';
import { ForumTopicComponent } from './forum-content/forum-topic/forum-topic.component';
import { ForumReplyComponent } from './forum-content/forum-reply/forum-reply.component';
import { ForumTopicsListComponent } from './forum-content/forum-topics-list/forum-topics-list.component';
import { RouterModule } from '@angular/router';
import { ForumAddTopicComponent } from './forum-content/forum-add-topic/forum-add-topic.component';
import { FormsModule } from '@angular/forms';
import { PaginationDirective } from '../common/pagination-directive';
import { TopicWithRepliesComponent } from './forum-content/topic-with-replies/topic-with-replies.component';
import { ForumAddReplyComponent } from './forum-content/forum-add-reply/forum-add-reply.component';



@NgModule({
  declarations: [
    ForumWrapperComponent,
    ForumSectionComponent,
    ForumTopicComponent,
    ForumReplyComponent,
    ForumTopicsListComponent,
    ForumAddTopicComponent,
    PaginationDirective,
    TopicWithRepliesComponent,
    ForumAddReplyComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ]
})
export class ForumModule { }
