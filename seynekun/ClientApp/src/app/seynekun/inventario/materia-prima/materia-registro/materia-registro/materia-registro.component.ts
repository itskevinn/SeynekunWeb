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
import { ConsultaProductorComponent } from "src/app/modal/consulta-productor-modal/consulta-productor/consulta-productor.component";
import { EventoService } from "src/app/servicios/servicio-evento/evento.service";
defineLocale("es", esLocale);

@Component({
  selector: "app-materia-registro",
  templateUrl: "./materia-registro.component.html",
  styleUrls: ["./materia-registro.component.css"],
})
export class MateriaRegistroComponent implements OnInit {
  materia: MateriaPrima;
  formGroup: FormGroup;
  tipos: string[] = ["Panela", "Café", "Cacao"]
  codigoProductor: string;
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
    private localeService: BsLocaleService,
    private eventoService: EventoService) {
    this.fechaMinima = new Date();
    this.fechaMaxima = new Date();
    this.fechaMinima.setDate(this.fechaMinima.getDate() - 7);
    this.fechaMaxima.setDate(this.fechaMaxima.getDate());
  }

  ngOnInit(): void {
    this.obtenerProductores();
    this.materia = new MateriaPrima();
    this.crearFormulario();
    this.recibirId();
  }
  cambiarId() {
    if (!this.modalService.hasOpenModals()) {
      this.recibirId();
      this.control.codigoProductor.setValue(this.codigoProductor);
    }
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
  recibirId() {
    this.eventoService.codigo.subscribe(
      (estado) => (this.codigoProductor = estado)
    );
    this.control.codigoProductor.setValue(this.codigoProductor);
    this.colocarValor();
  }
  colocarValor() {
    this.eventoService.codigo.subscribe(
      (estado) => (this.codigoProductor = estado)
    );
    this.control.codigoProductor.setValue(this.codigoProductor);
  }

  cambiarTipo(e) {
    this.control.tipo.setValue(e.target.value, {
      onlySelf: true,
    });
    console.log(this.control.tipo.value);
  }
  mostrarProductores() {
    this.modalService.open(ConsultaProductorComponent, { size: 'lg' });
  }
  crearFormulario() {
    this.materia.fecha = new Date();
    this.materia.codigo = "";
    this.materia.codigoProductor = "";
    this.materia.cantidad = null;
    this.materia.nombreProductor = "";
    this.materia.tipo = "";
    this.formGroup = this.formBuilder.group({
      fecha: [this.materia.fecha, Validators.required],
      codigo: [this.materia.codigo, Validators.required],
      codigoProductor: [this.materia.codigoProductor, Validators.required],
      cantidad: [this.materia.cantidad, Validators.required],
      nombreProductor: [this.materia.nombreProductor, Validators.required],
      tipo: [this.materia.tipo, Validators.required]
    });
  }
  onSubmit() {
    this.registrar();
  }
  get control() {
    return this.formGroup.controls;
  }
  registrar() {
    this.materia = this.formGroup.value;
    console.log(this.materia.tipo);
    this.materiaService.post(this.materia).subscribe((e) => {
      if (e != null) {
        this.materia = e;
        this.formGroup.reset();
      }
    });
  }
}
