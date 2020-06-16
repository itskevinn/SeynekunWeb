import { Component, OnInit, OnDestroy } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { EventoService } from "src/app/servicios/servicio-evento/evento.service";
import { Insumo } from "src/app/seynekun/models/modelo-insumo/insumo";
import { InsumoService } from "src/app/servicios/servicio-insumo/insumo.service";
import { ConsultaFabricanteComponent } from "src/app/modal/consulta-fabricante/consulta-fabricante/consulta-fabricante.component";
import { FichaTecnica } from "src/app/seynekun/models/modelo-ficha-tecnica/ficha-tecnica";
import { Subscription } from "rxjs";

@Component({
  selector: "app-insumo-registro",
  templateUrl: "./insumo-registro.component.html",
  styleUrls: ["./insumo-registro.component.css"],
})
export class RegistroInsumoComponent implements OnInit {
  insumo: Insumo;
  formGroup: FormGroup;
  formGroupFichaTecnica: FormGroup;
  insumos: Insumo[]
  fichaTecnica: FichaTecnica;
  idFabricante: string;
  ceChecked: boolean;
  ce: number
  colChecked: boolean;
  col:number
  efapa:number
  jas:number
  nop:number
  suscripcion: Subscription
  efapaChecked: boolean;
  jasChecked: boolean;
  nopChecked: boolean;
  constructor(
    private insumoService: InsumoService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private eventoService: EventoService) {
  }

  ngOnInit(): void {
    this.obtenerProductores();
    this.insumo = new Insumo();
    this.fichaTecnica = new FichaTecnica();
    this.crearFormulario();
    this.crearFormularioFichaTecnica();
  }
  cambiarId() {
    if (!this.modalService.hasOpenModals()) {
      this.recibirIdFabricante();
      this.control.idFabricante.setValue(this.idFabricante);
    }
  }
  obtenerProductores() {
    this.insumoService.gets().subscribe((result) => {
      this.insumos = result;
    });
  }
  cambiarCe() {
    this.ceChecked = !this.ceChecked;
    if (this.ceChecked) {
      this.controlFichaTecnica.ce.setValue(1);
      return;
    }
    this.controlFichaTecnica.ce.setValue(0);
  }
  cambiarEfapa() {
    this.efapaChecked = !this.efapaChecked;
    if (this.efapaChecked) {
      this.controlFichaTecnica.efapa.setValue(1);
      return;
    }
    this.controlFichaTecnica.efapa.setValue(0);
  }
  cambiarNop() {
    this.nopChecked = !this.nopChecked;
    if (this.nopChecked) {
      this.controlFichaTecnica.nop.setValue(1);
      return;
    }
    this.controlFichaTecnica.nop.setValue(0);
  }
  cambiarCol() {
    this.colChecked = !this.colChecked;
    if (this.colChecked) {
      this.controlFichaTecnica.col.setValue(1);
      if(this.fichaTecnica.col){
        console.log("si")
      }
      else if(!this.fichaTecnica.col) {
        console.log("no")
      }
      return;
    }
    this.controlFichaTecnica.col.setValue(0);
  }
  cambiarJas() {
    this.jasChecked = !this.jasChecked;
    if (this.jasChecked) {
      this.controlFichaTecnica.jas.setValue(1);
      return;
    }
    this.controlFichaTecnica.jas.setValue(0);
  }
  recibirIdFabricante() {
    this.suscripcion = this.eventoService.idFabricante.subscribe(
      (estado) => {
        (this.control.idFabricante.setValue(estado));
      }
    );
  }
  colocarValor() {
    this.suscripcion = this.eventoService.idFabricante.subscribe(
      (estado) => (this.idFabricante = estado)
    );
    this.control.idFabricante.setValue(this.idFabricante);
  }
  ngOnDestroy() {
    if (this.suscripcion != null) {
      this.suscripcion.unsubscribe();
    }
  }
  mostrarFabricantes() {
    this.modalService.open(ConsultaFabricanteComponent, { size: 'lg' });
  }
  crearFormulario() {
    this.insumo.id = "";
    this.insumo.idFabricante = "";
    this.insumo.nombre = "";
    this.insumo.uso = "";
    this.insumo.resultado = '';
    this.insumo.descripcion = "";
    this.insumo.registroIca = '';
    this.formGroup = this.formBuilder.group({
      id: [this.insumo.id, Validators.required],
      idFabricante: [this.insumo.idFabricante, Validators.required],
      nombre: [this.insumo.nombre, Validators.required],
      uso: [this.insumo.uso, Validators.required],
      registroIca: [this.insumo.registroIca, Validators.required],
      descripcion: [this.insumo.descripcion],
      resultado: [this.insumo.resultado],
      estado: ['Activo']
    });
  }
  crearFormularioFichaTecnica() {
    this.fichaTecnica.id = "";
    this.fichaTecnica.idInsumo = "";
    this.fichaTecnica.ingrediente = "";
    this.fichaTecnica.tipoIngrediente = "";
    this.fichaTecnica.ce = 0;
    this.fichaTecnica.numeroCas = '';
    this.fichaTecnica.observacion = "";
    this.fichaTecnica.col = 0;
    this.fichaTecnica.efapa = 0;
    this.fichaTecnica.nop = 0;
    this.fichaTecnica.jas = 0;
    this.formGroupFichaTecnica = this.formBuilder.group({
      id: [this.fichaTecnica.id, Validators.required],
      idInsumo: [this.insumo.id, Validators.required],
      ingrediente: [this.fichaTecnica.ingrediente, Validators.required],
      tipoIngrediente: [this.fichaTecnica.tipoIngrediente, Validators.required],
      ce: [this.fichaTecnica.ce],
      col: [this.fichaTecnica.col],
      efapa: [this.fichaTecnica.efapa],
      nop: [this.fichaTecnica.nop],
      jas: [this.fichaTecnica.jas],
      numeroCas: [this.fichaTecnica.numeroCas, Validators.required],
      observacion: [this.fichaTecnica.observacion],
    });
  }
  onSubmit() {
    this.registrar();
  }
  get control() {
    return this.formGroup.controls;
  }
  get controlFichaTecnica() {
    return this.formGroupFichaTecnica.controls;
  }
  colocarIdEnFichaTecnica() {
    this.fichaTecnica.idInsumo = this.control.id.value;
    this.controlFichaTecnica.idInsumo.setValue(this.insumo.id);
    this.controlFichaTecnica.idInsumo.setValue(this.control.id.value);
  }
  registrar() {
    this.insumo = this.formGroup.value;
    this.insumo.fichaTecnica = this.formGroupFichaTecnica.value;
    this.insumoService.post(this.insumo).subscribe((e) => {
      if (e != null) {
        this.insumo = e;
        this.formGroup.reset();
      }
    });
  }
}
