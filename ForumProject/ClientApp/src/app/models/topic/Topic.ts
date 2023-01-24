import { BaseAuditableEntity } from "../common/BaseAuditableEntity";

export class Topic extends BaseAuditableEntity {
  title: string;
  description: string;
  sectionId: number;
}
