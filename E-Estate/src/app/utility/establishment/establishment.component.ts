import { Component, OnInit } from '@angular/core';
import { Establishment } from 'src/app/_model/establishment';
import { EstablishmentService } from 'src/app/_services/establishment.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-establishment',
  templateUrl: './establishment.component.html',
  styleUrls: ['./establishment.component.css'],
})
export class EstablishmentComponent implements OnInit {
  establishment = {} as Establishment;

  establishments: Establishment[] = [];

  term = '';

  isLoading: boolean = true;

  pageNumber = 1;

  constructor(private establishmentService: EstablishmentService) {}

  ngOnInit(): void {
    this.getEstablishment();
  }

  submit() {
    this.establishment.isActive = true;
    this.establishmentService.addEstablishment(this.establishment)
      .subscribe(
        Response => {
        swal.fire({
          title: 'Done!',
          text: 'Establishment successfully submitted!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });

        this.reset();
        this.ngOnInit();
      });
  }

  reset() {
    this.establishment = {} as Establishment;
  }

  getEstablishment() {
    setTimeout(() => {
    this.establishmentService.getEstablishment()
    .subscribe(
      Response => {
      this.establishments = Response;
      this.isLoading = false;
    });
  }, 2000)
}

  status(id:number){
    this.establishmentService.updateStatus(id)
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
