import { Component, EventEmitter, Input, OnInit, Output, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AuthorizeService, IUser } from '../../../../api-authorization/authorize.service';
import { Reply } from '../../../models/reply/Reply';
import { ForumServiceService } from '../../forum-service.service';

@Component({
  selector: 'app-forum-reply',
  templateUrl: './forum-reply.component.html',
  styleUrls: ['./forum-reply.component.css']
})
export class ForumReplyComponent implements OnInit {
  @Input() reply: Reply;
  @Output() deleteOutput: EventEmitter<number> = new EventEmitter<number>()
  editMode: boolean;
  userInfo: IUser;
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

  deleteReply() {
    debugger;
    
    this.deleteOutput.emit(this.reply.id);
    this.deleteListModalRef.hide();
  }

  editReply() {
    if (!this.isCreatedByCurrentUser()) {
      return;
    }
    this.editMode = true;
  }

  onClickSubmit(value) {
    debugger;


    this.forumService.editReply({ id: this.reply.id, sectionId: this.reply.topicId, ...value }).subscribe(result => {
      debugger;
      this.editMode = false;
    })
  }

  isCreatedByCurrentUser(): boolean {
    debugger;
    if (this.userInfo && this.reply) {
      return this.userInfo.sub === this.reply.createdBy;
    }

    return false;
  }
}
