using System;    
using System.Collections.Generic;    
using System.Data;    
using System.Data.SqlClient;    
using System.Linq;    
using System.Threading.Tasks;

namespace pruebaTecnica2.Models
{
    public class TercerosDataAccessLayer{
        string connectionString = "Data Source=192.168.0.17;" +
  "Initial Catalog=almacen;" +
  "User id=sa;" +
  "Password=D@vid@:c19@:h20;";

        public IEnumerable<Terceros> ObtenerTodosTerceros()
        {
            List<Terceros> listaTerceros = new List<Terceros>();

            using(SqlConnection con = new SqlConnection(connectionString)){
                SqlCommand cmd = new SqlCommand("spObtenerTerceros", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sqlReader = cmd.ExecuteReader();

                while(sqlReader.Read())
                {
                    Terceros terceros = new Terceros();
                    terceros.idTercero = Convert.ToInt32(sqlReader["idTercero"]);
                    terceros.cedula = sqlReader["cedula"].ToString();
                    terceros.nombres = sqlReader["nombres"].ToString();
                    terceros.apellidos = sqlReader["apellidos"].ToString();
                    terceros.razonSocial = sqlReader["razonSocial"].ToString();

                    listaTerceros.Add(terceros);
                }
                con.Close();
            }
            return listaTerceros;
        }
        public void CrearTerceros(Terceros tercero){
        using(SqlConnection con = new SqlConnection(connectionString)){
                SqlCommand cmd = new SqlCommand("spCrearTerceros", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cedula", tercero.cedula);
                cmd.Parameters.AddWithValue("@nombres", tercero.nombres);
                cmd.Parameters.AddWithValue("@apellidos", tercero.apellidos);
                cmd.Parameters.AddWithValue("@razonSocial", tercero.razonSocial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
    }
    }    
}