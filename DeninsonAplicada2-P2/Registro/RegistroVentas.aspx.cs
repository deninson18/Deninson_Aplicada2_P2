using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace DeninsonAplicada2_P2.Registro
{
    public partial class RegistroVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
    }
}