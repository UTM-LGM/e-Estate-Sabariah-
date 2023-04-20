export interface UserActivityLog{
    id:number,
    userId:number | null,
    userName:string,
    role:string,
    dateTime:Date,
    method:string,
    body:string,
    url:string
}