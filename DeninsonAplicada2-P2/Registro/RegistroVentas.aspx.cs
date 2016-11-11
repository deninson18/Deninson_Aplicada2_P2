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
                CargarDropList();
                dt.Columns.AddRange(new DataColumn[3] {new DataColumn("Articulo"), new DataColumn("Cantidad"), new DataColumn("Precio") });
                Session["Articulos"] = dt;
            }
        }

        private void CargarDatosVentas(Ventas venta)
        {
            venta.Fecha = FechaTexBox.Text;
            int id;
            float monto;
            int.TryParse(idVentaTextBox.Text, out id);
            venta.VentaId = id;
            float.TryParse(montoTextBox.Text, out monto);
            venta.Monto = monto;

            foreach(GridViewRow row in ventasGridView.Rows)
            {
                venta.AgregarArticulos(int.Parse(row.Cells[0].Text),int.Parse(row.Cells[1].Text),(float)Convert.ToDecimal(row.Cells[2].Text));
            }
        }
        private void CargarDropList()
        {
            Articulos articulo = new Articulos();
            articuloDropDownList.DataSource = articulo.Listado("ArticuloID,Descripcion", "1=1", "");
            articuloDropDownList.DataTextField = "Descripcion";
            articuloDropDownList.DataValueField = "ArticuloID";
            articuloDropDownList.DataBind();

            precioDropDownList.DataSource = articulo.Listado("ArticuloID,Precio", "1=1", "");
            precioDropDownList.DataTextField = "Precio";
            precioDropDownList.DataValueField = "Precio";
            precioDropDownList.DataBind();
        }

        private void CalcularMonto()
        {
            float Suma = 0, Total = 0, Resultado = 0;
            
            foreach(GridViewRow row in ventasGridView.Rows)
            {
                Suma = Suma + (float)Convert.ToDecimal(row.Cells[1].Text);
                Total = Total + (float)Convert.ToDecimal(row.Cells[2].Text);
            }

            Resultado = Suma * Total;
            montoTextBox.Text = Resultado.ToString();
            cantidadTextBox.Text = string.Empty;


        }
        private void DevolverDatos(Articulos articulo)
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
                    Utility.ShowToastr(this, "Error al Guardar", "Message", "Danger");
                }
            }
        }

        protected void agregarButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["Articulos"];
            dt.Rows.Add(articuloDropDownList.SelectedValue, cantidadTextBox.Text, precioDropDownList.SelectedValue);
            Session["Articulos"] = dt;
            ventasGridView.DataSource = dt;
            ventasGridView.DataBind();
            CalcularMonto();
        }
    }
}