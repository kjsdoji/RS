export default interface IBrand {
    id: number,
    name: string,
    type: number,
    imagePath?: string,
    imageFile?: Blob,
    description: string
}