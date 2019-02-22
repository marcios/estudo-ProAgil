import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {


  eventos: any  = []
  constructor(private http: HttpClient) { 
    
  }

  getEventos(){
     this.http.get('http://localhost:5000/api/values')
                            .subscribe(response=> {
                              this.eventos = response
                            },error => {
                              console.error(error);
                            })
  }

  ngOnInit() {

    this.getEventos();
  }

}
