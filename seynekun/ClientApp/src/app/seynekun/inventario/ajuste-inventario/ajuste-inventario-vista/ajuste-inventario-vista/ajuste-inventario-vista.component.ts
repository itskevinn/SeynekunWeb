import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { AjusteInventarioService } from 'src/app/servicios/servicio-ajuste/ajuste-inventario.service';
import { AjusteDeInventario } from 'src/app/seynekun/models/modelo-ajuste-inventario/ajuste-de-inventario';
import { AlertaModalPreguntaComponent } from 'src/app/@base/alerta-modal-pregunta/alerta-modal-pregunta/alerta-modal-pregunta.component';
import { AlertaModalOkComponent } from 'src/app/@base/alerta-modal/alerta-modal.component';

@Component({
  selector: 'app-ajuste-inventario-vista',
  templateUrl: './ajuste-inventario-vista.component.html',
  styleUrls: ['./ajuste-inventario-vista.component.css']
})
export class AjusteInventarioVistaComponent implements OnInit {

  ajusteInventario: AjusteDeInventario;
  seEncontro: Boolean;
  respuesta: boolean;

  constructor(
    private ajusteService: AjusteInventarioService,
    private rutaActiva: ActivatedRoute,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    const codigo = this.rutaActiva.snapshot.params.id;
    this.ajusteService.get(codigo).subscribe((result) => {
      this.ajusteInventario = result;
      this.ajusteInventario != null
        ? (this.seEncontro = true)
        : (this.seEncontro = false);
    });
  }

  eliminar(){
    const messageBox = this.modalService.open(AlertaModalPreguntaComponent);
    messageBox.componentInstance.titulo = "¿Desea eliminar esta ajueste?";
    messageBox.componentInstance.mensaje = "Esta acción no es reversible";
    messageBox.result.then((result) => {
      this.respuesta = result;
      if (this.respuesta === true) {
        this.ajusteService.delete(this.ajusteInventario).subscribe((p) => {
          if (p != null) {
            this.ajusteInventario = null;
            const messageBox = this.modalService.open(AlertaModalOkComponent);
            messageBox.componentInstance.titulo = "Ajuste eliminado";
            window.location.reload();
          }
        });
      }
      else {
        this.modalService.dismissAll();
      }
    });
  }
}
