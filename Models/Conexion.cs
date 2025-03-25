using MySql.Data.MySqlClient;


namespace Stieger_models
{

    //hacer clase estatica posiblemente
    class Conexion
    {
        public MySqlConnection conexion;
        private string stringConexion = "Server=localhost;Database=stieger_inmobiliaria;Uid=root;Pwd=";


        public Conexion()
        {

            this.conexion = new MySqlConnection(stringConexion);



        }

        public void abrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
        }


        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }


        public MySqlCommand comandoSimple(string sql)
        {
            abrirConexion();
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = this.conexion;

            comando.CommandText = sql;
            CerrarConexion();
            return comando;
        }


    }

}
