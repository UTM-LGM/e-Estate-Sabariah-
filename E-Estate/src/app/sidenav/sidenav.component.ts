import { Component } from '@angular/core';
import { User } from '../_model/user';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css'],
})
export class SidenavComponent {
  user = {} as User;
}
