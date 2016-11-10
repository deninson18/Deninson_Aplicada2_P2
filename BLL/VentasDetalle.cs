using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class VentasDetalle 
    {
        public int VentaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }

        public VentasDetalle()
        {
            this.VentaId = 0;
            this.ArticuloId = 0;
            this.Cantidad = 0;
            this.Precio = 0;
        }
        public VentasDetalle(int ventaId, int ArticuloId, int Cantidad, float Precio)
        {
            this.VentaId = ventaId;
            this.ArticuloId = ArticuloId;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
        }
    }
}
