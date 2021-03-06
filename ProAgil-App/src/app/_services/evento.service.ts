import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../_models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {
  baseUrl = 'http://localhost:5000/api/evento';
  
  constructor(private http: HttpClient) { 
  }

  getAllEvento() : Observable<Evento[]>{
    return this.http.get<Evento[]>(this.baseUrl);
  }

  getEventoByTema(tema: string) : Observable<Evento[]>{
    return this.http.get<Evento[]>(`${this.baseUrl}/getTema/${tema}`);
  }

  getEventoById(id: number) : Observable<Evento>{
    return this.http.get<Evento>(`${this.baseUrl}/${id}`);
  }

  postEvento(evento: Evento) {
    return this.http.post<Evento>(`${this.baseUrl}`, evento);
  }

  postUpload(file: File[], name: string){
    const fileToUpload = file[0];
    console.log(fileToUpload)
    const formData = new FormData();
    formData.append("file", fileToUpload, name);
    return this.http.post(`${this.baseUrl}/upload`, formData);
  }

  putEvento(evento: Evento) {
    /*console.log(typeof(evento.lotes[0].id), "id")
    console.log(typeof(evento.lotes[0].nome), "nome")
    console.log(typeof(evento.lotes[0].preco), "preco" )
    console.log(typeof(evento.lotes[0].quantidade), "quantidade")
    console.log(typeof(evento.lotes[0].dataInicio), "data inicio")
    console.log(typeof(evento.lotes[0].dataFim), "data fim")*/

    return this.http.put(`${this.baseUrl}/${evento.id}`, evento);
  }

  deleteEvento(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`)
  }

}
