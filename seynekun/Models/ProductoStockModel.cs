using Entity;

namespace seynekun.Models
{
    public class ProductoStockModel
    {
        public class ProductoStockViewModel : ProductoStock
        {
            public ProductoStockViewModel(ProductoStock producto)
            {
                Producto = producto.Producto;
                Cantidad = producto.Cantidad;
            }
        }
    }
}