import { PalestrantesComponent } from './../components/palestrantes/palestrantes.component';
import { EventosComponent } from './../components/eventos/eventos.component';
import { NgModule } from "@angular/core";
import { IonicModule } from '@ionic/angular';

@NgModule({
  declarations: [PalestrantesComponent],
  imports: [IonicModule],
  exports: [PalestrantesComponent]
})
export class MyModules{}
