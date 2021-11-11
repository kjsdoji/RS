export default interface IQueryCategoryModel {
    search: string;
    sortOrder: string;
    sortColumn: string;
    limit: number;
    page: number;
    types: number[];
}