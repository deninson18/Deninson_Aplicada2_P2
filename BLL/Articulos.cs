using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class Articulos : ClaseMaestra
    {

        public int ArticuloID { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public float Precio { get; set; }

        public Articulos()
        {
            this.ArticuloID = 0;
            this.Descripcion = "";
            this.Existencia = 0;
            this.Precio = 0;
        }
        public override bool Buscar(int Buscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Articulos where ArticuloID={0}", Buscado));
                if (dt.Rows.Count > 0)
                {
                    
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    this.Existencia = (int)dt.Rows[0]["Existencia"];
                    this.Precio = (float)Convert.ToDecimal(dt.Rows[0]["Precio"].ToString());
                }
                return dt.Rows.Count > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Insertar()
        {
            throw new NotImplementedException();
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string Order = "";
            if (!Orden.Equals(""))
            {
                Order = "order by";
            }
            return conexion.ObtenerDatos(string.Format("select " + Campos + " from Articulos where " + Condicion + Order));
        }

        public override bool Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
