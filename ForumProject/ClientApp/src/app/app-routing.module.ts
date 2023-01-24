import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizeGuard } from '../api-authorization/authorize.guard';
import { TokenComponent } from './token/token.component';
import { ForumWrapperComponent } from './forum/forum-wrapper/forum-wrapper.component';
import { ForumTopicsListComponent } from './forum/forum-content/forum-topics-list/forum-topics-list.component';
import { ForumAddTopicComponent } from './forum/forum-content/forum-add-topic/forum-add-topic.component';
import { TopicWithRepliesComponent } from './forum/forum-content/topic-with-replies/topic-with-replies.component';
import { ForumAddReplyComponent } from './forum/forum-content/forum-add-reply/forum-add-reply.component';

export const routes: Routes = [
  { path: '', component: ForumWrapperComponent, pathMatch: 'full', canActivate: [AuthorizeGuard] },
  { path: 'forum', component: ForumWrapperComponent, canActivate: [AuthorizeGuard] },
  { path: 'forumTopics/:sectionId', component: ForumTopicsListComponent, canActivate: [AuthorizeGuard] },
  { path: 'forumTopics/:sectionId/forumTopicsWithReplies/:topicId', component: TopicWithRepliesComponent, canActivate: [AuthorizeGuard] },
  { path: 'forumTopics/:sectionId/forumTopicsWithReplies/:topicId/forumAddReply', component: ForumAddReplyComponent, canActivate: [AuthorizeGuard] },
  { path: 'forumTopics/:sectionId/forumAddTopic', component: ForumAddTopicComponent, canActivate: [AuthorizeGuard] },
  { path: 'token', component: TokenComponent, canActivate: [AuthorizeGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
