import { Component, OnInit } from '@angular/core';
import { Company } from '../_model/company';
import { CompanyService } from '../_services/company.service';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css'],
})
export class CompanyListComponent implements OnInit {
  companies: Company[] = [];
  term = '';

  pageNumber = 1;

  isLoading: boolean = true;

  constructor(private companyService: CompanyService) {}

  ngOnInit(): void {
    this.getCompany();
  }

  getCompany() {
    setTimeout(() => {
    this.companyService.getCompany()
    .subscribe(
      Response => {
      this.companies = Response;
      this.isLoading = false;
    });
  }, 2000)
  }
}
