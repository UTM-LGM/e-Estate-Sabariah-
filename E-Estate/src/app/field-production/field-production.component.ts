import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Field } from '../_model/field';
import { FieldProduction } from '../_model/fieldProduction';
import { FieldProductionService } from '../_services/field-production.service';
import { FieldService } from '../_services/field.service';
import swal from 'sweetalert2';
import { MatDialog } from '@angular/material/dialog';
import { FieldProductionDetailComponent } from '../field-production-detail/field-production-detail.component';


@Component({
  selector: 'app-field-production',
  templateUrl: './field-production.component.html',
  styleUrls: ['./field-production.component.css'],
})
export class FieldProductionComponent implements OnInit {
  previousMonth = new Date();

  fields: Field[] = [];
  filterFields: Field[] = [];

  products: FieldProduction[] = [];
  productions: FieldProduction[] = [];
  filterProductions: FieldProduction[] = [];
  cuplumpDry: FieldProduction[] = [];
  latexDry: FieldProduction[] = [];
  totalDry: FieldProduction[] = [];

  date: any;
  cuplump: any;
  latex: any;
  total: any;
  value: any;

  currentDate = new Date();

  constructor(
    private fieldService: FieldService,
    private datePipe: DatePipe,
    private productionService: FieldProductionService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getDate();
    this.getField();
    this.date = this.datePipe.transform(this.previousMonth, 'MMM-yyyy');
    this.getAllProduction();
  }

  monthSelected(month: string) {
    let monthDate = new Date(month);
    this.date = this.datePipe.transform(monthDate, 'MMM-yyyy');
    this.products.forEach(y => y.monthYear = this.datePipe.transform(monthDate, 'MMM-yyyy'));
    this.getAllProduction();
  }


  getDate() {
    this.previousMonth.setMonth(this.previousMonth.getMonth() - 1);
  }

  getField() {
    this.fieldService.getField()
    .subscribe(
      Response => {
      this.fields = Response;
      this.filterFields = this.fields.filter((e) => e.isActive == true);
      this.getProducts(this.filterFields);
    });
  }

  add() {
    this.productionService.addProduction(this.products)
      .subscribe(
        Response =>{
           swal.fire({
            title: 'Done!',
            text: 'Field Production information successfully submitted!',
            icon: 'success',
            showConfirmButton: false,
            timer: 1000
          });  
            this.getAllProduction();
            this.products = [];
            this.getField();
        }
      );
  }

  getProducts(Fields: Field[]) {
    Fields.forEach(x => {
      let product = {} as FieldProduction;  
      product.cuplump = 0,
      product.cuplumpDRC = 0.00,
      product.latex = 0,
      product.latexDRC = 0,
      product.noTaskTap = 0,
      product.noTaskUntap = 0,
      product.fieldId = x.id,
      product.monthYear = this.datePipe.transform(this.previousMonth,'MMM-yyyy');
      this.products.push(product);

    });
  }

  getAllProduction() {
    this.productionService.getAllProduction()
    .subscribe(
      Response => {
      this.productions = Response;
      this.filterProductions = this.productions.filter(e => e.monthYear == this.date);
      this.calculateCuplumpDry(this.filterProductions, this.cuplumpDry);
      this.calculateLatexDry(this.filterProductions,this.latexDry,this.totalDry);
    });
  }


  calculateCuplumpDry(data: any, cuplump: any) {
    this.value = data;
    this.cuplump = cuplump;
    for (let j = 0; j < data.length; j++) {
      this.cuplump[j] = this.value[j].cuplump * (this.value[j].cuplumpDRC / 100);
    }
  }
    
    calculateLatexDry(data: any, latex: any, total: any) {
    this.value = data;
    this.latex = latex;
    this.total = total;
    for (let j = 0; j < data.length; j++) {
      this.latex[j] = this.value[j].latex * (this.value[j].latexDRC / 100);
      this.total[j] = this.cuplump[j] + this.latex[j];
    }
  }

  openDialog(product: any): void {
    const dialogRef = this.dialog.open(FieldProductionDetailComponent, {
      height: '295px',
      data: { data: product },
    });

    dialogRef.afterClosed()
    .subscribe(
      Response => {
      this.getAllProduction();
    });
  }
}
