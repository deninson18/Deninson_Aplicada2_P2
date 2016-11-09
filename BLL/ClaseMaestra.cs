using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace BLL
{
    public abstract class ClaseMaestra
    {
        public abstract bool Insertar();
        public abstract bool Modificar();
        public abstract bool Eliminar();
        public abstract bool Buscar(int Buscado);
        public abstract DataTable Listado(string Campos, string Condicion, string Orden);
    }
}
