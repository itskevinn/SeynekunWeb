using Entity;

namespace seynekun.Models
{
    public class BodegaProductoModel
    {
        public class BodegaProductoViewModel : BodegaProducto
        {
            public BodegaProductoViewModel(BodegaProducto bodega)
            {
                Bodega = bodega.Bodega;
                Cantidad = bodega.Cantidad;
            }
        }
    }
}