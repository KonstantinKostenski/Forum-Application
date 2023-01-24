import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin, merge, mergeAll, mergeMap, mergeWith, pipe, switchMap } from 'rxjs';
import { PaginatedList } from '../../../models/common/PaginatedList';
import { Reply } from '../../../models/reply/Reply';
import { Topic } from '../../../models/topic/Topic';
import { ForumServiceService } from '../../forum-service.service';

@Component({
  selector: 'app-topic-with-replies',
  templateUrl: './topic-with-replies.component.html',
  styleUrls: ['./topic-with-replies.component.css']
})
export class TopicWithRepliesComponent implements OnInit {
  replies: PaginatedList<Reply>;
  topicId: number;
  topic: Topic;
  pageNumber: number = 1;

  constructor(private route: ActivatedRoute, private forumService: ForumServiceService, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      debugger;
      this.topicId = +params['topicId'];
      forkJoin(this.forumService.getTopicById(this.topicId), this.forumService.getTopicRepliesPaginated(this.topicId, this.pageNumber)).subscribe((value) => {
        debugger;

        this.topic = value[0]; this.replies = value[1];
      })
    });
    
  }

  onPageChange(pageNumber: number) {
    debugger;
    this.pageNumber = pageNumber;
    this.forumService.getTopicRepliesPaginated(this.topicId, this.pageNumber).subscribe(result => {
      this.replies = result;
    });
  }

  replyToTopic() {
    this.router.navigate(['forumAddReply'], { relativeTo: this.route });
  }

  deleteReply(id: number) {

    this.forumService.deleteReply(id)
      .pipe(switchMap(result =>
      {
        debugger;
        return this.forumService.getTopicRepliesPaginated(this.topicId, this.pageNumber);
      }))
      .subscribe(result => {
      debugger;
      this.replies = result;
    });
  }
}
