import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  /*
   * Service Method to retries Eventos
   */
  getEventos(eventos: any): Promise<any> {
    return new Promise((resolve, reject) => {
      //POST user/SolicitarDadosUsuario
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
      };
      this.http
        .get('https://localhost:44334/api/Eventos', httpOptions)
        .subscribe(
          (response: any) => {
            resolve(response);
          },
          (error) => {
            resolve('error');
            console.log(error);
          }
        );
    });
  }

  /*
   * Service Method to update Eventos
   */
  setEventos(): void {}
}
