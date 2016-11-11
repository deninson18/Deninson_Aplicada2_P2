using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Ventas : ClaseMaestra
    {
        public int VentaId { get; set; }
        public string Fecha { get; set; }
        public float Monto { get; set; }
        public List<VentasDetalle> ListaArticulos { get; set; }

        public Ventas()
        {
            this.VentaId = 0;
            this.Fecha = "";
            this.Monto = 0;
            ListaArticulos = new List<VentasDetalle>();
        }
        public void AgregarArticulos(int ArticuloID,int Cantidad,float Precio)
        {
            ListaArticulos.Add(new VentasDetalle(ArticuloID,Cantidad,Precio));
        }


        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            int retorno = 0;
            try
            {
               retorno =Convert.ToInt32(conexion.ObtenerValor(String.Format("insert into Ventas(Fecha,Monto) values('{0}',{1}); select SCOPE_IDENTITY() ", 
                    this.Fecha,this.Monto)));
                 VentaId=retorno;
                
                if (retorno > 0)
                {
                    foreach (VentasDetalle item in this.ListaArticulos)
                    {
                        conexion.Ejecutar(String.Format("Insert into VentasDetalle(VentaId,ArticuloID,Cantidad,Precio) Values ({0},{1},{2},{3})",
                            retorno,item.ArticuloId,item.Cantidad,item.Precio));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno > 0;

        }

        public override bool Buscar(int Buscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Ventas where VentalId={0}", Buscado));
                if (dt.Rows.Count > 0)
                {
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();
                    this.Monto = (float)dt.Rows[0]["Monto"];

                    DataTable dtDetalle = new DataTable();

                    dtDetalle = conexion.ObtenerDatos(string.Format("select * from VentasDetalle where ArticulolId={0}", Buscado));
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        AgregarArticulos((int)row["ArticuloID"],(int)row["Cantidad"], (float)row["Precio"]);
                    }

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
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("delete from VentasDetalle where VentaId={0}; delete from Ventas where VentaId={0}", this.VentaId));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }    

        public override bool Modificar()
        {
            throw new NotImplementedException();
        }
        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string Order = "";
            if (!Orden.Equals(""))
            {
                Order = "order bye";
            }
            return conexion.ObtenerDatos(string.Format("select " + Campos + " from Ventas where " + Condicion + Order));
        }
    }
}
