import { EventosComponent } from './../../components/eventos/eventos.component';
import { MyModules } from './../../modules/my.modules';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { HomePage } from './home.page';

import { HomePageRoutingModule } from './home-routing.module';


@NgModule({
    declarations: [HomePage, EventosComponent],
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        HomePageRoutingModule,
        MyModules
    ],
})
export class HomePageModule {}
