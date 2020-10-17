using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class MapperAlumno : MapperBase, IMapperAlumno
    {
        public int Actualizar(Alumno a)
        {
            return -1;
        }
        

        public int AgregarAlumnoDB(Alumno a)
        {
            var parametros = new List<SqlParameter>();
            var numero = new SqlParameter();
            numero.ParameterName = "@numero";
            numero.Value = a.numero;
            parametros.Add(numero);

            var cedula = new SqlParameter();
            cedula.ParameterName = "@cedula";
            cedula.Value = a.cedula;
            parametros.Add(cedula);

            var nombre = new SqlParameter();
            nombre.ParameterName = "@nombre";
            nombre.Value = a.nombre;
            parametros.Add(nombre);

            var apellido = new SqlParameter();
            apellido.ParameterName = "@apellido";
            apellido.Value = a.apellido;
            parametros.Add(apellido);

            var conn = AbrirConexion();

            var filasAfectadas = EjecutaNonQuery("INSERT INTO Alumnos (numero, cedula, nombre, apellido) VALUES (@numero,@cedula,@nombre,@apellido)",
                CommandType.Text, parametros, conn, null);
            conn.Close();
            return filasAfectadas;
        }       

        public List<Alumno> ObtenerTodos()
        {
            var conn = AbrirConexion();
            var reader = Select("SELECT * FROM Alumnos", CommandType.Text, null, conn, null);
            List<Alumno> colAlumnos = new List<Alumno>();
            while (reader.Read())
            {
                colAlumnos.Add(CargarAlumno(reader));
            }
            CerrarConexion(conn);
            return colAlumnos;
        }

        private Alumno CargarAlumno(SqlDataReader reader)
        {
            var alumno = new Alumno();
            alumno.numero = Convert.ToInt32(reader["numero"]);
            alumno.cedula = Convert.ToString(reader["cedula"]);
            alumno.nombre = Convert.ToString(reader["nombre"]);
            alumno.apellido = Convert.ToString(reader["apellido"]);
            return alumno;
        }
    }
}

