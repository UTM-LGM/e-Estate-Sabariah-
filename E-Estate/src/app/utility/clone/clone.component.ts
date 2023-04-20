import { Component, OnInit } from '@angular/core';
import { Clone } from 'src/app/_model/clone';
import { CloneService } from 'src/app/_services/clone.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-clone',
  templateUrl: './clone.component.html',
  styleUrls: ['./clone.component.css'],
})
export class CloneComponent implements OnInit {
  clone = {} as Clone;

  term = '';

  clones: Clone[] = [];

  isLoading: boolean = true;

  pageNumber = 1;

  constructor(private cloneService: CloneService) {}

  ngOnInit(): void {
    this.getClone();
  }

  submit() {
    this.clone.isActive = true;
    this.cloneService.addClone(this.clone)
    .subscribe(
      Response => {
      swal.fire({
        title: 'Done!',
        text: 'Clone successfully submitted!',
        icon: 'success',
        showConfirmButton: false,
        timer: 1000
      });

      this.reset();
      this.ngOnInit();
    });
  }

  reset() {
    this.clone = {} as Clone;
  }

  getClone() {
    setTimeout(() => {
    this.cloneService.getClone()
    .subscribe(
      Response => {
      this.clones = Response;
      this.isLoading = false;
    });
  }, 2000)
}

  status(id:number){
    this.cloneService.updateStatus(id)
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
