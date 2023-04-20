import { Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { Field } from '../_model/field';
import { CropCategory } from '../_model/cropCategory';
import { Clone } from '../_model/clone';
import { CropCategoryService } from '../_services/crop-category.service';
import { CloneService } from '../_services/clone.service';
import { FieldService } from '../_services/field.service';
import { FieldCloneService } from '../_services/field-clone.service';
import { FieldClone } from '../_model/fieldClone';
import swal from 'sweetalert2';

@Component({
  selector: 'app-field-info',
  templateUrl: './field-info.component.html',
  styleUrls: ['./field-info.component.css'],
})
export class FieldInfoComponent implements OnInit {
  field: Field = {} as Field;

  clones: Clone[] = [];
  filterClones: Clone[] = [];
  filterArray: Clone[] = [];
  availableClones: Clone[]=[];

  combineClone:FieldClone[]=[];

  selectClone: FieldClone = {} as FieldClone;

  fields: Field[] = [];
  selectedValues: any[] = [];

  cropCategories: CropCategory[] = [];
  filterCropCategories: CropCategory[] = [];
  filterCropStatus: CropCategory[] = [];

  total = 0;
  value: any;
  isLoading: boolean = true;

  pageNumber=1;


  constructor(
    private cropService: CropCategoryService,
    private cloneService: CloneService,
    private fieldService: FieldService,
    private fieldCloneService: FieldCloneService,
  ) {}

  ngOnInit(): void {
    this.initialForm();
    this.getCrop();
    this.getClone();
    this.getField();
  }

  initialForm(){
    this.field.cropCategoryId = 0
    this.field.cloneId = 0
  }

  onSubmit() {
    this.field.estateId = 7;
    this.field.isActive = true;
    this.fieldService.addField(this.field)
    .subscribe(
      Response => {
      const combineClone:any[]= this.selectedValues.map(item =>{
        return{'cloneId': item.id, 'fieldId':Response.id}
      })
      this.fieldCloneService.addFieldClone(combineClone)
      .subscribe(
        Response=>{
        swal.fire({
          title: 'Done!',
          text: 'Field successfully submitted!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });
        this.field = {} as Field
        this.ngOnInit();
        },)
    }, Error=>{
      swal.fire({
        text: 'Please fil up the form',
        icon: 'error'
      });
    });
  }

  getcategory(event: any) {
    this.filterCropCategories = this.cropCategories.filter(c => c.isMature == this.field.isMature);
    this.filterCropStatus = this.filterCropCategories.filter(e => e.isActive == true);
  }

  getCrop() {
    this.cropService.getCrop()
    .subscribe(
      Response => {
      this.cropCategories = Response;
    });
  }

  getClone() {
    this.cloneService.getClone()
    .subscribe(Response => {
      this.clones = Response;
      this.filterClones = this.clones.filter((e) => e.isActive == true);
      this.availableClones = this.filterClones;
    });
  }

  selectedClone(value: Field) {
     const item = this.filterClones.find((x) => x.id == value.cloneId)
     this.selectedValues.push(item);
     console.log(this.selectedValues)
     this.field.cloneId = 0;
     this.availableClones = this.filterClones.filter(x=> !this.selectedValues.includes(x))
  }

  delete(index: number) {
    this.selectedValues.splice(index, 1);
    this.availableClones = this.filterClones.filter(x=> !this.selectedValues.includes(x))
  }

  getField() {
    setTimeout(() => {
    this.fieldService.getField()
    .subscribe(
      Response => {
      this.fields = Response;
      this.sum(this.fields);
      this.isLoading = false;
    });
  }, 2000)
}

  sum(data: any) {
    this.value = data.filter((x: { isActive: boolean; })=>x.isActive == true);
    const sum = this.value.reduce((acc: any, item: { area: any; })=> acc + item.area, 0)
    this.total = sum
  }
}
