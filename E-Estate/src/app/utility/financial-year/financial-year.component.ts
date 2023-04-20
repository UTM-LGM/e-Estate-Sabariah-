import { Component, OnInit } from '@angular/core';
import { FinancialYear } from 'src/app/_model/financialYear';
import { FinancialYearService } from 'src/app/_services/financial-year.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-financial-year',
  templateUrl: './financial-year.component.html',
  styleUrls: ['./financial-year.component.css'],
})
export class FinancialYearComponent implements OnInit {
  financialYear = {} as FinancialYear;

  financialYears: FinancialYear[] = [];

  term = '';

  isLoading: boolean = true;

  pageNumber=1;

  constructor(private financialService: FinancialYearService) {}

  ngOnInit(): void {
    this.getFinancialYear();
  }

  submit() {
    this.financialYear.isActive = true;
    this.financialService.addFinancialYear(this.financialYear)
      .subscribe(
        Response => {
        swal.fire({
          title: 'Done!',
          text: 'Financial Year successfully submitted!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });
        this.reset();
        this.ngOnInit();
      });
  }

  reset() {
    this.financialYear = {} as FinancialYear;
  }

  getFinancialYear() {
    setTimeout(() => {
    this.financialService.getAllFinancialYear()
    .subscribe(
      Response => {
      this.financialYears = Response;
      this.isLoading = false;
    });
  }, 2000)
}

  status(id:number){
    this.financialService.updateStatus(id)
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
