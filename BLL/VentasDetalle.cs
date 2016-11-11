using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class VentasDetalle 
    {
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }

        public VentasDetalle()
        {
            this.ArticuloId = 0;
            this.Cantidad = 0;
            this.Precio = 0;
        }
        public VentasDetalle(int ArticuloId, int Cantidad, float Precio)
        {
            this.ArticuloId = ArticuloId;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
        }
    }
}
