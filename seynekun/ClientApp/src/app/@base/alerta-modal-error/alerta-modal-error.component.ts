import { Component, OnInit, Input } from '@angular/core'
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap'

@Component({
  selector: 'app-alerta-modal-error',
  templateUrl: './alerta-modal-error.component.html',
  styleUrls: ['./alerta-modal-error.component.css'],
})
export class AlertaModalErrorComponent implements OnInit {
  constructor(public activeModal: NgbActiveModal) {}

  @Input() titulo;

  @Input() mensaje;

  ngOnInit(): void {}
}
