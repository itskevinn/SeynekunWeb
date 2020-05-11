import { Component, OnInit, Input } from "@angular/core";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: "app-alerta-modal-pregunta",
  templateUrl: "./alerta-modal-pregunta.component.html",
  styleUrls: ["./alerta-modal-pregunta.component.css"],
})
export class AlertaModalPreguntaComponent implements OnInit {
  ok: boolean = true;
  constructor(public activeModal: NgbActiveModal) {}

  @Input() titulo;

  @Input() mensaje;

  ngOnInit(): void {}
  confirmar() {
    this.ok = true;
  }
  cancelar() {
    this.ok = false;
  }
}
