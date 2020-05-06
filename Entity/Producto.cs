namespace Entity
{
    public class Producto
    {
        public string Codigo { get; set; }
        public decimal Precio { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public Categoria Categoria { get; set; }
        public Bodega Bodega { get; set; }
    }
}