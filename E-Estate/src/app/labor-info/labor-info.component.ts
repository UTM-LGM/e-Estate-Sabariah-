import { Component, OnInit } from '@angular/core';
import { Country } from '../_model/country';
import { Labor } from '../_model/labor';
import { CountryService } from '../_services/country.service';
import { LaborService } from '../_services/labor.service';
import swal from 'sweetalert2';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-labor-info',
  templateUrl: './labor-info.component.html',
  styleUrls: ['./labor-info.component.css'],
})
export class LaborInfoComponent implements OnInit {
  previousMonth = new Date();

  labor = {} as Labor;

  countries: Country[] = [];
  filterCountries: Country[] = [];
  labors: Labor[] = [];
  filterLabors: Labor[] = [];
  country:Country[]=[]

  Date: any;
  totalWorker = 0;
  isLoading: boolean = true;

  pageNumber=1;

  constructor(
    private countryService: CountryService,
    private laborService: LaborService,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    this.labor.countryId = 0
    this.getCountry();
    this.getDate();
    this.getLabor();
  }

  getDate() {
    this.previousMonth.setMonth(this.previousMonth.getMonth() - 1);
    this.labor.monthYear = this.datePipe.transform(this.previousMonth,'MMM-yyyy');
  }

  monthSelected(month: string) {
    let monthDate = new Date(month);
    this.labor.monthYear = this.datePipe.transform(monthDate, 'MMM-yyyy');
    this.getLabor();
  }

  onSubmit(month: string) {
    this.labor.estateId = 3;
    this.laborService.addLabor(this.labor)
    .subscribe(
      Response => {
      swal.fire({
        title: 'Done!',
        text: 'Labor successfully submitted!',
        icon: 'success',
        showConfirmButton: false,
        timer: 1000
      });
      this.reset();
      let monthDate = new Date(month);
      this.labor.monthYear = this.datePipe.transform(monthDate, 'MMM-yyyy');
      this.getLabor();
      this.labor.countryId = 0
    }, Error=>{
      swal.fire({
        text: 'Please fil up the form',
        icon: 'error'
      });
    });
  }

  reset() {
    this.labor = {} as Labor;
  }

  getCountry() {
    this.countryService.getCountry()
    .subscribe(
      Response => {
      this.countries = Response;
      this.filterCountries = this.countries.filter((e) => e.isActive == true);
    });
  }

  getLabor() {
    setTimeout(() => {
    this.laborService.getLabor()
    .subscribe(
      Response => {
      this.labors = Response;
      this.filterLabors = this.labors.filter(e => e.monthYear == this.labor.monthYear);
      this.sumTable(this.labors);
      this.isLoading = false;
    });
  }, 2000)
}

  sumTable(row: Labor[]) {
    row.forEach(x => {
        x.total = x.fieldCheckrole + x.fieldContractor + x.tapperCheckrole + x.tapperContractor;
    });
  }

  delete(id: number) {
    swal.fire({
        title: 'Are you sure to delete ?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes',
        denyButtonText: 'Cancel',
      })
      .then((result) => {
        if (result.isConfirmed) {
          this.laborService.deleteLabor(id)
          .subscribe(
            Response => {
            swal.fire(
              'Deleted!',
              'Labor information has been deleted.',
              'success'
            ),
              this.getLabor();
          });
        } else if (result.isDenied) {
        }
      });
  }
}
