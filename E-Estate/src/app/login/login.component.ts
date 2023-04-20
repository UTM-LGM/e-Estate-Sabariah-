import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SpinnerService } from '../_services/spinner.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  constructor(private router: Router, private spinnerService: SpinnerService) {}

  login() {
    this.spinnerService.requestStarted();
    setTimeout(() => {
      this.spinnerService.requestEnded();
      this.router.navigateByUrl('/e-estate');
    }, 2000);
  }
}
