import { Clone } from "./clone";

export interface Field{
    id:number,
    fieldName:string,
    area:number,
    isActive:boolean,
    isMature:boolean,
    dateOpenTapping:string,
    totalTask:number,
    estateId: number,
    cloneId:number,
    clone:string,
    cropCategoryId:number | null,
    cropCategory:string,
    yearPlanted:string,
    otherCrop:string,
    cloneName:string,
    clones:Clone[]
}