import { Country } from "./country";

export interface Labor{
    id:number,
    monthYear:string | null,
    tapperCheckrole:number,
    tapperContractor:number,
    fieldCheckrole:number,
    fieldContractor:number,
    countryId:number,
    country:Country[],
    total:number,
    workerNeeded:number,
    estateId:number
}