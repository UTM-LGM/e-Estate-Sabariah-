import { Component, OnInit } from '@angular/core';
import { CostCategory } from 'src/app/_model/costCategory';
import { CostSubcategory1 } from 'src/app/_model/costSubcategory1';
import { CostSubcategory2 } from 'src/app/_model/costSubcategory2';
import { CostCategoryService } from 'src/app/_services/cost-category.service';
import { CostSubcategory1Service } from 'src/app/_services/cost-subcategory1.service';
import { CostSubcategory2Service } from 'src/app/_services/cost-subcategory2.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-cost-category',
  templateUrl: './cost-category.component.html',
  styleUrls: ['./cost-category.component.css'],
})
export class CostCategoryComponent implements OnInit {
  costCategory = {} as CostCategory;

  costSubcategory1 = {} as CostSubcategory1;

  costSubcategory2 = {} as CostSubcategory2;

  costCategories: CostCategory[] = [];

  costSubCategories1: CostSubcategory1[] = [];

  costSubCategories2: CostSubcategory2[] = [];

  term = '';

  isLoading: boolean = true;

  pageNumber1 = 1;
  pageNumber2 = 1;
  pageNumber3 = 1;


  constructor(
    private costCategorService: CostCategoryService,
    private costSubCategory1Serive: CostSubcategory1Service,
    private costSubCategory2Service: CostSubcategory2Service
  ) {}

  ngOnInit(): void {
    this.getCostCategory();
    this.getCostSub1();
    this.getCostSub2();
  }

  getCostCategory() {
    setTimeout(() => {
    this.costCategorService.getCostCat()
    .subscribe(
      Response => {
      this.costCategories = Response;
      this.isLoading = false;
    });
  }, 2000)
}

  getCostSub1() {
    setTimeout(() => {
    this.costSubCategory1Serive.getCostSubCat()
    .subscribe(
      Response => {
      this.costSubCategories1 = Response;
      this.isLoading = false;
    });
  }, 2000)
}

  getCostSub2() {
    setTimeout(() => {
    this.costSubCategory2Service.getCostSubCat()
    .subscribe(
      Response => {
      this.costSubCategories2 = Response;
      this.isLoading = false;
    });
  }, 2000)
}

  submitCategory() {
    this.costCategory.isActive = true;
    this.costCategorService.addCostCat(this.costCategory)
      .subscribe(
        Response => {
        swal.fire({
          title: 'Done!',
          text: 'Cost category successfully submitted!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });

        this.costCategory = {} as CostCategory;
        this.ngOnInit();
      });
  }

  submitSub1() {
    this.costSubcategory1.isActive = true;
    this.costSubCategory1Serive.addCostSubCat(this.costSubcategory1)
      .subscribe(
        Response => {
        swal.fire({
          title: 'Done!',
          text: 'Cost Subcategory 1 successfully submitted!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });
        this.costSubcategory1 = {} as CostSubcategory1;
        this.ngOnInit();
      });
  }

  submitSub2() {
    this.costSubcategory2.isActive = true;
    this.costSubCategory2Service.addCostSubCat(this.costSubcategory2)
      .subscribe(
        Response => {
        swal.fire({
          title: 'Done!',
          text: 'Cost Subcategory 2 successfully submitted!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });

        this.costSubcategory2 = {} as CostSubcategory2;
        this.ngOnInit();
      });
  }

  statusCostCategory(id:number){
    this.costCategorService.updateStatus(id)
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

  statusCostSub1(id:number){
    this.costSubCategory1Serive.updateStatus(id)
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

  statusCostSub2(id:number){
    this.costSubCategory2Service.updateStatus(id)
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
