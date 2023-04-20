import { Component, OnInit } from '@angular/core';
import { State } from 'src/app/_model/state';
import { StateService } from 'src/app/_services/state.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-state',
  templateUrl: './state.component.html',
  styleUrls: ['./state.component.css'],
})
export class StateComponent implements OnInit {
  state = {} as State;

  states: State[] = [];

  term = '';

  isLoading: boolean = true;

  pageNumber=1;

  constructor(private stateService: StateService) {}

  ngOnInit(): void {
    this.getState();
  }

  submit() {
    this.state.isActive = true;
    this.stateService.addState(this.state)
    .subscribe(
      Response => {
      swal.fire({
        title: 'Done!',
        text: 'State successfully submitted!',
        icon: 'success',
        showConfirmButton: false,
        timer: 1000
      });
      this.reset();
      this.ngOnInit();
    });
  }

  reset() {
    this.state = {} as State;
  }

  getState() {
    setTimeout(() => {
    this.stateService.getState()
    .subscribe(
      Response => {
      this.states = Response; 
      this.isLoading = false;
    });
  }, 2000)
}

  status(id:number){
    this.stateService.updateStatus(id)
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
