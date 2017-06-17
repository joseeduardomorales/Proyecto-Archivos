using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using ctrlArchivos.Modelo;

namespace ctrlArchivos.Modelo
{
    public class Usuario2
    {
        public String idUsuario { get; set; }
        public String Usuario { get; set; }
        public String Contraseña { get; set; }

        public Usuario2()
        {
            idUsuario = "";
            Usuario = "";
            Contraseña = "";

        }

        public Usuario2(String u, String c, String n)
        {
            idUsuario = u;
            Usuario = n;
            Contraseña = c;
        }


        public bool acceso(String usu, String contra)
        {

            servidor misvr = new servidor("localhost", "insunipue");

            SqlConnection miconexion = new SqlConnection("Data Source=" +
                misvr.Svractual +
                "; Initial catalog=" +
                misvr.Bdatos +
                "; Integrated security=true");

            misvr.MyQuery = "select * from usuario where nombre_usr ='" + usu +
                "'and contra_usr = '" + contra + "'";

            miconexion.Open();
            //Datos conecta = new Datos();
            //conecta.Conectar();
            SqlCommand consulta = new SqlCommand(misvr.MyQuery, miconexion);
            SqlDataReader ejecuta = consulta.ExecuteReader();

            if (ejecuta.Read() == true)
            {
                miconexion.Close();
                return true;

            }
            else
            {
                miconexion.Close();
            }
            return false;
        }
        public int Guardar(string consulta)
        {
            SqlCommand Comando;
            Datos inserta = new Datos();
            int regresa = 0;
            if (inserta.Conectar())
            {
                Comando = inserta.construye_command(consulta);
                if ((inserta.ejecutanonquery()) != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                inserta.desconectar();
            }
            else
                regresa = -1;
            return regresa;
        }

        public int Actualiza(string consulta)
        {
            SqlCommand Comando;
            Datos actualiza = new Datos();
            int regresa = 0;
            if (actualiza.Conectar())
            {
                Comando = actualiza.construye_command(consulta);
                if ((actualiza.ejecutanonquery()) != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                actualiza.desconectar();
            }
            else
                regresa = -1;
            return regresa;
        }

        public int Elimina(string consulta)
        {
            SqlCommand Comando;
            Datos eliminar = new Datos();
            int regresa = 0;
            if (eliminar.Conectar())
            {
                Comando = eliminar.construye_command(consulta);
                if ((eliminar.ejecutanonquery()) != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                eliminar.desconectar();
            }
            else
                regresa = -1;
            return regresa;
        }

        public Expediente Buscar(String Consulta, Expediente MiExp)//buscando expediente 
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;

            if (selecciona.Conectar())
            {
                selecciona.construye_reader(Consulta);
                lector = selecciona.ejecuta_reader();

                if (lector.Read() == true)//verifica que el data reader tengan datos aunque sean null
                {
                    do
                    {
                        if (!(lector.IsDBNull(0))) //veririfca que no sean datos null
                        {
                            MiExp.Clasificación = lector.GetString(0);
                            MiExp.idFondo = lector.GetString(1);
                            MiExp.idseccion = lector.GetString(2);
                            MiExp.idserie = lector.GetString(3);
                            MiExp.no_exp = lector.GetInt32(4);
                            MiExp.año = lector.GetInt32(5);
                            MiExp.id_unid_admva_resp = lector.GetString(6);
                            MiExp.id_area_prod = lector.GetString(7);
                            MiExp.id_resp_exp = lector.GetString(8);
                            MiExp.resumen_exp = lector.GetString(9);
                            MiExp.asunto_exp = lector.GetString(10);
                            MiExp.funcion_exp = lector.GetString(11);
                            MiExp.acceso_exp = lector.GetString(12);
                            MiExp.val_prim_exp = lector.GetString(13);
                            MiExp.fec_ext_ini_exp = lector.GetDateTime(14);
                            MiExp.fec_ext_fin_exp = lector.GetDateTime(15);
                            MiExp.no_legajo_exp = lector.GetInt32(16);
                            MiExp.no_fojas_exp = lector.GetInt32(17);
                            MiExp.vinc_otro_exp = lector.GetString(18);
                            MiExp.id_exp_vincd = lector.GetString(19);
                            MiExp.formato_Soporte = lector.GetString(20);
                            MiExp.plazo_conservacion_exp = lector.GetInt32(21);
                            MiExp.tipo_exp = lector.GetString(22);
                            MiExp.destino_final_exp = lector.GetString(23);
                            MiExp.valores_secundarios_exp = lector.GetString(24);
                            MiExp.id_ubic_topog = lector.GetString(25);
                            MiExp.IdEdificio = lector.GetString(26);
                            MiExp.IdPisoEd = lector.GetString(27);
                            MiExp.IdPasillo = lector.GetString(28);
                            MiExp.IdEstante = lector.GetString(29);
                            MiExp.IdCharola = lector.GetString(30);
                            MiExp.IdUnidInsCaja = lector.GetString(31);
                            MiExp.fecha_alta_exp = lector.GetDateTime(32);
                            MiExp.id_capturista_exp = lector.GetString(33);
                            MiExp.id_autorizador_exp = lector.GetString(34);
                        }
                    } while (lector.Read());
                    selecciona.desconectar();
                    selecciona.dr.Close();

                    return MiExp;
                }
                else
                {
                    return null;
                }

            }
            else
                return null;
        }
        public documentos Buscar(String Consulta, documentos MiDoc)//buscando documentos
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;

            if (selecciona.Conectar())
            {
                selecciona.construye_reader(Consulta);
                lector = selecciona.ejecuta_reader();

                if (lector.Read() == true)//verifica que el data reader tengan datos aunque sean null
                {
                    do
                    {
                        if (!(lector.IsDBNull(0))) //veririfca que no sean datos null
                        {
                            MiDoc.clasif_expe = lector.GetString(0);
                            MiDoc.id_doc = lector.GetString(1);
                            MiDoc.tipo_doc = lector.GetString(2);
                            MiDoc.estatus_doc = lector.GetString(3);
                            MiDoc.prioridad = lector.GetString(4);
                            MiDoc.id_remitente = lector.GetString(5);
                            MiDoc.no_doc = lector.GetString(6);
                            MiDoc.fecha_doc = lector.GetDateTime(7);
                            MiDoc.id_destinatario = lector.GetString(8);
                            MiDoc.fecha_rec_doc = lector.GetDateTime(9);
                            MiDoc.hora_rec_doc = lector.GetDateTime(10);
                            MiDoc.asunto_doc = lector.GetString(11);
                            MiDoc.obser_doc = lector.GetString(12);
                            MiDoc.desc_anexos = lector.GetString(13);
                            MiDoc.no_fojas = lector.GetInt32(14);
                            MiDoc.id_delegado = lector.GetString(15);
                            MiDoc.estatus_delegado = lector.GetString(16);
                            MiDoc.fecha_delegado_doc = lector.GetDateTime(17);
                        }
                    } while (lector.Read());
                    selecciona.desconectar();
                    selecciona.dr.Close();

                    return MiDoc;
                }
                else
                {
                    return null;
                }

            }
            else
                return null;
        }
        public ccharola Buscar(String Consulta, ccharola MiCha)//buscando Charola
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;

            if (selecciona.Conectar())
            {
                selecciona.construye_reader(Consulta);
                lector = selecciona.ejecuta_reader();

                if (lector.Read() == true)//verifica que el data reader tengan datos aunque sean null
                {
                    do
                    {
                        if (!(lector.IsDBNull(0))) //veririfca que no sean datos null
                        {
                            MiCha.IDcharola = lector.GetString(0);
                            MiCha.Descripcion = lector.GetString(1);
                            MiCha.IDEstante = lector.GetString(2);
                        }
                    } while (lector.Read());
                    selecciona.desconectar();
                    selecciona.dr.Close();

                    return MiCha;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }
        public UnidadIoC Buscar(String Consulta, UnidadIoC MiUnidad)//buscando Caja
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;

            if (selecciona.Conectar())
            {
                selecciona.construye_reader(Consulta);
                lector = selecciona.ejecuta_reader();

                if (lector.Read() == true)//verifica que el data reader tengan datos aunque sean null
                {
                    do
                    {
                        if (!(lector.IsDBNull(0))) //veririfca que no sean datos null
                        {
                            MiUnidad.IDUnidad = lector.GetString(0);
                            MiUnidad.Descripcion = lector.GetString(1);
                            MiUnidad.IDCharola = lector.GetString(2);
                        }
                    } while (lector.Read());
                    selecciona.desconectar();
                    selecciona.dr.Close();

                    return MiUnidad;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }


        public int cargar_DropDownListString(
            DropDownList cmbNom,
            DropDownList cmbId,
            string consulta)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;

            cmbNom.Items.Clear();
            cmbId.Items.Clear();
            cmbNom.Items.Add("Selecciona");
            cmbId.Items.Add("Selecciona");
            if (selecciona.Conectar())
            {
                selecciona.construye_reader(consulta);
                lector = selecciona.ejecuta_reader();

                if (lector.Read() == true)//verifica que el data reader tengan datos aunque sean null
                {
                    do
                    {
                        if (!(lector.IsDBNull(0))) //veririfca que no sean datos null
                        {
                            cmbNom.Items.Add(lector.GetString(0).ToString());
                            cmbId.Items.Add(lector.GetString(1).ToString());
                        }
                    } while (lector.Read());
                    selecciona.desconectar();
                    selecciona.dr.Close();
                    return 1;
                }
                else
                {
                    return -1;
                }

            }
            else
                return -1;
        }
        public int cargar_DropDownListString(DropDownList cmb, string consulta)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;

            cmb.Items.Clear();
            cmb.Items.Add("Selecciona");
            if (selecciona.Conectar())
            {
                selecciona.construye_reader(consulta);
                lector = selecciona.ejecuta_reader();

                if (lector.Read() == true)//verifica que el data reader tengan datos aunque sean null
                {
                    do
                    {
                        if (!(lector.IsDBNull(0))) //veririfca que no sean datos null
                        {
                            cmb.Items.Add(lector.GetString(0).ToString());
                            //cmb.Items.Add(lector.GetInt32(0).ToString());
                        }
                    } while (lector.Read());
                    selecciona.desconectar();
                    selecciona.dr.Close();
                    return 1;
                }
                else
                {
                    return -1;
                }

            }
            else
                return -1;
        }

        public int cargar_DropDownListInt(DropDownList cmb, string consulta)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;

            cmb.Items.Clear();
            cmb.Items.Add("Selecciona");
            if (selecciona.Conectar())
            {
                selecciona.construye_reader(consulta);
                lector = selecciona.ejecuta_reader();

                if (lector.Read() == true)//verifica que el data reader tengan datos aunque sean null
                {
                    do
                    {
                        if (!(lector.IsDBNull(0))) //veririfca que no sean datos null
                        {
                            //cmb.Items.Add(lector.GetString(0).ToString());
                            cmb.Items.Add(lector.GetInt32(0).ToString());
                        }
                    } while (lector.Read());
                    selecciona.desconectar();
                    selecciona.dr.Close();
                    return 1;
                }
                else
                {
                    return -1;
                }

            }
            else
                return -1;
        }

