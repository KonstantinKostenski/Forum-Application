import { Component, OnInit } from '@angular/core';
import { Section } from '../../models/section/Section';
import { ForumServiceService } from '../forum-service.service';

@Component({
  selector: 'app-forum-wrapper',
  templateUrl: './forum-wrapper.component.html',
  styleUrls: ['./forum-wrapper.component.css']
})
export class ForumWrapperComponent implements OnInit {
  sections: Section[] = [];

  constructor(private forumService: ForumServiceService) { }

  ngOnInit(): void {
    debugger;
    this.forumService.getAllForumSections().subscribe(result => {
      debugger;
      this.sections = result;
    });
  }

}
