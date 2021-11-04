export default interface IBrandForm {
    id? : number,
    name: string,
    type: number,
    description: string,
    imagePath?: string,
    imageFile?: Blob
}