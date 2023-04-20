import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver } from '@angular/cdk/layout';
import { User } from 'src/app/_model/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-layout',
  templateUrl: './home-layout.component.html',
  styleUrls: ['./home-layout.component.css'],
})
export class HomeLayoutComponent {
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;

  user = {} as User;

  constructor(
    private observer: BreakpointObserver,
    private changeDetector: ChangeDetectorRef,
    private router: Router
  ) {}

  ngAfterViewInit() {
    this.observer.observe(['(max-width: 800px)']).subscribe((res) => {
      if (res.matches) {
        this.sidenav.mode = 'over';
        this.sidenav.close();
      } else {
        this.sidenav.mode = 'side';
        this.sidenav.open();
      }
    });
  }

  ngAfterViewChecked() {
    this.changeDetector.detectChanges();
  }

  logOut() {
    this.router.navigateByUrl('/login');
  }
}
