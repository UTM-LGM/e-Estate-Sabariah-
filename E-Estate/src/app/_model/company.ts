import { Estate } from "./estate";

export interface Company{
    id: number,
    companyName: string,
    address1: string,
    address2: string,
    address3:string,
    postcode:string,
    town:string,
    phone:string,
    email:string,
    fax:string,
    contactNo:string,
    managerName:string,
    isActive:boolean,
    estates: Estate[],
    townEstate:string,
    membershipType:string
}