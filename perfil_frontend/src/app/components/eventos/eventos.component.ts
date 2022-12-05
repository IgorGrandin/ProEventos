import { UserService } from './../../services/eventos.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any = [];

  constructor(private userService: UserService) {}

  ngOnInit() {
    console.log("stored:");
    this.userService.getEventos(this.eventos).then((storedEventos) => {
      this.eventos = storedEventos;
      console.log(this.eventos);
    });
  }
}
