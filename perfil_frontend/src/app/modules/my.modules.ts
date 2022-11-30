import { PalestrantesComponent } from './../components/palestrantes/palestrantes.component';
import { EventosComponent } from './../components/eventos/eventos.component';
import { NgModule } from "@angular/core";

@NgModule({
  declarations: [EventosComponent, PalestrantesComponent],
  exports: [EventosComponent, PalestrantesComponent]
})
export class MyModules{}
