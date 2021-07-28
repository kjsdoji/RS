export default interface IBrandForm {
    id? : number,
    Name: string,
    type?: number,
    imagePath?: string,
    imageFile?: Blob,

    Price: number,
    OriginalPrice: number,
    Stock: number,
    Description: string,
    Details: string,
    SeoDescription: string,
    SeoTitle: string,
    SeoAlias: string,
    LanguageId: string
}