using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
//using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ctrlArchivos.Modelo
{
    public class documentos
    {
        public String nombre_dpt { get; set; }
        Usuario2 obj1 = new Usuario2();

        public String clasif_expe { get; set; }
        public String id_doc { get; set; }
        public String tipo_doc { get; set; }
        public String estatus_doc { get; set; }
        public String prioridad { get; set; }
        public String id_remitente { get; set; }
        public String no_doc { get; set; }
        public DateTime fecha_doc { get; set; }
        public String id_destinatario { get; set; }
        public DateTime fecha_rec_doc { get; set; }
        public DateTime hora_rec_doc { get; set; }
        public String asunto_doc { get; set; }
        public String obser_doc { get; set; }
        public String desc_anexos { get; set; }
        public int no_fojas { get; set; }
        public String id_delegado { get; set; }
        public String estatus_delegado { get; set; }
        public DateTime fecha_delegado_doc { get; set; }
        public void CargarTipoDoc(DropDownList DdlDatos)
        {
            DdlDatos.Items.Clear();
            DdlDatos.Items.Add("Selecciona");
            DdlDatos.Items.Add("Notificación");
            DdlDatos.Items.Add("Citatorio");
            DdlDatos.Items.Add("Permiso");
        }
        public void CargarEstatusDoc(DropDownList DdlDatos)
        {
            DdlDatos.Items.Clear();
            DdlDatos.Items.Add("Selecciona");
            DdlDatos.Items.Add("Activo");
            DdlDatos.Items.Add("Cancelado");
            DdlDatos.Items.Add("Proceso");
        }
        public void CargarPrioridadDoc(DropDownList DdlDatos)
        {
            DdlDatos.Items.Clear();
            DdlDatos.Items.Add("Selecciona");
            DdlDatos.Items.Add("Alta");
            DdlDatos.Items.Add("Media");
            DdlDatos.Items.Add("Baja");
        }
        public void CargarEstatuDoc(DropDownList DdlDatos)
        {
            DdlDatos.Items.Clear();
            DdlDatos.Items.Add("Selecciona");
            DdlDatos.Items.Add("Recibido");
            DdlDatos.Items.Add("Pendiente a entregar");
            DdlDatos.Items.Add("Rechazado");
        }
        public void CargarDatos(
            DropDownList DdlClasificacion,
            DropDownList DdlUsuario,
            DropDownList DdlUsuario1)
        {
            String consulta1 = "";
            consulta1 = "select clasificacion_exp from expediente";
            obj1.cargar_DropDownListString(DdlClasificacion, consulta1);
            consulta1 = "select nombre_usr from usuario";
            obj1.cargar_DropDownListString(DdlUsuario, consulta1);
            obj1.cargar_DropDownListString(DdlUsuario1, consulta1);
        }
        public void CargarNombre(DropDownList DdlUsu, DropDownList DdlNombre)
        {
            DdlNombre.Items.Clear();
            string consulta1 = "select nom_com_usr from usuario " +
                "where nombre_usr= '" + DdlUsu.Text + "'";
            obj1.cargar_DropDownListString(DdlNombre, consulta1);
        }
        public void Consultar_id(DropDownList DdlUsu, TextBox txtid)
        {
            string consulta1 = "select id_usr from usuario " +
                "where nombre_usr= '" + DdlUsu.Text + "'";
            obj1.cargar_TextBoxString(txtid, consulta1);
        }
        public void Consultar_idRespaldo(TextBox txtrespaldo, TextBox txtid)
        {
            string consulta1 = "select id_usr from usuario " +
                "where nombre_usr= '" + txtrespaldo.Text + "'";
            obj1.cargar_TextBoxString(txtid, consulta1);
        }
        public void Consultar_Nombre(TextBox txtid,TextBox txtCaja)
        {
            string consulta1 = "select nombre_usr from usuario " +
                "where id_usr= '" + txtid.Text + "'";
            obj1.cargar_TextBoxString(txtCaja, consulta1);
        }
        public void ConsultaNombresito(TextBox txt1, TextBox txt2)
        {
            string consulta1 = "select nom_com_usr from usuario " +
               "where id_usr= '" + txt1.Text + "'";
            obj1.cargar_TextBoxString(txt2, consulta1);
        }
        public int Guardar()
        {
            string consulta = "insert into documento values('" + clasif_expe + "','" + id_doc + "','"
                + tipo_doc + "','" + estatus_doc + "','" + prioridad + "','" + id_remitente + "','"
                + no_doc + "','" + fecha_doc.ToString("dd/MM/yyyy") + "','" + id_destinatario + "','"
                + fecha_rec_doc.ToString("dd/MM/yyyy") + "','" + hora_rec_doc.ToString("hh:mm:ss") + "','"
                + asunto_doc + "','" + obser_doc + "','" + desc_anexos + "','" + Convert.ToInt32(no_fojas) + "','"
                + id_delegado + "','" + estatus_delegado + "','" + fecha_delegado_doc.ToString("dd/MM/yyyy") + "')";
            int res = obj1.Guardar(consulta);
            return res;
        }
        public documentos BuscarDoc(string valor, string valor1)
        {
            string consulta1 = "select * from documento where  clasificacion_exp = '" + valor + "' and id_doc='" + valor1 + "'";
            documentos Midocumento = obj1.Buscar(consulta1, this);
            if (Midocumento != null)
            {
                return Midocumento;
            }
            else
            {
                return null;
            }
        }

        public void cargarDocumentoEncontrados(
            documentos Miducu,
            DropDownList ddlClasifica,
            TextBox txtFolio,
            DropDownList ddlTipo,
            DropDownList ddlestatusdoc,
            DropDownList ddlprioridad,
            TextBox txtId,
            TextBox txtNumerodoc,
            TextBox txtFecha,
            TextBox txtidDestinatario,
            TextBox txtFechadoc,
            TextBox txtHora,
            TextBox txtAsunto,
            TextBox txtObser,
            TextBox txtAnexos,
            TextBox txtFoja,
            TextBox txtIddele,
            DropDownList ddlEstatusdel,
            TextBox txtFechadel
            )
        {
            ddlClasifica.Text = Miducu.clasif_expe;
            txtFolio.Text = Miducu.id_doc;
            ddlTipo.Text = Miducu.tipo_doc;
            ddlestatusdoc.Text = Miducu.estatus_doc;
            ddlprioridad.Text = Miducu.prioridad;
            txtId.Text = Miducu.id_remitente;
            txtNumerodoc.Text = Miducu.no_doc;

            txtFecha.Text = Miducu.fecha_doc.ToString("yyyy-MM-dd");

            txtidDestinatario.Text = Miducu.id_destinatario;
            txtFechadoc.Text = Miducu.fecha_rec_doc.ToString("yyyy-MM-dd");
            txtHora.Text = Miducu.hora_rec_doc.ToString("hh:mm:ss");
            txtAsunto.Text = Miducu.asunto_doc;
            txtObser.Text = Miducu.obser_doc;
            txtAnexos.Text = Miducu.desc_anexos;
            txtFoja.Text = Convert.ToString(Miducu.no_fojas);
            txtIddele.Text = Miducu.id_delegado;
            ddlEstatusdel.Text = Miducu.estatus_delegado;
            txtFechadel.Text = Miducu.fecha_delegado_doc.ToString("yyyy-MM-dd");
        }


        public int baja(String CLA, String ID_DOCU)
        {
            String consulta1 = "delete from documento where clasificacion_exp ='" + CLA + "' and id_doc='" + ID_DOCU + "'";
            int res = obj1.Elimina(consulta1);

            return res;
        }

        public int actualiza_documentos()
        {
            SqlCommand Comando;
            Datos actualiza = new Datos();
            int regresa = 0;
            if (actualiza.Conectar())
            {
                Comando = actualiza.construye_command("update documento set tipo_doc='" + tipo_doc + "',estatus_doc='" + estatus_doc + "',prioridad_doc='" + prioridad
                + "',id_remitente_doc='" + id_remitente + "',no_doc='" + Convert.ToInt32(no_doc) + "',fecha_doc='" + fecha_doc.ToString("dd-MM-yyyy")
                + "',id_destinatario='" + id_destinatario + "',fecha_recep_doc='" + fecha_rec_doc.ToString("dd-MM-yyyy")
                + "',hora_recep_doc='" + hora_rec_doc.ToString("hh:mm:ss") + "',asunto='" + asunto_doc + "',obs_doc='" + obser_doc
                + "',desc_anexos_doc='" + desc_anexos + "',no_fojas_doc='" + Convert.ToInt32(no_fojas) + "',id_delegado_doc='" + id_delegado
                + "',estatus_dele_doc='" + estatus_delegado + "',fecha_dele_doc='" + fecha_delegado_doc.ToString("dd-MM-yyyy") + "' where clasificacion_exp='" + clasif_expe + "' and id_doc='" + id_doc + "'");
                if (actualiza.ejecutanonquery() != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                actualiza.desconectar();
            }
            else
                return -1;
            return regresa;
        }

    }
}
    