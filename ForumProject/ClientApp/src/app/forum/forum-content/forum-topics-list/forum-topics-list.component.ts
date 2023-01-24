import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PaginatedList } from '../../../models/common/PaginatedList';
import { Topic } from '../../../models/topic/Topic';
import { ForumServiceService } from '../../forum-service.service';

@Component({
  selector: 'app-forum-topics-list',
  templateUrl: './forum-topics-list.component.html',
  styleUrls: ['./forum-topics-list.component.css']
})
export class ForumTopicsListComponent implements OnInit {
  topics: PaginatedList<Topic>;
  sectionId: number;
  constructor(private route: ActivatedRoute, private forumService: ForumServiceService, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      debugger;
      this.sectionId = +params['sectionId'];
      this.forumService.getAllForumTopicsPerSectionPaginated(this.sectionId, 1).subscribe(result => {
        this.topics = result;
      });
    });
  }

  navigateToAddTopic() {
    this.router.navigate(['forumAddTopic'], { relativeTo: this.route });
  }

  onPageChange(pageNumber) {
    debugger;
    this.forumService.getAllForumTopicsPerSectionPaginated(this.sectionId, pageNumber).subscribe(result => {
      debugger;
      this.topics = result;
    });
  }

}
