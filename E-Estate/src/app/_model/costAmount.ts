import { Cost } from "./cost";
import { Estate } from "./estate";

export interface CostAmount{
    id:number,
    costId:number,
    amount:number,
    year:number,
    estates:Estate[],
    costAmount:CostAmount[],
    costs:Cost[]
}