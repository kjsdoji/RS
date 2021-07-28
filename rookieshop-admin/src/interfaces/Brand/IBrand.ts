export default interface IBrand {
    id: number,
    name: string,
    type: number,
    imagePath?: string,
    imageFile?: Blob

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