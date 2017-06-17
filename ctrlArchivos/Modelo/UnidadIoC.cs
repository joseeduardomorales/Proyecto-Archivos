using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ctrlArchivos.Modelo;
using ctrlArchivos.vista;
using System.Web.UI.WebControls;

namespace ctrlArchivos.Modelo
{
    public class UnidadIoC
    {
        public String IDUnidad { get; set; }
        public String Descripcion { get; set; }
        public String IDCharola { get; set; }

        Usuario2 obj1 = new Usuario2();

        public UnidadIoC()
        {
            IDUnidad = "";
            Descripcion = "";
            IDCharola = "";
        }

        public UnidadIoC(String idunidad, String desc, String idchar)
        {
            IDUnidad = idunidad;
            Descripcion = desc;
            IDCharola = idchar;
        }

        public int Guardar()
        {
            string consulta = "insert into UnidadInstOCaja (IdUnidInsCaja, DescUnidIsnCaja, IdCharola) values('"
                + IDUnidad + "', '" + Descripcion + "', '" + IDCharola + "')";

            int res = obj1.Guardar(consulta);

            return res;
        }
        public UnidadIoC BuscarUni(string valor)
        {
            string consulta1 = "select * from UnidadInstOCaja where IdUnidInsCaja = '" + valor + "'";
            UnidadIoC MiUnidad = obj1.Buscar(consulta1, this);
            if (MiUnidad != null)
            {
                return MiUnidad;
            }
            else
            {
                return null;
            }
        }
        public void cargarUnidad(
          UnidadIoC MiUnidad,
          TextBox txtIdUni,
          TextBox txtDescri,
          TextBox txtIdCha
          )
        {
            txtIdUni.Text = MiUnidad.IDUnidad;
            txtDescri.Text = MiUnidad.Descripcion;
            txtIdCha.Text = MiUnidad.IDCharola;
        }

        public int Eliminar(int codigo)
        {
            string consulta = ("delete from UnidadInstOCaja where IdUnidInsCaja= " + codigo);
            int res = obj1.Elimina(consulta);
            return res;
        }
        public int ActualizaUni()
        {
            String consulta = ("update UnidadInstOCaja set DescUnidIsnCaja='" + Descripcion + "' where IdUnidInsCaja = '" + IDUnidad + "'");
            int res = obj1.Actualiza(consulta);
            return res;
        }
    }
}