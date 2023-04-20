import { Clone } from "./clone";

export interface FieldClone{
    includes(x: Clone): unknown;
    id:number,
    fieldId:number,
    cloneId:number
}