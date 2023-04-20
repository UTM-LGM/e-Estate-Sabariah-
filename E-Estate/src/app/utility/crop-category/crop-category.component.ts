import { Component, OnInit } from '@angular/core';
import { CropCategory } from 'src/app/_model/cropCategory';
import { CropCategoryService } from 'src/app/_services/crop-category.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-crop-category',
  templateUrl: './crop-category.component.html',
  styleUrls: ['./crop-category.component.css'],
})
export class CropCategoryComponent implements OnInit {
  crop = {} as CropCategory;

  term = '';

  cropCategories: CropCategory[] = [];

  isLoading: boolean = true;

  pageNumber=1;

  constructor(private cropService: CropCategoryService) {}

  ngOnInit(): void {
    this.getCrop();
  }

  submit() {
    this.crop.isActive = true;
    this.cropService.addCrop(this.crop)
    .subscribe(
      Response => {
      swal.fire({
        title: 'Done!',
        text: 'Crop Category successfully submitted!',
        icon: 'success',
        showConfirmButton: false,
        timer: 1000
      });

      this.reset();
      this.ngOnInit();
    });
  }

  reset() {
    this.crop = {} as CropCategory;
  }

  getCrop() {
    setTimeout(() => {
    this.cropService.getCrop()
    .subscribe(Response => {
      this.cropCategories = Response;
      this.isLoading = false;
    });
  }, 2000)
}

  status(id:number){
    this.cropService.updateStatus(id)
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
