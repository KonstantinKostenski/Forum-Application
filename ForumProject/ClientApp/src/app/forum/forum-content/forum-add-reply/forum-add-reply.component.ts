import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorizeService, IUser } from '../../../../api-authorization/authorize.service';
import { Reply } from '../../../models/reply/Reply';
import { ForumServiceService } from '../../forum-service.service';

@Component({
  selector: 'app-forum-add-reply',
  templateUrl: './forum-add-reply.component.html',
  styleUrls: ['./forum-add-reply.component.css']
})
export class ForumAddReplyComponent implements OnInit {
  reply: Reply = new Reply();
  topicId: number;
  userInfo: IUser;

  constructor(private forumService: ForumServiceService, private route: ActivatedRoute, private router: Router, private authorizeService: AuthorizeService) { }

  ngOnInit(): void {
    this.authorizeService.getUser().subscribe(user => {
      this.userInfo = user;
    });
    this.route.params.subscribe(params => {
      debugger;
      this.topicId = +params['topicId'];
    });
  }

  onClickSubmit(value) {
    debugger;
    this.forumService.addReply({ topicId: this.topicId, ...value }).subscribe(result => {
      debugger;
      this.route.pathFromRoot[1].url.subscribe(val => {
        debugger;
        console.log();
        let result = val.map(segment => segment.path);
        result.pop();
        this.router.navigate(result);
      });
    });
  }
}
