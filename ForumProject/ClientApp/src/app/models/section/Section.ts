import { BaseAuditableEntity } from "../common/BaseAuditableEntity";

export class Section extends BaseAuditableEntity {
  name: string;
  description: string;
}
