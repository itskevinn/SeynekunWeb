import { Component, OnInit } from '@angular/core';
import { Control } from 'src/app/seynekun/models/modelo-control/control';
import { ControlService } from 'src/app/servicios/servicio-control/control.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-control-vista',
  templateUrl: './control-vista.component.html',
  styleUrls: ['./control-vista.component.css']
})
export class ControlVistaComponent implements OnInit {

  seEncontro: Boolean;
  control: Control;

  constructor(private constrolService: ControlService, private rutaActiva: ActivatedRoute) { }

  ngOnInit(): void {
    this.buscarControl();
  }

  private buscarControl(){
    const codigo = this.rutaActiva.snapshot.params.id;
    this.constrolService.get(codigo).subscribe(result => {
      this.control = result;
      this.control != null ? this.seEncontro = true : this.seEncontro = false;      
    });
  }
}
