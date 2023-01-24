import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiClientService } from '../common/web-api-client.service';
import { PaginatedList } from '../models/common/PaginatedList';
import { Reply } from '../models/reply/Reply';
import { Section } from '../models/section/Section';
import { Topic } from '../models/topic/Topic';
import { FileResponse } from '../web-api-client';

@Injectable({
  providedIn: 'root'
})
export class ForumServiceService {

  constructor(private webApiClientService: WebApiClientService) { }

  public getAllForumSections(): Observable<Section[]>
  {
    return this.webApiClientService.getItemsWithPagination<Section>("/api/Sections");
  }

  public getAllForumTopicsPerSectionPaginated(sectionId: number, pageNumber: number): Observable<PaginatedList<Topic>> {
    return this.webApiClientService.getItemsWithPaginationById<PaginatedList<Topic>>("/api/Topics", sectionId, pageNumber);
  }

  public getTopicById(topicId: number): Observable<Topic> {
    return this.webApiClientService.getItemsWithPaginationById("/api/Topics/GetTopicById", topicId);
  }

  public addTopic(topic: Topic): Observable<number> {
    return this.webApiClientService.create(topic, "Topics");
  }

  public editTopic(topic: Topic): Observable<FileResponse> {
    return this.webApiClientService.update("Topics", topic.id, topic);
  }

  public addReply(reply: Reply): Observable<number> {
    return this.webApiClientService.create(reply, "Replies");
  }

  public editReply(reply: Reply): Observable<FileResponse> {
    return this.webApiClientService.update("Replies", reply.id, reply);
  }

  public deleteTopic(id: number): Observable<number> {
    return this.webApiClientService.delete(id, "Topics");
  }

  public deleteReply(id: number): Observable<number> {
    return this.webApiClientService.delete(id, "Replies");
  }

  public getTopicRepliesPaginated(topicId: number, pageNumber:number): Observable<PaginatedList<Reply>> {
    return this.webApiClientService.getItemsWithPaginationById<PaginatedList<Reply>>("/api/Replies/GetRepliesByTopic", topicId, pageNumber);
  }
}
