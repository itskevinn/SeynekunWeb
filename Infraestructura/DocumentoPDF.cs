using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Datos;
using Entity;

namespace Infraestructura
{
    public class DocumentoPDF
    {
        const string RUTA = @"C:\Users\User\Desktop\";
        FileStream fileStream;
        Document document;
        Paragraph pararagraph, paragrafph2, paragraph3;
        Phrase pharase, pharase2;

        private readonly SeynekunContext _context;

        public DocumentoPDF()
        {

        }

        public object CrearDocumentoPDF(List<Empleado> lista, string tipo)
        {
            string nombreDocumento = RUTA+"dim"+tipo+".PDF";
            fileStream = new FileStream(nombreDocumento, FileMode.Create, FileAccess.Write, FileShare.None);
            document = new Document(PageSize.LETTER);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, fileStream);
            document.Open();
            
            AgregarLogo();
            AgregarTitulo(tipo);

            string fecha = DateTime.Now.ToShortDateString();
            AgregarFecha(fecha);
            AgregarCuerpo();
            AgregarInformacionMuffinMagico();
            //AgregarInformacionCliente(cliente);
            AgregarInformacionLista(lista);

            document.Close();
            fileStream.Close();
            return document;
        }

        private void AgregarLogo()
        {
            Image image = Image.GetInstance(@"C:\Users\User\Documents\bbbbb.png");
            image.ScaleToFit(100.0F, 130.0F);
            image.SpacingBefore = 20.0F;
            image.SpacingAfter = 10.0F;
            image.SetAbsolutePosition(220, 660);
            document.Add(image);
        }

        private void AgregarTitulo(string titulo)
        {
            pararagraph = new Paragraph(titulo);
            pararagraph.Alignment = Element.ALIGN_CENTER;
            pararagraph.Alignment = Element.TITLE;
            pararagraph.Font.Size = 14;
            pararagraph.Font.Color = GrayColor.BLACK;
            pararagraph.Font.SetStyle("bold");
            pararagraph.Font.SetFamily("Times New Roman");
            document.Add(pararagraph);
        }

        private void AgregarFecha(string fecha)
        {
            pharase = new Phrase("Fecha: " + fecha);
            pararagraph.Alignment = Element.ALIGN_LEFT;
            pharase.Font.Size = 12;
            pharase.Font.Color = GrayColor.BLACK;
            pharase.Font.SetFamily("Times New Roman");
            pharase2 = new Phrase("Codigo: " + 10002);
            paragrafph2 = new Paragraph();
            paragrafph2.Add(pharase);
            paragrafph2.Add(Chunk.TABBING);
            paragrafph2.Add(Chunk.TABBING);
            paragrafph2.Add(Chunk.TABBING);
            paragrafph2.Add(Chunk.TABBING);
            paragrafph2.Add(Chunk.TABBING);
            paragrafph2.Add(Chunk.TABBING);
            paragrafph2.Add(Chunk.TABBING);
            pharase2.Font.Size = 12;
            pharase2.Font.Color = GrayColor.BLACK;
            pharase2.Font.SetFamily("Times New Roman");
            paragrafph2.Add(pharase2);
            document.Add(paragrafph2);
        }

        private void AgregarCuerpo()
        {
            Paragraph paragraph3 = new Paragraph();
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            paragrafph2 = new Paragraph("Muffin Magico");
            paragrafph2.Alignment = Element.ALIGN_CENTER;
            document.Add(paragrafph2);
            AgregarLinea();
            pharase = new Phrase("Datos de MuffinMagico:");
            document.Add(pharase);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            pararagraph = new Paragraph();
            document.Add(pharase);
            document.Add(Chunk.NEWLINE);
        }

        private void AgregarInformacionMuffinMagico()
        {
            pharase = new Phrase("Cedula: 1007610009");
            pararagraph.Add(pharase);
            pararagraph.Add(Chunk.TABBING);
            pararagraph.Add(Chunk.TABBING);
            pharase = new Phrase("Nombre: KEINER");
            pararagraph.Add(pharase);
            pararagraph.Add(Chunk.TABBING);
            pararagraph.Add(Chunk.TABBING);
            pharase = new Phrase("Sexo: Masculino");
            pararagraph.Add(pharase);
            pararagraph.Add(Chunk.TABBING);
            pararagraph.Add(Chunk.TABBING);
            pharase = new Phrase("Correo Electronico: muffinmafico@unicesar.edu.co");
            document.Add(pararagraph);
            document.Add(Chunk.NEWLINE);
            document.Add(pharase);
            document.Add(Chunk.NEWLINE);
            AgregarLinea();
        }

