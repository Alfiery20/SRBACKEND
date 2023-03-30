using CAD;
using CEN.Imagen;
using CEN.Request;
using CEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLN
{
    public class ClnImagen
    {
        public CenControlError ListarImagen(ListarImagenesRequest request)
        {
            CadImagen c = new();
            return c.ListarImagen(request);
        }
        public CenControlError AgregarImagen(CenAgregarImagen request)
        {
            CadImagen c = new();
            return c.AgregarImagen(request);
        }
        public CenControlError EliminarImagen(CenEliminarImagen request)
        {
            CadImagen c = new();
            return c.EliminarImagen(request);
        }
        public CenControlError ObtenerImagen(int id)
        {
            CadImagen c = new();
            return c.ObtenerImagen(id);
        }
        public int ObtenerCodigo(int idProducto)
        {
            CadImagen c = new();
            return c.ContarImagen(new ListarImagenesRequest { id_producto = idProducto });
        }
    }
}