        public int cargar_TextBoxInt(System.Web.UI.WebControls.TextBox txt, string consulta)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;

            txt.Text = "";

            try
            {
                if (selecciona.Conectar())
                {
                    selecciona.construye_reader(consulta);
                    lector = selecciona.ejecuta_reader();

                    if (lector.Read() == true)//verifica que el data reader tengan datos aunque sean null
                    {
                        if (!(lector.IsDBNull(0))) //veririfca que no sean datos null
                        {
                            txt.Text = lector.GetInt32(0).ToString();
                        }
                        selecciona.desconectar();
                        selecciona.dr.Close();
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }

                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Se genero el siguiente error\nen tiempo de ejecución:\n" + e.Message);
                return -1;
            }
        }


        public int CargarObjetosString(
            System.Web.UI.WebControls.TextBox TxtDato1,
            System.Web.UI.WebControls.TextBox TxtDato2,
            System.Web.UI.WebControls.TextBox TxtDato3,
            String consulta)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;

            TxtDato1.Text = "";
            TxtDato2.Text = "";
            TxtDato3.Text = "";

            try
            {
                if (selecciona.Conectar())
                {
                    selecciona.construye_reader(consulta);
                    lector = selecciona.ejecuta_reader();

                    if (lector.Read() == true)//verifica que el data reader tengan datos aunque sean null
                    {
                        if (!(lector.IsDBNull(0))) //veririfca que no sean datos null
                        {
                            TxtDato1.Text = lector.GetString(0);
                            TxtDato2.Text = lector.GetString(1);
                            TxtDato3.Text = lector.GetString(2);
                        }
                        selecciona.desconectar();
                        selecciona.dr.Close();
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }

                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Se genero el siguiente error\nen tiempo de ejecución:\n" + e.Message);
                return -1;
            }
        }
        public int CargarObjetosString(
            System.Web.UI.WebControls.TextBox TxtNomRespExp,
            System.Web.UI.WebControls.TextBox TxtCargoRespExp,
            System.Web.UI.WebControls.TextBox TxtTelRespExp,
            System.Web.UI.WebControls.TextBox TxtEmailRespExp,
            String consulta)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;

