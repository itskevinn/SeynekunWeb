import { Component, OnInit } from '@angular/core';
import { Lote } from '../../models/modelo-lote/lote';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-lote-registro',
  templateUrl: './lote-registro.component.html',
  styleUrls: ['./lote-registro.component.css']
})
export class LoteRegistroComponent implements OnInit {
  lote: Lote;
  formGroup: FormGroup;
  fechaFloracion = new Date();
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.lote = new Lote();
    this.crearFormulario();    
  }
  crearFormulario() {
    this.lote.numeroLote = 0;
    this.lote.variedad = "";
    this.lote.numeroArbol = 0;
    this.lote.sistemaRenovacion = "";
    this.lote.fechaSiembra = null;
    this.lote.cultivo = "";
    this.lote.fechaCosecha = null;
    this.lote.fechaFloracion = null;
    this.lote.estimadoCosecha = 0;
    this.lote.tipoEstimado = "";
    this.lote.distanciaSiembra= 0;
    this.formGroup = this.formBuilder.group({
      numeroLote: [this.lote.numeroLote, [Validators.required, Validators.minLength(7)]],
      variedad: [this.lote.variedad, Validators.required],
      numeroArbol: [this.lote.numeroArbol, Validators.required],
      distanciaSiembra: [this.lote.distanciaSiembra, Validators.required],
      sistemaRenovacion: [this.lote.sistemaRenovacion, Validators.required],
      fechaSiembra: [this.lote.fechaSiembra, Validators.required],
      cultivo: [this.lote.cultivo, Validators.required],
      fechaCosecha: [this.lote.fechaCosecha, Validators.required],
      fechaFloracion: [this.lote.fechaFloracion, Validators.required],
      estimadoCosecha: [this.lote.estimadoCosecha, Validators.required],
      tipoEstimado: [this.lote.tipoEstimado, Validators.required],
    });
  }
  validar(){
    if(!this.formGroup.invalid){
     // this.registrar();
    }
  }
  get control() {
    return this.formGroup.controls;
  }
  /*registrar() {
    this.lote=this.formGroup.value;
    this.loteService.post(this.lote).subscribe(l => {
      if (l != null) {
        alert('Lote registrado exitosamente');
        this.lote = l;
      }
    });
  }*/
}
