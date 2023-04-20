import { Component, OnInit } from '@angular/core';
import { Estate } from '../_model/estate';
import { EstateService } from '../_services/estate.service';

@Component({
  selector: 'app-estate-list',
  templateUrl: './estate-list.component.html',
  styleUrls: ['./estate-list.component.css'],
})
export class EstateListComponent implements OnInit {
  estates: Estate[] = [];
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
