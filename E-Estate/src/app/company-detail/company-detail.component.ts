import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Company } from '../_model/company';
import { CompanyService } from '../_services/company.service';
import swal from 'sweetalert2';
import { UserActivityLog } from '../_model/userActivityLog';
import { UserActivityLogService } from '../_services/user-activity-log.service';
import { HttpHeaders } from '@angular/common/http';
import { Location } from '@angular/common';
import { EstateService } from '../_services/estate.service';
import { FieldService } from '../_services/field.service';


@Component({
  selector: 'app-company-detail',
  templateUrl: './company-detail.component.html',
  styleUrls: ['./company-detail.component.css'],
})
export class CompanyDetailComponent implements OnInit {
  company: Company = {} as Company;

  isLoading:boolean = true;

  term = '';

  pageNumber = 1;
  selectedEstate: any;

  activityLog = {} as UserActivityLog;

  constructor(
    private route: ActivatedRoute,
    private companyService: CompanyService,
    private estateService:EstateService,
    private location: Location,
    private fieldService:FieldService
  ) {}

  ngOnInit(): void {
    this.getCompany();
  }

  getCompany() {
    setTimeout(() => {
    this.route.params.subscribe((routeParams) => {
      if (routeParams['id'] != null) 
      {
        this.companyService.getOneCompany(routeParams['id'])
          .subscribe(
            Response => {
            this.company = Response;
            this.isLoading = false;
          });
      }
    });
  }, 2000)
}

  status(company: Company) {
    this.activityLog.userId = 1
    const headers = new HttpHeaders().set('userId', this.activityLog.userId.toString());
    this.companyService.updateStatus(company.id, headers)
    .subscribe(
      Response => {
      swal.fire({
        title: 'Done!',
        text: 'Company Status successfully updated!',
        icon: 'success',
        showConfirmButton: false,
        timer: 1000
      });
      this.getCompany();
    });
  }

  back(){
    this.location.back();
  }

  statusEstate(id:number){
    this.estateService.updateStatus(id)
    .subscribe(
      Response=>{
        swal.fire({
          title: 'Done!',
          text: 'Estate Status successfully updated!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });
        this.ngOnInit();
      }
    )
  }

  statusField(id:number){
    this.fieldService.updateStatus(id)
    .subscribe(
      Response=>{
        swal.fire({
          title: 'Done!',
          text: 'Field Status successfully updated!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });
        this.ngOnInit();
      }
    )
  }

  toggleSelectedEstate(estate: any) {
    if (this.selectedEstate === estate) {
      this.selectedEstate = null;
    } else {
      this.selectedEstate = estate;
    }
  }

}
