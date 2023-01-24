import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Topic } from '../../../models/topic/Topic';
import { ForumServiceService } from '../../forum-service.service';

@Component({
  selector: 'app-forum-add-topic',
  templateUrl: './forum-add-topic.component.html',
  styleUrls: ['./forum-add-topic.component.css']
})
export class ForumAddTopicComponent implements OnInit {
  topic: Topic = new Topic();
  sectionId: number;
  constructor(private forumService: ForumServiceService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      debugger;
      this.sectionId = +params['sectionId'];
    });
  }

  onClickSubmit(value) {
    debugger;
    this.forumService.addTopic({ sectionId: this.sectionId, ...value }).subscribe(result => {
      debugger;
      this.router.navigateByUrl("forumTopics/" + this.sectionId);
    })
  }

}
