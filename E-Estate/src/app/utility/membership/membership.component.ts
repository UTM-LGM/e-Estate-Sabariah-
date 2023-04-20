import { Component, OnInit } from '@angular/core';
import { MembershipType } from 'src/app/_model/membership';
import { MembershipService } from 'src/app/_services/membership.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-membership',
  templateUrl: './membership.component.html',
  styleUrls: ['./membership.component.css'],
})
export class MembershipComponent implements OnInit {
  membershipType = {} as MembershipType;

  membershipTypes: MembershipType[] = [];

  term = '';

  isLoading: boolean = true;

  pageNumber =1;

  constructor(private membershipService: MembershipService) {}

  ngOnInit(): void {
    this.getMembership();
  }

  submit() {
    this.membershipType.isActive = true;
    this.membershipService.addMembership(this.membershipType)
      .subscribe(
        Response => {
        swal.fire({
          title: 'Done!',
          text: 'Membership Type successfully submitted!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });
        this.reset();
        this.ngOnInit();
      });
  }

  reset() {
    this.membershipType = {} as MembershipType;
  }

  getMembership() {
    setTimeout(() => {
    this.membershipService.getAllMembership()
    .subscribe(Response => {
      this.membershipTypes = Response;
      this.isLoading = false;
    });
  }, 2000)
}

  status(id:number){
    this.membershipService.updateStatus(id)
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