        /*private void AgregarInformacionCliente(Persona cliente)
        {
            Paragraph paragraph3 = new Paragraph();
            pharase = new Phrase("Datos del clientes: ");
            document.Add(pharase);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            pharase = new Phrase("Cedula: " + cliente.Identificacion);
            paragraph3.Add(pharase);
            paragraph3.Add(Chunk.TABBING);
            paragraph3.Add(Chunk.TABBING);
            pharase2 = new Phrase("Nombre: " + cliente.Nombre);
            paragraph3.Add(pharase2);
            paragraph3.Add(Chunk.TABBING);
            paragraph3.Add(Chunk.TABBING);
            pharase = new Phrase("Sexo: " + cliente.Genero);
            paragraph3.Add(pharase);
            paragraph3.Add(Chunk.TABBING);
            paragraph3.Add(Chunk.TABBING);
            pharase = new Phrase("Correo Electronico: " + cliente.Correo);
            document.Add(paragraph3);
            document.Add(Chunk.NEWLINE);
            document.Add(pharase);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            AgregarLinea();
        }*/

        private void AgregarInformacionLista(List<Empleado> lista)
        {
            pharase = new Phrase("Datos reporte: ");
            document.Add(pharase);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);
            Paragraph pharagraft4 = new Paragraph();

            pharase = new Phrase("Estado: " + "Hecho...");
            pharagraft4.Add(pharase);
            pharagraft4.Add(Chunk.SPACETABBING);
            pharagraft4.Add(Chunk.SPACETABBING);

            pharase = new Phrase(" ");
            pharagraft4.Add(pharase);
            pharagraft4.Add(Chunk.SPACETABBING);
            pharagraft4.Add(Chunk.SPACETABBING);
            pharase = new Phrase("Cantidad empleados: " + lista.Count);
            pharagraft4.Add(pharase);
            pharagraft4.Alignment = Element.ALIGN_CENTER;
            document.Add(pharagraft4);
            document.Add(Chunk.NEWLINE);
            AgregarTablas(lista);
        }

        private void AgregarTablas(List<Empleado> lista)
        {
            int tablacolumnas = 5;

            PdfPTable tabla = new PdfPTable(tablacolumnas);
            PdfPCell codigocell = new PdfPCell(new Phrase("Codigo: "));
            codigocell.BorderWidth = 0.75f;
            codigocell.BorderWidthBottom = 0.75f;
            codigocell.BackgroundColor = GrayColor.GRAYWHITE;
            tabla.AddCell(codigocell);
            PdfPCell producto = new PdfPCell(new Phrase("Producto:  "));
            producto.BorderWidth = 0.75f;
            producto.BorderWidthBottom = 0.75f;
            tabla.AddCell(producto);
            PdfPCell modelo = new PdfPCell(new Phrase("Precio:  "));
            modelo.BorderWidth = 0.75f;
            modelo.BorderWidthBottom = 0.75f;
            tabla.AddCell(modelo);
            PdfPCell marca = new PdfPCell(new Phrase("Cantidad:    "));
            marca.BorderWidth = 0.75f;
            marca.BorderWidthBottom = 0.75f;
            tabla.AddCell(marca);
            PdfPCell precio = new PdfPCell(new Phrase("Valor total:   "));
            precio.BorderWidth = 0.75f;
            precio.BorderWidthBottom = 0.75f;
            tabla.AddCell(precio);

            foreach (var item in lista)
            {
                codigocell = new PdfPCell(new Phrase(item.TipoIdentificacion));
                codigocell.BorderWidth = 0.75f;
                producto = new PdfPCell(new Phrase(item.Identificacion));
                producto.BorderWidth = 0.75f;
                modelo = new PdfPCell(new Phrase(Convert.ToString(item.Nombre)));
                modelo.BorderWidth = 0.75f;
                marca = new PdfPCell(new Phrase(Convert.ToString(item.Apellido)));
                marca.BorderWidth = 0.75f;
                precio = new PdfPCell(new Phrase(Convert.ToString(item.NumeroTelefono)));
                precio.BorderWidth = 0.75f;
                tabla.AddCell(codigocell);
                tabla.AddCell(producto);
                tabla.AddCell(modelo);
                tabla.AddCell(marca);
                tabla.AddCell(precio);
            }
            document.Add(tabla);
        }

        private void AgregarLinea()
        {
            pararagraph = new Paragraph("---------------------------------------------------------------------------------------------------------------------");
            document.Add(pararagraph);
        }
    }
}
