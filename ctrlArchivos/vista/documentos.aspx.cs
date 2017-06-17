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
    public partial class documento : System.Web.UI.Page
    {
        documentos objDoc = new documentos();
        Usuario2 objUsu = new Usuario2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Validate();
                objDoc.CargarTipoDoc(DropDownList1);
                objDoc.CargarEstatusDoc(DropDownList2);
                objDoc.CargarPrioridadDoc(DropDownList8);
                objDoc.CargarEstatuDoc(DropDownList6);
                objDoc.CargarDatos(DropDownList9, DropDownList3, DropDownList4);
            }
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            objDoc.CargarNombre(DropDownList4, DropDownList5);
            objDoc.Consultar_id(DropDownList4, txtIdDesti);
        }

        protected void btnAgregarDoc_Click(object sender, EventArgs e)
        {
            try
            {
                objDoc.clasif_expe = DropDownList9.Text;
                objDoc.id_doc = TextBox1.Text;
                objDoc.tipo_doc = DropDownList1.Text;
                objDoc.estatus_doc = DropDownList2.Text;
                objDoc.prioridad = DropDownList8.Text;
                //Coj¿nsulta para sacar id
                objDoc.id_remitente = txtId.Text;
                objDoc.no_doc = TextBox3.Text;
                objDoc.fecha_doc = DateTime.Parse(TextBox2.Text);
                objDoc.id_destinatario = txtIdDesti.Text;
                objDoc.fecha_rec_doc = DateTime.Parse(TextBox4.Text);
                objDoc.hora_rec_doc = DateTime.Parse(TextBox5.Text);
                objDoc.asunto_doc = TextBox7.Text;
                objDoc.obser_doc = TextBox8.Text;
                objDoc.desc_anexos = TextBox9.Text;
                objDoc.no_fojas = int.Parse(TextBox10.Text);
                objDoc.id_delegado = txtIdDesti.Text;
                objDoc.estatus_delegado = DropDownList6.Text;
                objDoc.fecha_delegado_doc = DateTime.Parse(TextBox6.Text);

                int r = objDoc.Guardar();

                if (r == 1)
                {   ClientScript.RegisterStartupScript(GetType(), "mostrar", "GuardarDatos();", true);

                    objDoc.CargarTipoDoc(DropDownList1);
                    objDoc.CargarEstatusDoc(DropDownList2);
                    objDoc.CargarPrioridadDoc(DropDownList8);
                    objDoc.CargarDatos(DropDownList9, DropDownList3, DropDownList4);
                    TextBox1.Text = " ";
                    TextBox3.Text = "";
                    TextBox2.Text = " ";
                    txtId.Text = "";
                    txtIdDesti.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox7.Text = "";
                    TextBox8.Text = "";
                    TextBox9.Text = "";
                    TextBox10.Text = "";
                    objDoc.CargarEstatuDoc(DropDownList6);
                    TextBox6.Text = "";
                    DropDownList5.Items.Clear();
                    DropDownList5.Items.Add("Selecciona");


                }
                else if (r == 0)
                    ClientScript.RegisterStartupScript(GetType(), "mostrar", "ErAgregar();", true);
                else
                    ClientScript.RegisterStartupScript(GetType(), "mostrar", "ErAgregar();", true);
            }
            catch (Exception m)
            {
                MessageBox.Show("Revisa los datos");
            }



        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            objDoc.Consultar_id(DropDownList3, txtId);
        }

        protected void btnBuscarDoc_Click(object sender, EventArgs e)
        { 
            String clasifica = DropDownList9.Text;
            objDoc.BuscarDoc(clasifica, TextBox1.Text);
            if (objDoc != null)
            {
                objDoc.cargarDocumentoEncontrados(objDoc,
                   DropDownList9, TextBox1, DropDownList1, DropDownList2, DropDownList8,
                   txtId, TextBox3,TextBox2, txtIdDesti,TextBox4 , TextBox5, TextBox7, TextBox8,
                   TextBox9, TextBox10, txtIdDesti, DropDownList6, TextBox6);
                String respaldo = txtIdDesti.Text;
                objDoc.Consultar_Nombre(txtId, txtIdDesti);
                String respaldo1 = txtId.Text;
                String nom = txtIdDesti.Text; txtIdDesti.Text = respaldo; txtId.Text = "";
                DropDownList3.Text = nom;
                objDoc.Consultar_Nombre(txtIdDesti, txtId);
                DropDownList4.Text = nom = txtId.Text;  txtIdDesti.Text = respaldo;
                objDoc.CargarNombre(DropDownList4, DropDownList5);
                objDoc.ConsultaNombresito(txtIdDesti,txtId);
                DropDownList5.Text = txtId.Text;
                txtId.Text = respaldo1;
            }
        }

        protected void btnActualizarDoc_Click(object sender, EventArgs e)
        {
            objDoc.clasif_expe = DropDownList9.Text;
            objDoc.id_doc = TextBox1.Text;
            objDoc.clasif_expe = DropDownList9.Text;
            objDoc.id_doc = TextBox1.Text;
            objDoc.tipo_doc = DropDownList1.Text;
            objDoc.estatus_doc = DropDownList2.Text;
            objDoc.prioridad = DropDownList8.Text;
            objDoc.id_remitente = txtId.Text;
            objDoc.no_doc = TextBox3.Text;
            objDoc.fecha_doc = DateTime.Parse(TextBox2.Text);
            objDoc.id_destinatario = txtIdDesti.Text;
            objDoc.fecha_rec_doc = DateTime.Parse(TextBox4.Text);
            objDoc.hora_rec_doc = DateTime.Parse(TextBox5.Text);
            objDoc.asunto_doc = TextBox7.Text;
            objDoc.obser_doc = TextBox8.Text;
            objDoc.desc_anexos = TextBox9.Text;
            objDoc.no_fojas = int.Parse(TextBox10.Text);
            objDoc.id_delegado = txtIdDesti.Text;
            objDoc.estatus_delegado = DropDownList6.Text;
            objDoc.fecha_delegado_doc = DateTime.Parse(TextBox6.Text);
            int r = objDoc.actualiza_documentos();

            if (r == 1)
            {
                Response.Write("<script language='JavaScript'>alert('Se Actualizaron los Registros...!!!');</script>");

                objDoc.CargarTipoDoc(DropDownList1);
                objDoc.CargarEstatusDoc(DropDownList2);
                objDoc.CargarPrioridadDoc(DropDownList8);
                objDoc.CargarDatos(DropDownList9, DropDownList3, DropDownList4);
                TextBox1.Text = "";
                TextBox3.Text = "";
                TextBox2.Text = "";
                txtId.Text = "";
                txtIdDesti.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                objDoc.CargarEstatuDoc(DropDownList6);
                TextBox6.Text = "";
                DropDownList5.Items.Clear();
                DropDownList5.Items.Add("Selecciona");


            }
            else if (r == 0)
                Response.Write("<script language='JavaScript'>alert('Revise los datos...!!!');</script>");
            else
                Response.Write("<script language='JavaScript'>alert('No se pudieron Actualizar los datos...!!!');</script>");


        }
    

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEliminarDoc_Click(object sender, EventArgs e)
        {
            objDoc.clasif_expe = DropDownList9.Text;
            objDoc.id_doc = TextBox1.Text;
            objDoc.tipo_doc = DropDownList1.Text;
            objDoc.estatus_doc = DropDownList2.Text;
            objDoc.prioridad = DropDownList8.Text;
            //Coj¿nsulta para sacar id
            objDoc.id_remitente = txtId.Text;
            objDoc.no_doc = TextBox3.Text;
            objDoc.fecha_doc = DateTime.Parse(TextBox2.Text);
            objDoc.id_destinatario = txtIdDesti.Text;
            objDoc.fecha_rec_doc = DateTime.Parse(TextBox4.Text);
            objDoc.hora_rec_doc = DateTime.Parse(TextBox5.Text);
            objDoc.asunto_doc = TextBox7.Text;
            objDoc.obser_doc = TextBox8.Text;
            objDoc.desc_anexos = TextBox9.Text;
            objDoc.no_fojas = int.Parse(TextBox10.Text);
            objDoc.id_delegado = txtIdDesti.Text;
            objDoc.estatus_delegado = DropDownList6.Text;
            objDoc.fecha_delegado_doc = DateTime.Parse(TextBox6.Text);
            int r = objDoc.baja(DropDownList9.Text, TextBox1.Text);
            if (r == 1)
            {
                Response.Write("<script language='JavaScript'>alert('Se Eliminaron los Registros!! :)...!!!');</script>");
                objDoc.CargarTipoDoc(DropDownList1);
                objDoc.CargarEstatusDoc(DropDownList2);
                objDoc.CargarPrioridadDoc(DropDownList8);
                objDoc.CargarDatos(DropDownList9, DropDownList3, DropDownList4);
                TextBox1.Text = "";
                TextBox3.Text = "";
                TextBox2.Text = "";
                txtId.Text = "";
                txtIdDesti.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                objDoc.CargarEstatuDoc(DropDownList6);
                TextBox6.Text = "";
                DropDownList5.Items.Clear();
                DropDownList5.Items.Add("Selecciona");
            }
            else if (r == 0)
                Response.Write("<script language='JavaScript'>alert('Revise los Datos...!!!');</script>");
            else
                Response.Write("<script language='JavaScript'>alert('No se pudieron Eliminar los datos...!!!');</script>");
        }
    }
}