import { Component, OnInit } from '@angular/core';
import { Cost } from 'src/app/_model/cost';
import { CostAmount } from 'src/app/_model/costAmount';
import { CostSubcategory1 } from 'src/app/_model/costSubcategory1';
import { CostAmountService } from 'src/app/_services/cost-amount.service';
import { CostSubcategory1Service } from 'src/app/_services/cost-subcategory1.service';
import { CostService } from 'src/app/_services/cost.service';
import swal from 'sweetalert2';


@Component({
  selector: 'app-direct-cost',
  templateUrl: './direct-cost.component.html',
  styleUrls: ['./direct-cost.component.css'],
})
export class DirectCostComponent implements OnInit {
  term = '';

  directCost={} as Cost;
  
  costItems: Cost[] = [];
  costCategories: Cost[] = [];
  filterCostCategories: Cost[] = [];

  subCategories1: Cost[] = [];
  subCategories2: Cost[] = [];
  subCategories2IM: Cost[] = [];

  costImmatureAmount:CostAmount[]=[];
  costMatureAmount:CostAmount[]=[];
  immatureDirectCostAmount:CostAmount[]=[];
  filterImmatureDirectCostAmount:CostAmount[]=[];

  matureDirectCostAmount:CostAmount[]=[];
  filterMatureDirectCostAmount:CostAmount[]=[];

  yearSelectedImmature:boolean = false;
  yearSelectedMature:boolean = false;

  costSubCategories1: CostSubcategory1[] = [];
  filter: CostSubcategory1[] = [];
  subCategoryName: string[] = [];


  immatureYear='';
  matureYear = '';
  totalImmatureAmount=0;
  totalImmatureCostAmount = 0;
  totalMatureAmount=0;
  totalMatureCostAmount = 0;
  value: any;
  filterId:any;
  filterName:any;


  constructor(
    private costService: CostService,
    private costAmountService: CostAmountService,
    ) {}

  ngOnInit(): void {
    this.getCostCategory();
    this.getCostSub1();
    this.getCostSub2();
    this.getCostSub2IM();
  }

  getCostCategory() {
    this.costService.getDirectMatureCostCategory()
    .subscribe(
      Response => {
      this.costCategories = Response;
    });
  }

  getCostSub1() {
    this.costService.getDirectMatureSubCategory1()
    .subscribe(
      Response => {
      this.subCategories1 = Response;
      const subCategoryId = [...new Set(this.subCategories1.map(cost => cost.costSubcategory1Id))]
      const result = subCategoryId.map(id=>{
      this.filterId = this.subCategories1.filter(cost => cost.costSubcategory1Id === id)})
    });
  }
  
  getCostSub2() {
    this.costService.getDirectMatureSubCategory2()
    .subscribe(
      Response => {
      this.subCategories2 = Response;
    });
  }

  getCostSub2IM() {
    this.costService.getDirectMatureSubCategory2IM()
    .subscribe(
      Response => {
      this.subCategories2IM = Response;
    });
  }

  addImmmatureCost(){
    this.costImmatureAmount = this.subCategories2IM.map(({ amount, id, year, estateId }) => ({ amount, costID: id, year, estateId: estateId})) as unknown as CostAmount[];
    this.costAmountService.addCostAmount(this.costImmatureAmount)
    .subscribe(
      Response =>{
        swal.fire({
          title: 'Done!',
          text: 'Cost amount successfully submitted!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });
        this.getImmatureDirectCost();
      }, Error=>{
        swal.fire({
          text: 'Please fil up the form',
          icon: 'error'
        });
      });
  }

  calculateTotalImmatureAmount() {
    const sum = this.subCategories2IM.reduce((acc, item)=> acc + item.amount, 0)
    this.totalImmatureAmount = sum
  }

  yearImmature(){
    this.yearSelectedImmature = true
    let year = {
      year: parseInt(this.immatureYear)
    };
    let estate = {
      estateId: 3
    }
    let newArray = this.subCategories2IM.map((obj) => {
      return {
        ...obj,
        ...year,
        ...estate
      };
    });
    this.subCategories2IM=newArray
    this.getImmatureDirectCost();

  }

  getImmatureDirectCost(){
    this.costAmountService.getCostAmount()
    .subscribe(
      Response=>{
        this.immatureDirectCostAmount = Response
        this.filterImmatureDirectCostAmount = this.immatureDirectCostAmount.filter(x=>x.year === parseInt(this.immatureYear) 
        && x.costs.some(y=> y.costType === "Direct Cost" && y.isMature === false) 
        && x.costs.every(c=>c.costType === 'Direct Cost'))
        this.totalImmatureCost(this.filterImmatureDirectCostAmount)
      }
    )
  }

  totalImmatureCost(data:any){
    this.value= data
    const sum = this.value.reduce((acc: any, item: { amount: any; })=> acc + item.amount, 0)
    this.totalImmatureCostAmount = sum
  }

  addMatureCost(){
    this.costMatureAmount = this.subCategories1.map(({ amount, id, year, estateId }) => ({ amount, costID: id, year, estateId: estateId})) as unknown as CostAmount[];
    this.costAmountService.addCostAmount(this.costMatureAmount)
    .subscribe(
      Response =>{
        swal.fire('Done!', 'Cost amount successfully submitted!', 'success')
        swal.fire({
          title: 'Done!',
          text: 'Cost amount successfully submitted!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });
        this.getMatureDirectCost();
      }, Error=>{
        swal.fire({
          text: 'Please fil up the form',
          icon: 'error'
        });
      });
  }

  yearMature(){
    this.yearSelectedMature = true;
    let year = {
      year: parseInt(this.matureYear)
    };
    let estate = {
      estateId: 3
    }
    let newArray = this.subCategories1.map((obj) => {
      return {
        ...obj,
        ...year,
        ...estate
      };
    });
    this.subCategories1=newArray
    this.getMatureDirectCost()
  }

  getMatureDirectCost(){
    this.costAmountService.getCostAmount()
    .subscribe(
      Response =>{
        this.matureDirectCostAmount = Response
        this.filterMatureDirectCostAmount = this.matureDirectCostAmount.filter(x=>x.year === parseInt(this.matureYear)
        && x.costs.some(y=> y.costType === "Direct Cost"
        && y.isMature === true && y.isMature !== null) 
        && x.costs.every(c=>c.costType === 'Direct Cost'))
        // const subCategoryName = [...new Set(this.filterMatureDirectCostAmount.map(cost => cost.costs.map(c => c.costSubcategory1)))];
        // const result = subCategoryName.map(name => {
        // this.filterName = this.filterMatureDirectCostAmount.filter(cost => cost.costs.some(c => c.costSubcategory1 === name))});      
        // console.log(this.filterName)
        this.totalMatureCost(this.filterMatureDirectCostAmount)
        console.log(this.filterMatureDirectCostAmount)
      }
    )
  }

  totalMatureCost(data:any){
    this.value= data
    const sum = this.value.reduce((acc: any, item: { amount: any; })=> acc + item.amount, 0)
    this.totalMatureCostAmount = sum
  }

  calculateTotalMatureAmount(){
    const sum = this.subCategories1.reduce((acc, item)=> acc + item.amount, 0)
    this.totalMatureAmount = sum
  }  
}




