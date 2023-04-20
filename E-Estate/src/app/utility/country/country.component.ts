import { Component, OnInit } from '@angular/core';
import { Country } from 'src/app/_model/country';
import { CountryService } from 'src/app/_services/country.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css'],
})
export class CountryComponent implements OnInit {
  country = {} as Country;

  term = '';

  countries: Country[] = [];

  isLoading: boolean = true;

  pageNumber = 1;

  constructor(private countryService: CountryService) {}

  ngOnInit(): void {
    this.getCountry();
  }

  onSubmit() {
    this.country.isActive = true;
    this.countryService.addCountry(this.country)
    .subscribe(
      Response => {
      swal.fire({
        title: 'Done!',
        text: 'Country successfully submitted!',
        icon: 'success',
        showConfirmButton: false,
        timer: 1000
      });

      this.reset();
      this.ngOnInit();
    });
  }

  reset() {
    this.country = {} as Country;
  }

  getCountry() {
    setTimeout(() => {
    this.countryService.getCountry()
    .subscribe(Response => {
      this.countries = Response;
      this.isLoading = false;
    });
  }, 2000)
}

  status(id:number){
    this.countryService.updateStatus(id)
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
