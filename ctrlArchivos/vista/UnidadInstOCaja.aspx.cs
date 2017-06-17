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
    public partial class UnidadInstOCaja : System.Web.UI.Page
    {
        UnidadIoC objUIoC = new UnidadIoC();
        Usuario2 obj1 = new Usuario2(); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarUoC_Click(object sender, EventArgs e)
        {
            objUIoC.BuscarUni(txtIDUoC.Text);
            if (objUIoC != null)
                objUIoC.cargarUnidad(objUIoC, txtIDUoC, txtDescripcionUoC, txtIDCharolaUoC);
            else
                Response.Write("<script language='JavaScript'>alert('Los datos no están en existencia!!!');</script>");
        }

        protected void btnAgregarUoC_Click(object sender, EventArgs e)
        {
            objUIoC.IDUnidad = txtIDUoC.Text;
            objUIoC.Descripcion = txtDescripcionUoC.Text;
            objUIoC.IDCharola = txtIDCharolaUoC.Text;
            int r = objUIoC.Guardar();
            if (r == 1)
            {
                Response.Write("<script language='JavaScript'>alert('Éxito en la inserción de los datos...!!!');</script>");
                txtIDUoC.Text = "";
                txtDescripcionUoC.Text = "";
                txtIDCharolaUoC.Text = "";
            }
            else if (r == 0)
                Response.Write("<script language='JavaScript'>alert('Hay problemas con la base de datos...!!!');</script>");
            else
                Response.Write("<script language='JavaScript'>alert('Error al conectarse con la base de datos...!!!');</script>");
        }

        protected void btnEliminarUoC_Click(object sender, EventArgs e)
        {
            int r = objUIoC.Eliminar(Convert.ToInt32(txtIDUoC.Text));
            if (r == 1)
            {
                Response.Write("<script language='JavaScript'>alert('Se borraron los datos correctamente...!!!');</script>");
                txtIDUoC.Text = "";
                txtDescripcionUoC.Text = "";
                txtIDCharolaUoC.Text = "";
            }
            else if (r == 0)
                Response.Write("<script language='JavaScript'>alert('No se pudieron borrar los datos!!!');</script>");
            else
                Response.Write("<script language='JavaScript'>alert('Error en la base de datos!!!');</script>");
        }

        protected void btnActualizarUoC_Click(object sender, EventArgs e)
        {
            objUIoC.IDUnidad = txtIDUoC.Text;
            objUIoC.Descripcion = txtDescripcionUoC.Text;
            int r = objUIoC.ActualizaUni();
            if (r == 1)
            {
                Response.Write("<script language='JavaScript'>alert('Registro actualizado!!!');</script>");
                txtIDUoC.Text = "";
                txtDescripcionUoC.Text = "";
                txtIDCharolaUoC.Text = "";
            }
            else if (r == 0)
                Response.Write("<script language='JavaScript'>alert('Hay problemas con los datos!!!');</script>");
            else
                Response.Write("<script language='JavaScript'>alert('Problema con la base de datos!!!');</script>");
        }
    }
}