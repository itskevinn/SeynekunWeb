import { Component, OnInit } from '@angular/core';
import { MateriaPrima } from 'src/app/seynekun/models/modelo-materia-prima/materia-prima';
import { MateriaPrimaService } from 'src/app/servicios/servicio-materia/materia-prima.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { EventoService } from 'src/app/servicios/servicio-evento/evento.service';

@Component({
  selector: 'app-consulta-materia',
  templateUrl: './consulta-materia.component.html',
  styleUrls: ['./consulta-materia.component.css']
})
export class ConsultaMateriaComponent implements OnInit {
  materiaDisponibles: MateriaPrima[]
  textoABuscar: string;
  constructor(private materiaService: MateriaPrimaService, public activeModal: NgbActiveModal, private eventoServicio: EventoService) { }

  ngOnInit(): void {
    this.materiaService.getDisponibles().subscribe((result) => {
      this.materiaDisponibles = result;
    });
  }
  enviarId(id: string) {
    this.eventoServicio.cambiarId(id);
    console.log(id)
  }
}
