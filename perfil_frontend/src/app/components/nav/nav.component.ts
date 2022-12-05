import { Component, OnInit } from '@angular/core';
import { MenuController } from '@ionic/angular';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {

  constructor(public menuCtrl: MenuController) { }

  ngOnInit() {}

  toggleMenu() {
    this.menuCtrl.toggle(); //Add this method to your button click function
  }

}
