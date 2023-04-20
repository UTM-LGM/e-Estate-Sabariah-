import { Field } from "./field";

export interface Estate{
    id: number,
    companyId: number,
    estateName: string,
    address1: string,
    address2: string,
    address3: string,
    postcode: string,
    phone: string,
    fax: string,
    email: string, 
    licenseNo: string,
    totalArea: string,
    townId: number,
    town:string,
    stateId:number,
    state:string,
    financialYearId: number,
    financialYear:string,
    establishmentId: number,
    establishment:string,
    membershipTypeId: number,
    membership:string,
    isActive:boolean,
    managerName:string,
    fields: Field[],
    clone:string,
    cropCategory:string
}