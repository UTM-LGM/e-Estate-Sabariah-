import { Component } from '@angular/core';

@Component({
  selector: 'app-cost-info',
  templateUrl: './cost-info.component.html',
  styleUrls: ['./cost-info.component.css'],
})
export class CostInfoComponent {
  activeButton: number = 1;

  setActiveButton(buttonNumber: number) {
    this.activeButton = buttonNumber;
  }
}
