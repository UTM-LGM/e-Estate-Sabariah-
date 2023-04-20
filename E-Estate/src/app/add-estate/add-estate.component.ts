import { Component, OnInit } from '@angular/core';
import { Establishment } from '../_model/establishment';
import { Estate } from '../_model/estate';
import { FinancialYear } from '../_model/financialYear';
import { MembershipType } from '../_model/membership';
import { State } from '../_model/state';
import { Town } from '../_model/town';
import { EstablishmentService } from '../_services/establishment.service';
import { EstateService } from '../_services/estate.service';
import { FinancialYearService } from '../_services/financial-year.service';
import { MembershipService } from '../_services/membership.service';
import { StateService } from '../_services/state.service';
import { TownService } from '../_services/town.service';
import swal from 'sweetalert2';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-add-estate',
  templateUrl: './add-estate.component.html',
  styleUrls: ['./add-estate.component.css'],
})
export class AddEstateComponent implements OnInit {
  estate: Estate = {} as Estate;

  states: State[] = [];
  filterStates: State[] = [];

  towns: Town[] = [];
  filterTown: Town[] = [];
  filterTowns: Town[] = [];

  financialYears: FinancialYear[] = [];
  filterFinancialYears: FinancialYear[] = [];

  memberships: MembershipType[] = [];
  filterMemberships: MembershipType[] = [];

  establishments: Establishment[] = [];
  filterEstablishments: Establishment[] = [];


  constructor(
    private townService: TownService,
    private financialYearService: FinancialYearService,
    private membershipService: MembershipService,
    private establishmentService: EstablishmentService,
    private stateService: StateService,
    private estateService: EstateService,
    private route: ActivatedRoute,
    private location: Location,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.initialForm();
    this.getTown();
    this.getFinancialYear();
    this.getMembership();
    this.getEstablishment();
    this.getState();
  }

  initialForm(){
    this.estate.stateId = 0;
    this.estate.townId = 0;
    this.estate.financialYearId = 0;
    this.estate.membershipTypeId = 0;
    this.estate.establishmentId = 0;
  }

  onSubmit() {
    this.estate.isActive = true
    const id = this.route.snapshot.paramMap.get('id')
    this.estate.companyId = id !== null ? parseInt(id, 10) : 0,
    this.estateService.addEstate(this.estate)
    .subscribe(
      Response => {
        swal.fire({
          title: 'Done!',
          text: 'Estate successfully submitted!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });
        this.reset();
        this.initialForm();
      },
      Error=>{
        swal.fire({
          text: 'Please fil up the form',
          icon: 'error'
        });
      });
  }

  reset() {
    this.estate = {} as Estate;
  }

  gettown(event: any) {
    this.filterTown = this.towns.filter(e => e.stateId == event.target.value);
    this.filterTowns = this.filterTown.filter(e => e.isActive == true);
  }

  getTown() {
    this.townService.getTown()
    .subscribe(
      Response => {
      this.towns = Response;
    });
  }

  getFinancialYear() {
    this.financialYearService.getAllFinancialYear()
    .subscribe(
      Response => {
      this.financialYears = Response;
      this.filterFinancialYears = this.financialYears.filter(e => e.isActive == true);
    });
  }

  getMembership() {
    this.membershipService.getAllMembership()
    .subscribe(
      Response => {
      this.memberships = Response;
      this.filterMemberships = this.memberships.filter(e => e.isActive == true);
    });
  }

  getEstablishment() {
    this.establishmentService.getEstablishment()
    .subscribe(
      Response => {
      this.establishments = Response;
      this.filterEstablishments = this.establishments.filter(e => e.isActive == true);
    });
  }

  getState() {
    this.stateService.getState()
    .subscribe(
      Response => {
      this.states = Response;
      this.filterStates = this.states.filter(e => e.isActive == true);
    });
  }

  back(){
    this.location.back();
  }
}
