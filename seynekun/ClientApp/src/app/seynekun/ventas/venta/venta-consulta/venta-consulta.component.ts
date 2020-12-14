import { Component, OnInit } from '@angular/core';
import { Venta } from 'src/app/seynekun/models/modelo-venta/venta';
import { VentaService } from 'src/app/servicios/servicio-venta/venta.service';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
@Component({
  selector: 'app-venta-consulta',
  templateUrl: './venta-consulta.component.html',
  styleUrls: ['./venta-consulta.component.css']
})
export class VentaConsultaComponent implements OnInit {
  ventas: Venta[];
  listaVacia: Boolean = true;
  textoABuscar: String;

  constructor(private ventaService: VentaService) { this.downloadPDF() }

  ngOnInit(): void {
    this.ventaService.gets().subscribe((result) => {
      this.ventas = result;
    });
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
      docResult.save(`ventas_${new Date().toLocaleDateString().toString()}.pdf`);
    });
  }

}
