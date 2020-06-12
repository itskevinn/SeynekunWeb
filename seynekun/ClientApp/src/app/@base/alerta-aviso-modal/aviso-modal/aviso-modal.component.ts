import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-aviso-modal',
  templateUrl: './aviso-modal.component.html',
  styleUrls: ['./aviso-modal.component.css']
})
export class AvisoModalComponent implements OnInit {
  constructor(public activeModal: NgbActiveModal) {}
  @Input() titulo
  @Input() mensaje
  ngOnInit(): void {}
}
