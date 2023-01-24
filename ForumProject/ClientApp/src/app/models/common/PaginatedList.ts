export class PaginatedList<T>{
  items: T[];
  pageNumber: number;
  totalPages: number;
  totalCount: number;
}
