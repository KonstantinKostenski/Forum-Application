import { BaseAuditableEntity } from "../common/BaseAuditableEntity";

export class Reply extends BaseAuditableEntity {
  message: string;
  topicId: number;
}
