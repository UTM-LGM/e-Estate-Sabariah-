import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Field } from '../_model/field';
import { FieldService } from '../_services/field.service';
import { DatePipe } from '@angular/common';
import { CropCategory } from '../_model/cropCategory';
import { CropCategoryService } from '../_services/crop-category.service';
import { CloneService } from '../_services/clone.service';
import { Clone } from '../_model/clone';
import swal from 'sweetalert2';
import { FieldClone } from '../_model/fieldClone';
import { environment } from 'src/environments/environments';
import { Location } from '@angular/common';



@Component({
  selector: 'app-field-detail',
  templateUrl: './field-detail.component.html',
  styleUrls: ['./field-detail.component.css'],
})
export class FieldDetailComponent implements OnInit {
  fields: Field = {} as Field;
  formattedDate: string = '';

  cropCategories: CropCategory[] = [];
  filterCropCategories: CropCategory[] = [];
  filterStatus: CropCategory[] = [];

  fieldClones:Clone[]=[]
  availableClones: Clone[]=[];
  clones: Clone[] = [];
  filterClones: Clone[] = [];

  selectedValues: any[] = [];

  fieldClone = {} as FieldClone
  selected = {} as CropCategory;

  baseUrl = environment.apiUrl;

  constructor(
    private route: ActivatedRoute,
    private fieldService: FieldService,
    private datePipe: DatePipe,
    private cropCategoryService: CropCategoryService,
    private cloneService: CloneService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getCropCategory();
    this.getClone();
    this.getOneField();
  }

  getOneField(){
    this.route.params.subscribe((routeParams) => {
      if (routeParams['id'] != null) {
        this.fieldService.getOneField(routeParams['id'])
          .subscribe(
            Response => {
            this.fields = Response;
            this.fields.cloneId = 0;
            this.fieldClones = Response.clones
            this.selectedValues = this.fieldClones;
            this.availableClones = this.filterClones.filter(clone => !this.selectedValues.some(selectedClone => selectedClone.id === clone.id));
            this.getDate(Response.dateOpenTapping);
            this.getcategory(event);
          });
      }
    })
  }

  getDate(date: string) {
    this.formattedDate = this.datePipe.transform(date, 'yyyy-MM-dd') || '';
    this.fields.dateOpenTapping = this.formattedDate.toString();
  }

  getCropCategory() {
    this.cropCategoryService.getCrop()
    .subscribe(
      Response => {
      this.cropCategories = Response;
    });
  }

  getcategory(event: any) {
    this.filterCropCategories = this.cropCategories.filter(c => c.isMature == this.fields.isMature);
    this.filterStatus = this.filterCropCategories.filter(c => c.isActive == true);
  }

  updateField(field: Field) {
    this.fieldService.updateField(field)
    .subscribe(
      Response => {
      swal.fire({
        title: 'Done!',
        text: 'Field successfully updated!',
        icon: 'success',
        showConfirmButton: false,
        timer: 1000
      });

      this.ngOnInit();
    });
  }

  getClone() {
    this.cloneService.getClone()
    .subscribe(
      Response => {
      this.clones = Response;
      this.filterClones = this.clones.filter((e) => e.isActive == true);
    });
  }

  status(field: Field) {
    this.fieldService.updateStatus(field.id)
    .subscribe(
      Response => {
      swal.fire({
        title: 'Done!',
        text: 'Field Status successfully updated!',
        icon: 'success',
        showConfirmButton: false,
        timer: 1000
      });
      this.ngOnInit();
    });
  }

  addClone(field:Field)
  {
    this.fieldClone.fieldId = field.id
    this.fieldClone.cloneId = field.cloneId
    this.fieldService.addClone(this.fieldClone)
    .subscribe(
      Response=>{
        swal.fire({
          title: 'Done!',
          text: 'Clone successfully added!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });

        this.ngOnInit();
      }
    )
    
  }

  delete(cloneId:number, fieldId:number){
    {
      swal.fire({
        title:"Are you sure to delete ?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: 'Yes',
        denyButtonText: 'Cancel'
      })
      .then((result) => {  
          if (result.isConfirmed) { 
            this.fieldService.deleteClone(cloneId,fieldId)
            .subscribe(
              Response =>{
                swal.fire({
                  title: 'Deleted!',
                  text: 'Clone has been deleted!',
                  icon: 'success',
                  showConfirmButton: false,
                  timer: 1000
                });
                this.ngOnInit();
              }
            )
          } else if (result.isDenied) {    
         }
      });
    }
  }
  
  back(){
    this.location.back();
  }
}

