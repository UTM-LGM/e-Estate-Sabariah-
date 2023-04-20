import { Component, OnInit } from '@angular/core';
import { Cost } from 'src/app/_model/cost';
import { CostCategory } from 'src/app/_model/costCategory';
import { CostSubcategory1 } from 'src/app/_model/costSubcategory1';
import { CostSubcategory2 } from 'src/app/_model/costSubcategory2';
import { CostType } from 'src/app/_model/costType';
import { CostCategoryService } from 'src/app/_services/cost-category.service';
import { CostSubcategory1Service } from 'src/app/_services/cost-subcategory1.service';
import { CostSubcategory2Service } from 'src/app/_services/cost-subcategory2.service';
import { CostTypeService } from 'src/app/_services/cost-type.service';
import { CostService } from 'src/app/_services/cost.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-cost-item',
  templateUrl: './cost-item.component.html',
  styleUrls: ['./cost-item.component.css'],
})
export class CostItemComponent implements OnInit {
  term = '';

  cost = {} as Cost;

  costTypes: CostType[] = [];
  filterCostTypes: CostType[] = [];

  costCategories: CostCategory[] = [];
  filterCostCategories: CostCategory[] = [];

  costSubs1: CostSubcategory1[] = [];
  filterCostSubs1: CostSubcategory1[] = [];

  costSubs2: CostSubcategory2[] = [];
  filterCostSubs2: CostSubcategory2[] = [];

  costItem: Cost[] = [];

  isLoading: boolean = true;

  pageNumber = 1;

  constructor(
    private costTypeService: CostTypeService,
    private costCategoryService: CostCategoryService,
    private costSub1Service: CostSubcategory1Service,
    private costSub2Service: CostSubcategory2Service,
    private costService: CostService
  ) {}

  ngOnInit(): void {
    this.initialForm();
    this.getCostType();
    this.getCostCategory();
    this.getCostSub1();
    this.getCostSub2();
    this.getCostItem();
  }

  initialForm(){
    this.cost.costTypeId = 0;
    this.cost.costCategoryId = 0;
    this.cost.costSubcategory1Id = 0;
    this.cost.costSubcategory2Id = 0;
  }

  submit() {
    this.cost.isActive = true;
    this.costService.addCostItem(this.cost)
    .subscribe(
      Response => {
      swal.fire({
        title: 'Done!',
        text: 'Cost Item successfully submitted!',
        icon: 'success',
        showConfirmButton: false,
        timer: 1000
      });

      this.cost = {} as Cost;
      this.ngOnInit();
    });
  }

  getCostType() {
    this.costTypeService.getCostType()
    .subscribe(
      Response => {
      this.costTypes = Response;
      this.filterCostTypes = this.costTypes.filter((e) => e.isActive == true);
    });
  }

  getCostCategory() {
    this.costCategoryService.getCostCat()
    .subscribe(
      Response => {
      this.costCategories = Response;
      this.filterCostCategories = this.costCategories.filter(e => e.isActive == true);
    });
  }

  getCostSub1() {
    this.costSub1Service.getCostSubCat()
    .subscribe(
      Response => {
      this.costSubs1 = Response;
      this.filterCostSubs1 = this.costSubs1.filter((e) => e.isActive == true);
    });
  }

  getCostSub2() {
    this.costSub2Service.getCostSubCat()
    .subscribe(
      Response => {
      this.costSubs2 = Response;
      this.filterCostSubs2 = this.costSubs2.filter((e) => e.isActive == true);
    });
  }

  getCostItem() {
    setTimeout(() => {
    this.costService.getCostItem()
    .subscribe(Response => {
      this.costItem = Response;
      this.isLoading = false;
    });
  }, 2000)
}

  status(id:number){
    this.costService.updateStatus(id)
    .subscribe(
      Response=>{
        swal.fire({
          title: 'Done!',
          text: 'Status successfully updated!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });
      this.ngOnInit();
      }
    )
  }
}
