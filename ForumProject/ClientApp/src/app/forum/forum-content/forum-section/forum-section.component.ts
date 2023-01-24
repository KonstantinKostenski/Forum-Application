import { Component, Input, OnInit } from '@angular/core';
import { Section } from '../../../models/section/Section';

@Component({
  selector: 'app-forum-section',
  templateUrl: './forum-section.component.html',
  styleUrls: ['./forum-section.component.css']
})
export class ForumSectionComponent implements OnInit {
  @Input() section: Section;

  constructor() { }

  ngOnInit(): void {
  }

}
