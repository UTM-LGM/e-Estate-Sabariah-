import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject } from '@angular/core';
import { FieldProduction } from '../_model/fieldProduction';
import { FieldProductionService } from '../_services/field-production.service';
import swal from 'sweetalert2';
import { FieldProductionComponent } from '../field-production/field-production.component';

@Component({
  selector: 'app-field-production-detail',
  templateUrl: './field-production-detail.component.html',
  styleUrls: ['./field-production-detail.component.css'],
})
export class FieldProductionDetailComponent implements OnInit {
  product = {} as FieldProduction;

  constructor(
    public dialogRef: MatDialogRef<FieldProductionComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { data: FieldProduction },
    private productionService: FieldProductionService
  ) {}

  ngOnInit(): void {
    this.product = this.data.data;
  }

  update() {
    this.productionService.updateProduction(this.product)
      .subscribe(
        Response => {
        swal.fire({
          title: 'Done!',
          text: 'Production successfully updated!',
          icon: 'success',
          showConfirmButton: false,
          timer: 1000
        });

        this.dialogRef.close();
      });
  }

  back() {
    this.dialogRef.close();
  }
}
