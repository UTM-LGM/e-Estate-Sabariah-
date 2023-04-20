export interface Cost{
    id:number,
    isMature:boolean,
    isActive:Boolean,
    costTypeId:number,
    costType:string,
    costCategoryId:number,
    costCategory:string,
    costSubcategory1Id:number,
    costSubcategory1:string,
    costSubcategory2Id:number,
    costSubcategory2:string,
    amount:number,
    year:number,
    estateId:number,
    name:string
}