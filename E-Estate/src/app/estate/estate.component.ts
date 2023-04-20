import { Component, OnInit } from '@angular/core';
import { Estate } from '../_model/estate';
import { EstateStatus } from '../_model/estateStatus';
import { EstateService } from '../_services/estate.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-estate',
  templateUrl: './estate.component.html',
  styleUrls: ['./estate.component.css'],
})
export class EstateComponent implements OnInit {
  estates: Estate[] = [];

  history = {} as EstateStatus;

  term = '';

  pageNumber = 1;

  isLoading: boolean = true;

  constructor(private estateService: EstateService) {}

  ngOnInit(): void {
    this.getEstate();
  }

  getEstate() {
    setTimeout(() => {
    this.estateService.getEstate()
    .subscribe(
      Response => {
      this.estates = Response;
      this.isLoading = false;
    });
  }, 2000)
  }
}
