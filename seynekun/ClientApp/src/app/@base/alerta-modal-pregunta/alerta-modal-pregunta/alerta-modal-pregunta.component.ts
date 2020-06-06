import { Component, OnInit, Input } from "@angular/core";
import { NgbActiveModal, NgbModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: "app-alerta-modal-pregunta",
  templateUrl: "./alerta-modal-pregunta.component.html",
  styleUrls: ["./alerta-modal-pregunta.component.css"],
})
export class AlertaModalPreguntaComponent implements OnInit {
  respuesta: boolean = true;
  constructor(public activeModal: NgbActiveModal) { }

  @Input() titulo;

  @Input() mensaje;

  ngOnInit(): void { }
  confirmar() {
    this.respuesta = true;
    this.activeModal.close(this.respuesta);
  }
  cancelar() {
    this.respuesta = false;
    this.activeModal.close(this.respuesta);
  }
}
