using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace DeninsonAplicada2_P2.Registro
{
    public partial class RegistroVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
               
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("VentaId"), new DataColumn("Articulo"), new DataColumn("Cantidad"), new DataColumn("Precio") });
                Session["Ventas"] = dt;
            }
        }

        public void CargarDatosVentas(Ventas Venta)
        {

        }
        public void DevolverDatos(Articulos articulo)
        {
            descripcionTextBox.Text = articulo.Descripcion;
            existenciaTextBox.Text = articulo.Existencia.ToString() ;
            precioTextBox.Text = articulo.Precio.ToString();
        }

        protected void buscarArticuloButton_Click(object sender, EventArgs e)
        {
            Articulos articulo = new Articulos();
            int id = 0;
            int.TryParse(ArticuloIdTextBox .Text, out id);
            if (id > 0)
            {
                if (articulo.Buscar(id))
                {
                    DevolverDatos(articulo);
                }
                else
                {
                    Utility.ShowToastr(this, "Id no Existe", "MESSAGE", "SUCCESS");
                }
            }
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            CargarDatosVentas(venta);
            if (idVentaTextBox.Text.Length <= 0)
            {
                if (venta.Insertar())
                {
                    Utility.ShowToastr(this, "Guardo Correctamente", "Message", "SUCCESS");
                }
                else
                {
                    Response.Write("<script>alert('Error al Guardar')</script>");
                }
            }
        }
    }
}