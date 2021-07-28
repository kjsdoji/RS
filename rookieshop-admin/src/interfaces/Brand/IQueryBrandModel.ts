export default interface IQueryBrandModel {
    Keyword: string;
    LanguageId: string;
    CategoryId: number;
    PageIndex: number;
    PageSize: number;

    search: string;
    sortOrder: string;
    sortColumn: string;
    limit: number;
    page: number;
    types: number[];
}