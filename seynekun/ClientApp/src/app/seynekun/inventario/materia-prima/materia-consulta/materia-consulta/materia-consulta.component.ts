import { Component, OnInit } from '@angular/core';
import { MateriaPrimaService } from 'src/app/servicios/servicio-materia/materia-prima.service';
import { MateriaPrima } from 'src/app/seynekun/models/modelo-materia-prima/materia-prima';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
@Component({
  selector: 'app-materia-consulta',
  templateUrl: './materia-consulta.component.html',
  styleUrls: ['./materia-consulta.component.css']
})
export class MateriaConsultaComponent implements OnInit {

  materiaPrimas: MateriaPrima[];
  listaVacia: boolean = true;
  materiaPrima: MateriaPrima;
  tipo: string;
  tipos = ["Cacao", "Panela", "Café"]
  cantidadEmpleados: Number;
  textoABuscar: String;
  constructor(private materiaPrimaService: MateriaPrimaService) { }

  ngOnInit(): void {
    this.materiaPrimaService.gets().subscribe((result) => {
      this.materiaPrimas = result;
    });
  }
  cambiarTipo(e) {
    this.tipo = e.target.value;
    this.textoABuscar = this.tipo;
  }
  downloadPDF() {
    // Extraemos el
    const DATA = document.getElementById('htmlData');
    const doc = new jsPDF('p', 'pt', 'a4');
    const options = {
      background: 'white',
      scale: 3
    };
    html2canvas(DATA, options).then((canvas) => {

      const img = canvas.toDataURL('image/PNG');

      // Add image Canvas to PDF
      const bufferX = 15;
      const bufferY = 15;
      const imgProps = (doc as any).getImageProperties(img);
      const pdfWidth = doc.internal.pageSize.getWidth() - 2 * bufferX;
      const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;
      doc.addImage(img, 'PNG', bufferX, bufferY, pdfWidth, pdfHeight, undefined, 'FAST');
      return doc;
    }).then((docResult) => {
      docResult.save(`materia_prima_${new Date().toLocaleDateString().toString()}.pdf`);
    });
  }

}
