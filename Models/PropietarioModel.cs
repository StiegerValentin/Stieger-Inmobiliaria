using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Stieger_inmobiliaria;

namespace Stieger_models
{
    public class Propietario
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Propietario()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
        }

        public Propietario(int id, string nombre, string apellido, string dni, string telefono)
        {
            id_Propietario = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Telefono = telefono;
        }

        public Propietario(string nombre, string apellido, string dni, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Telefono = telefono;
        }


        //varias cosas de .net.models que hay que investigar
        //indica que es llave primaria
        [Key]
        //cambia como se renderiza el id en las vistas
        [Display(Name = "Código Int.")]
        public int id_Propietario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Dni { get; set; }

        public string Telefono { get; set; }

        /* [EmailAddress]
         public string Email { get; set; }*/






        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
            //agregar otros datos segun se vea necesario
        }


        public List<Propietario> Todos()
        {
            List<Propietario> propietariosLista = new List<Propietario>();
            Conexion con = new Conexion();
            

            string sql = "SELECT * FROM propietario";
            MySqlCommand comando = con.comandoSimple(sql);
            con.abrirConexion();
            var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Propietario p = new Propietario();
                p.id_Propietario = lector.GetInt16(0);
                p.Dni = lector.GetString(1);
                p.Nombre = lector.GetString(2);
                p.Apellido = lector.GetString(3);
                p.Telefono = lector.GetString(4);
                propietariosLista.Add(p);
            }

            con.CerrarConexion();
            return propietariosLista;
        }

        public void Alta(Propietario p)
        {
            Conexion con = new Conexion();
            string sql = "INSERT INTO `propietario`( `dni`, `nombre`, `apellido`, `telefono`)" +
                    " VALUES (@dni,@nombre,@apellido,@telefono)";
            con.abrirConexion();
            MySqlCommand comando = new MySqlCommand(sql, con.conexion);
            //esto indica que no es un pa
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@dni", p.Dni);
            comando.Parameters.AddWithValue("@nombre", p.Nombre);
            comando.Parameters.AddWithValue("@apellido", p.Apellido);
            comando.Parameters.AddWithValue("@telefono", p.Telefono);

            int id = Convert.ToInt32(comando.ExecuteScalar());
            Console.Write("id del propietario:" + id);

        }

    }

}
