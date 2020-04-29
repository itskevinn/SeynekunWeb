import { Component, OnInit, Input } from '@angular/core'
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap'
@Component({
  selector: 'app-alerta-modal',
  templateUrl: './alerta-modal.component.html',
  styleUrls: ['./alerta-modal.component.css'],
})
export class AlertaModalOkComponent implements OnInit {
  constructor(public activeModal: NgbActiveModal) {}
  @Input() titulo
  @Input() mensaje
  ngOnInit(): void {}
}
 