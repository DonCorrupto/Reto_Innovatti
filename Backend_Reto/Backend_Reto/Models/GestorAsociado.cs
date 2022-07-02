using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend_Reto.Models
{
    public class GestorAsociado
    {
        //

        public DataSet buscarAsociado(string pAction, string pCed= null)
        {
            Asociado cn= new Asociado();
            DataSet ds= new DataSet();
            using (SqlConnection Conexion = new SqlConnection(cn.strinCon("BDServer")))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("Asociado_Buscar", Conexion))
                    {
                        Conexion.Open();
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Action", pAction));

                        if (pAction == "CE")
                        {
                            cmd.Parameters.Add(new SqlParameter("@ced", pCed));
                        }
                        da.SelectCommand = cmd;
                        // ???????????
                        da.Fill(ds, "Asociado");
                        //?????????????????
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Conexion.Close();
                }
                return ds;
            }
        }

        //
        public List<Asociado> getAsociados()
        {
            List<Asociado> lista = new List<Asociado>();
            string strConn = ConfigurationManager.ConnectionStrings["DBServer"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Asociado_All";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr.GetString(0).Trim();
                    string apellido = dr.GetString(1).Trim();
                    int cedula = dr.GetInt32(2);
                    string correo = dr.GetString(3).Trim();

                    Asociado asociado = new Asociado(nombre, apellido, cedula, correo);

                    lista.Add(asociado);

                }

                dr.Close();
                conn.Close();
            }

            return lista;
        }
    }
}