            TxtNomRespExp.Text = "";
            TxtCargoRespExp.Text = "";
            TxtTelRespExp.Text = "";
            TxtEmailRespExp.Text = "";

            try
            {
                if (selecciona.Conectar())
                {
                    selecciona.construye_reader(consulta);
                    lector = selecciona.ejecuta_reader();

                    if (lector.Read() == true)//verifica que el data reader tengan datos aunque sean null
                    {
                        if (!(lector.IsDBNull(0))) //veririfca que no sean datos null
                        {
                            TxtNomRespExp.Text = lector.GetString(0);
                            TxtCargoRespExp.Text = lector.GetString(1);
                            TxtTelRespExp.Text = lector.GetString(2);
                            TxtEmailRespExp.Text = lector.GetString(3);
                        }
                        selecciona.desconectar();
                        selecciona.dr.Close();
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }

                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Se genero el siguiente error\nen tiempo de ejecución:\n" + e.Message);
                return -1;
            }
        }
        public int cargar_TextBoxString(System.Web.UI.WebControls.TextBox txt, string consulta)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;

            txt.Text = "";

            try
            {
                if (selecciona.Conectar())
                {
                    selecciona.construye_reader(consulta);
                    lector = selecciona.ejecuta_reader();

                    if (lector.Read() == true)//verifica que el data reader tengan datos aunque sean null
                    {
                        if (!(lector.IsDBNull(0))) //veririfca que no sean datos null
                        {
                            txt.Text = lector.GetString(0);
                            //txt.Text = lector.GetInt32(0).ToString();
                        }
                        selecciona.desconectar();
                        selecciona.dr.Close();
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }

                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Se genero el siguiente error\nen tiempo de ejecución:\n" + e.Message);
                return -1;
            }
        }

        public int consultaRegresaInt(string consulta)
        {
            Datos selecciona = new Datos();

            SqlDataAdapter adaptador;

            DataRow fila;

            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter(consulta);
                    fila = selecciona.extrae_registro(adaptador, "resultado");
                    if (fila == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(fila["dato"]);
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("No se encuentra el codigo " + e.Message);
                    return 0;
                }
            }
            else
                return 0;
        }
    }
}