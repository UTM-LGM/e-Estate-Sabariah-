import { Component, OnInit } from '@angular/core';
import { Cost } from 'src/app/_model/cost';
import { CostAmount } from 'src/app/_model/costAmount';
import { CostAmountService } from 'src/app/_services/cost-amount.service';
import { CostService } from 'src/app/_services/cost.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-indirect-cost',
  templateUrl: './indirect-cost.component.html',
  styleUrls: ['./indirect-cost.component.css'],
})
export class IndirectCostComponent implements OnInit {
  term = '';

  indirectCosts: Cost[] = [];

  costAmount:CostAmount[]=[];
  indirectCostAmount:CostAmount[]=[];
  filterIndirectCostAmount:CostAmount[]=[];


  indirectCost = {} as Cost;
  cost = {} as Cost;

  totalAmount = 0;
  totalCostAmount = 0;
  value: any;

  yearSelected:boolean = false;

  constructor(
    private costService: CostService,
    private costAmountService: CostAmountService
    ) {}

  ngOnInit(): void {
    this.getIndirectCost();
  }

  getIndirectCost() {
    this.costService.getIndirectCost()
    .subscribe(
      Response => {
      this.indirectCosts = Response;
    });
  }

  totalCost(data:any){
    this.value = data
    this.totalCostAmount = this.value.reduce((acc: any, item: { amount: any; })=> acc + item.amount, 0)
  }

  add() {
    this.costAmount = this.indirectCosts.map(({ amount, id, year, estateId }) => ({ amount, costID: id, year, estateId })) as unknown as CostAmount[];
    this.costAmountService.addCostAmount(this.costAmount)
    .subscribe(
      Response =>{
        swal.fire({
          title: 'Done!',
          text: 'Cost amount successfully submitted!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });
        this.getIndirectCostAmount();
      }, Error=>{
        swal.fire({
          text: 'Please fil up the form',
          icon: 'error'
        });
      });
  }

  calculateTotalAmount() {
    const sum = this.indirectCosts.reduce((acc, cost) => acc + cost.amount, 0);
    this.totalAmount = sum;
  }

  year(){
    this.yearSelected = true
    let year = {
      year: this.indirectCost.year
    };
    let estate = {
      estateId: 3
    }
    let newArray = this.indirectCosts.map((obj) => {
      return {
        ...obj,
        ...year,
        ...estate
      };
    });
    this.indirectCosts=newArray
    this.getIndirectCostAmount();
  }

  getIndirectCostAmount(){
    this.costAmountService.getCostAmount()
    .subscribe(
      Response=>{
        this.indirectCostAmount = Response;
        this.filterIndirectCostAmount = this.indirectCostAmount.filter(x=>x.year === this.indirectCost.year && x.costs.some(y=> y.costType === "Indirect Cost") 
        && x.costs.every(c=>c.costType === 'Indirect Cost'))
        this.totalCost(this.filterIndirectCostAmount)
      }
    )
  }

}
