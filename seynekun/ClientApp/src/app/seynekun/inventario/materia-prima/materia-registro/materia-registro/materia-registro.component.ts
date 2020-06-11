import { Component, OnInit } from "@angular/core";
import { MateriaPrima } from "src/app/seynekun/models/modelo-materia-prima/materia-prima";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { MateriaPrimaService } from "src/app/servicios/servicio-materia/materia-prima.service";
import { Productor } from "src/app/seynekun/models/modelo-productor/productor";
import { ProductorService } from "src/app/servicios/servicio-de-productor/productor.service";
import {
  BsDatepickerDirective,
  BsLocaleService,
} from "ngx-bootstrap/datepicker";
import { defineLocale, esLocale } from "ngx-bootstrap/chronos";
defineLocale("es", esLocale);

@Component({
  selector: "app-materia-registro",
  templateUrl: "./materia-registro.component.html",
  styleUrls: ["./materia-registro.component.css"],
})
export class MateriaRegistroComponent implements OnInit {
  materia: MateriaPrima;
  formGroup: FormGroup;
  unidadMedidas: string[] = ["Gramo", "Kg", "Tonelada"];
  productores: Productor[];
  bsValue = new Date();
  fechaMinima: Date;
  fechaMaxima: Date;
  constructor(
    private materiaService: MateriaPrimaService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private productorService: ProductorService,
    private localeService: BsLocaleService) {
    this.fechaMinima = new Date();
    this.fechaMaxima = new Date();
    this.fechaMinima.setDate(this.fechaMinima.getDate() - 7);
    this.fechaMaxima.setDate(this.fechaMaxima.getDate());
  }

  ngOnInit(): void {
    this.obtenerProductores();
    this.materia = new MateriaPrima();
    this.crearFormulario();
  }
  obtenerProductores() {
    this.productorService.gets().subscribe((result) => {
      this.productores = result;
    });
  }
  cortarCodigo(texto: string) {
    var nombre = texto.split("-");
    for (let i = 0; i < nombre.length; i++) {
      console.log(nombre[0]);
      return nombre[0];
    }
  }
  crearFormulario() {
    this.materia.fecha = new Date();
    this.materia.codigo = "";
    this.materia.codigoProductor = "";
    this.materia.cantidad = null;
    this.materia.nombreProductor = "";
    this.formGroup = this.formBuilder.group({
      fecha: [this.materia.fecha, Validators.required],
      codigo: [this.materia.codigo, Validators.required],
      codigoProductor: [this.materia.codigoProductor, Validators.required],
      cantidad: [this.materia.cantidad, Validators.required],
      nombreProductor: [this.materia.nombreProductor, Validators.required]
    });
  }
  cambiarCodigo(e) {
    {
      this.control.codigoProductor.setValue(this.cortarCodigo(e.target.value), {
        onlySelf: true,
      });
      this.control.nombreProductor.setValue(this.cortarNombre(e.target.value), {
        onlySelf: true,
      });
    }
  }
  cortarNombre(texto: string) {
    var nombre = texto.split(" - ");
    for (let i = 0; i < nombre.length; i++) {
      console.log(nombre[1]);
      return nombre[1];
    }
  }
  onSubmit() {
    this.registrar();
  }
  get control() {
    return this.formGroup.controls;
  }
  registrar() {
    this.materia = this.formGroup.value;
    this.materiaService.post(this.materia).subscribe((e) => {
      if (e != null) {
        this.materia = e;
        this.formGroup.reset();
      }
    });
  }
}
