import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Estate } from '../_model/estate';
import { EstateService } from '../_services/estate.service';
import swal from 'sweetalert2';
import { Field } from '../_model/field';
import { FieldService } from '../_services/field.service';
import { Location } from '@angular/common';


@Component({
  selector: 'app-estate-detail',
  templateUrl: './estate-detail.component.html',
  styleUrls: ['./estate-detail.component.css'],
})
export class EstateDetailComponent implements OnInit {
  estate = {} as Estate;

  pageNumber = 1;

  isLoading:boolean = true;

  constructor(
    private route: ActivatedRoute,
    private estateService: EstateService,
    private fieldService: FieldService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getEstate();
  }

  getEstate() {
    setTimeout(() => {
    this.route.params.subscribe((routerParams) => {
      if (routerParams['id'] != null) {
        this.estateService.getOneEstate(routerParams['id'])
          .subscribe(
            Response => {
            this.estate = Response;
            this.isLoading = false;
          });
      }
    });
  }, 2000)
}

  status(estate: Estate) {
    this.estateService.updateStatus(estate.id)
    .subscribe(
      Response => {
      swal.fire({
        title: 'Done!',
        text: 'Estate Status successfully updated!',
        icon: 'success',
        showConfirmButton: false,
        timer: 1000
      });

      this.getEstate();
    });
  }

  back(){
    this.location.back();
  }
}
