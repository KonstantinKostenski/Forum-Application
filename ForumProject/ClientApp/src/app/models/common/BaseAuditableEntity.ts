export class BaseAuditableEntity {
  id: number;
  created: Date;
  createdBy: string;
  lastModified: Date;
  lastModifiedBy: string;
}
