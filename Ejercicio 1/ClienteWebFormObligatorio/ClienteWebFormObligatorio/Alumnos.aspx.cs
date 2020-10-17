using ClienteWebFormObligatorio.AlumnoServicioRemoto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWebFormObligatorio
{
    public partial class Alumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (!IsPostBack)                       
            {
                GridView1.DataSource = new AlumnoServicioRemoto.AlumnoServiceClient().ObtenerTodos();
                GridView1.DataBind();
            }
        }

        private void MostarMensaje(string mensaje, bool correcto)
        {
            lblMensaje.Text = mensaje;
            if (correcto)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {           
                Alumno nuevoAlumno = new Alumno()
                {
                    numero = Convert.ToInt32(TxtNumero.Text),
                    cedula = TxtDocumento.Text,
                    nombre = TxtNombre.Text,
                    apellido = TxtApellido.Text,
                };

                if (new AlumnoServiceClient().AgregarAlumno(nuevoAlumno))
                {
                    MostarMensaje("Alumno agregado!", true);
                }
                else
                {
                    MostarMensaje("No se pudo agregar el alumno", false);
                }           
           
        }

        protected void BtnListar_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = new AlumnoServicioRemoto.AlumnoServiceClient().ObtenerTodos();
            GridView1.DataBind();
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {

            var alumnos = new AlumnoServicioRemoto.AlumnoServiceClient().ObtenerTodos();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=Alumnos.txt");
            Response.AddHeader("content-type", "text/plain");

            using (StreamWriter writer = new StreamWriter(Response.OutputStream))
            {

                foreach (var a in alumnos)
                {
                    writer.WriteLine(a.numero + "," + a.cedula + "," + a.nombre + "," + a.apellido);
                }
            }
            Response.End();
        }
    }
}
