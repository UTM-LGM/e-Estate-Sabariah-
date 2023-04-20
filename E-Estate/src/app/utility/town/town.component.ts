import { Component, OnInit } from '@angular/core';
import { State } from 'src/app/_model/state';
import { Town } from 'src/app/_model/town';
import { StateService } from 'src/app/_services/state.service';
import { TownService } from 'src/app/_services/town.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-town',
  templateUrl: './town.component.html',
  styleUrls: ['./town.component.css'],
})
export class TownComponent implements OnInit {
  town = {} as Town;

  states: State[] = [];

  towns: Town[] = [];

  term = '';

  isLoading: boolean = true;

  pageNumber=1;


  constructor(
    private townService: TownService,
    private stateService: StateService
  ) {}

  ngOnInit(): void {
    this.town.stateId = 0
    this.getState();
    this.getTown();
  }

  submit() {
    this.town.isActive = true;
    this.townService.addTown(this.town)
    .subscribe(
      Response => {
      swal.fire({
        title: 'Done!',
        text: 'Town successfully submitted!',
        icon: 'success',
        showConfirmButton: false,
        timer: 1000
      });

      this.reset();
      this.ngOnInit();
    });
  }

  reset() {
    this.town = {} as Town;
  }

  getState() {
    this.stateService.getState()
    .subscribe(
      Response => {
      this.states = Response;
    });
  }

  getTown() {
    setTimeout(() => {
    this.townService.getTown()
    .subscribe(
      Response => {
      this.towns = Response;
      this.isLoading = false;

    });
  }, 2000)
}

  status(id:number){
    this.townService.updateStatus(id)
    .subscribe(
      Response => {
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
