using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ctrlArchivos.Modelo;
using System.Windows.Forms;

namespace ctrlArchivos.vista
{
    public partial class charola : System.Web.UI.Page
    {
        ccharola objcharola = new ccharola();
        Usuario2 obj1 = new Usuario2();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarCh_Click(object sender, EventArgs e)
        {
            objcharola.IDcharola = txtIDCharola.Text;
            objcharola.Descripcion = txtDescripcionCh.Text;
            objcharola.IDEstante = txtIDEstante.Text;
            int r = objcharola.Guardar();
            if (r == 1)
            {
                Response.Write("<script language='JavaScript'>alert('Éxito en la inserción de los datos...!!!');</script>");
                txtIDCharola.Text = "";
                txtDescripcionCh.Text = "";
                txtIDEstante.Text = "";
            }
            else if (r == 0)
                 Response.Write("<script language='JavaScript'>alert('Hay problemas con la base de datos...!!!');</script>");
            else
                Response.Write("<script language='JavaScript'>alert('Error al conectarse con la base de datos...!!!');</script>");
        }

        protected void btnEliminarCharola_Click(object sender, EventArgs e)
        {
            int r = objcharola.Eliminar(Convert.ToInt32(txtIDCharola.Text));
            if (r == 1)
            {
                Response.Write("<script language='JavaScript'>alert('Se borraron los datos correctamente...!!!');</script>");
                txtIDCharola.Text = "";
                txtDescripcionCh.Text = "";
                txtIDEstante.Text = "";
            }
            else if (r == 0)
                Response.Write("<script language='JavaScript'>alert('No se pudieron borrar los datos...!!!');</script>");
            else
                Response.Write("<script language='JavaScript'>alert('Error en la base de datos...!!!');</script>");
        }

        protected void btnBuscarCharola_Click(object sender, EventArgs e)
        {
            objcharola.BuscarCha(txtIDCharola.Text);
            if (objcharola != null)
                objcharola.cargarCharola(objcharola, txtIDCharola, txtDescripcionCh, txtIDEstante);
            else
                Response.Write("<script language='JavaScript'>alert('Los datos no están en existencia!!!');</script>");
        }

        protected void btnActualizarCharola_Click(object sender, EventArgs e)
        {
            objcharola.IDcharola = txtIDCharola.Text;
            objcharola.Descripcion = txtDescripcionCh.Text;
            int r = objcharola.ActualizaCha();
            if (r == 1)
            {
                Response.Write("<script language='JavaScript'>alert('Registro actualizado!!!');</script>");
                txtIDCharola.Text = "";
                txtDescripcionCh.Text = "";
                txtIDEstante.Text = "";
            }
            else if (r == 0)
                Response.Write("<script language='JavaScript'>alert('Hay problemas con los datos!!!');</script>");
            else
                Response.Write("<script language='JavaScript'>alert('Problema con la base de datos!!!');</script>");
        }
    }
}