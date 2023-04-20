import { Component, OnInit } from '@angular/core';
import { Company } from '../_model/company';
import { CompanyService } from '../_services/company.service';

@Component({
  selector: 'app-company-profile',
  templateUrl: './company-profile.component.html',
  styleUrls: ['./company-profile.component.css'],
})
export class CompanyProfileComponent implements OnInit {
  companies: Company[] = [];

  isLoading:boolean = true;

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
