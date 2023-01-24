import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AuthorizeService, IUser } from '../../../../api-authorization/authorize.service';
import { Topic } from '../../../models/topic/Topic';
import { ForumServiceService } from '../../forum-service.service';

@Component({
  selector: 'app-forum-topic',
  templateUrl: './forum-topic.component.html',
  styleUrls: ['./forum-topic.component.css']
})
export class ForumTopicComponent implements OnInit {
  @Input() topic: Topic;
  userInfo: IUser;
  editMode: boolean = false;
  deleteListModalRef: BsModalRef;

  constructor(private forumService: ForumServiceService, private authorizeService: AuthorizeService, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.authorizeService.getUser().subscribe(user => {
      this.userInfo = user;
    });
  }

  showDeleteModal(template: TemplateRef<any>) {
    if (!this.isCreatedByCurrentUser()) {
      return;
    }

    this.deleteListModalRef = this.modalService.show(template);
  }

  deleteTopic() {
    debugger;

    this.forumService.deleteTopic(this.topic.id).subscribe(result => {
      debugger;
      location.reload();
      this.deleteListModalRef.hide();
    });
  }

  editTopic() {
    if (!this.isCreatedByCurrentUser()) {
      return;
    }

    this.editMode = true;
  }

  onClickSubmit(value) {
    debugger;
    this.forumService.editTopic({ id: this.topic.id, sectionId: this.topic.sectionId, ...value }).subscribe(result => {
      debugger;
      this.editMode = false;
    })
  }

  isCreatedByCurrentUser(): boolean {
    debugger;
    if (this.userInfo && this.topic) {
      return this.userInfo.sub === this.topic.createdBy;
    }

    return false;
  }
}
