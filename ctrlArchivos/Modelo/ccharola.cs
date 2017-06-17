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
    public class ccharola
    {
        public String IDcharola { get; set; }
        public String Descripcion { get; set; }
        public String IDEstante { get; set; }

        Usuario2 obj1 = new Usuario2();

        public ccharola()
        {
            IDcharola = "";
            Descripcion = "";
            IDEstante = "";
        }

        public ccharola(String idchar, String desc, String idest)
        {
            IDcharola = idchar;
            Descripcion = desc;
            IDEstante = idest;
        }

        public int Guardar()
        {
            string consulta = "insert into Charola (idCharola, DescripcionChar, IdEstante) values('"
                + IDcharola + "', '" + Descripcion + "', '" + IDEstante + "')";

            int res = obj1.Guardar(consulta);

            return res;
        }
        public int ActualizaCha()
        {
            String consulta = ("update Charola set DescripcionChar='" + Descripcion + "' where idCharola='" + IDcharola + "'");
            int res = obj1.Actualiza(consulta);
            return res;
        }
        public ccharola BuscarCha(string valor)
        {
            string consulta1 = "select * from Charola where  idCharola = '" + valor + "'";
            ccharola MiCharola = obj1.Buscar(consulta1, this);
            if (MiCharola != null)
            {
                return MiCharola;
            }
            else
            {
                return null;
            }
        }
        public void cargarCharola(
          ccharola MiCharola,
          TextBox txtIdCharo,
          TextBox txtDescri,
          TextBox txtIdEstante
          )
        {
            txtIdCharo.Text = MiCharola.IDcharola;
            txtDescri.Text = MiCharola.Descripcion;
            txtIdEstante.Text = MiCharola.IDEstante;
        }

        public int Eliminar(int codigo)
        {
            string consulta=("delete from Charola where idCharola = " + codigo);
            int res = obj1.Elimina(consulta);
            return res;
        }
    }
}