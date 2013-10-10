using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ReservasServices.Dominio;

namespace ReservasServices.Persistencia
{
    public class ReservaDAO
    {
        private static string DATEFORMAT = "yyyy-MM-dd HH:mm:ss";

        private int SelectMax()
        {
            int codigo = 0;
            string sql = "SELECT MAX(codigo) as 'codigo' FROM TB_RESERVA;";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            try
                            {
                                codigo = (int)resultado["codigo"];
                            }
                            catch (InvalidCastException e)
                            {
                                codigo = 0;
                            }
                        }
                    }
                }
                con.Close();
            }
            return codigo + 1;
        }
        
        public Reserva Crear(Reserva reservaACrear)
        {
            int codigo = SelectMax();
            Reserva reservaCreado = null;
            string sql = "SET LANGUAGE Spanish; INSERT INTO TB_RESERVA VALUES(@cod,@codEsp,DATENAME(dw,@fecIni),@cantHora,@fecIni,@fecFin,@estado)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    com.Parameters.Add(new SqlParameter("@codEsp", reservaACrear.CodigoEspacio));
                    com.Parameters.Add(new SqlParameter("@cantHora", reservaACrear.CantidadHoras));
                    com.Parameters.Add(new SqlParameter("@fecIni", reservaACrear.FechaInicio));
                    com.Parameters.Add(new SqlParameter("@fecFin", reservaACrear.FechaFin));
                    com.Parameters.Add(new SqlParameter("@estado", reservaACrear.Estado));
                    com.ExecuteNonQuery();
                }
            }
            reservaCreado = Obtener(codigo);
            return reservaCreado;
        }

        public Reserva Obtener(int codigo)
        {
            Reserva reservaEncontrado = null;
            string sql = "SELECT * FROM TB_RESERVA WHERE codigo=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            reservaEncontrado = new Reserva()
                            {
                                Codigo = (int)resultado["codigo"],
                                CodigoEspacio = (int)resultado["cod_esp"],
                                Dia = (string)resultado["dia"],
                                CantidadHoras = (int)resultado["cant_hora"],
                                FechaInicio = ((DateTime)resultado["fecha_inicio"]).ToString(DATEFORMAT),
                                FechaFin = ((DateTime)resultado["fecha_fin"]).ToString(DATEFORMAT),
                                Estado = (string)resultado["estado"]
                            };
                        }
                    }
                }
                con.Close();
            }
            return reservaEncontrado;
        }


        public List<Reserva> ValidarDisponibilidad(Reserva reservaAValidar)
        {
            Reserva reservaEncontrado = null;
            List<Reserva> reservas = new List<Reserva>();
            string sql = "SELECT * FROM TB_RESERVA WHERE cod_esp=@codEsp "+
                " AND ((@fecIni between fecha_inicio AND fecha_fin) OR (@fecFin between fecha_inicio AND fecha_fin))";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@codEsp", reservaAValidar.CodigoEspacio));
                    com.Parameters.Add(new SqlParameter("@fecIni", reservaAValidar.FechaInicio));
                    com.Parameters.Add(new SqlParameter("@fecFin", reservaAValidar.FechaFin));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            reservaEncontrado = new Reserva()
                            {
                                Codigo = (int)resultado["codigo"],
                                CodigoEspacio = (int)resultado["cod_esp"],
                                Dia = (string)resultado["dia"],
                                CantidadHoras = (int)resultado["cant_hora"],
                                FechaInicio = ((DateTime)resultado["fecha_inicio"]).ToString(DATEFORMAT),
                                FechaFin = ((DateTime)resultado["fecha_fin"]).ToString(DATEFORMAT),
                                Estado = (string)resultado["estado"]
                            };
                            reservas.Add(reservaEncontrado);
                        }
                    }
                }
                con.Close();
            }
            return reservas;
        }


        public Reserva Modificar(Reserva reservaAModificar)
        {
            Reserva reservaModificado = null;
            string sql = "SET LANGUAGE Spanish; UPDATE TB_RESERVA SET cod_esp=@codEsp, dia=DATENAME(dw,@fechaFin), cant_hora=@cantHora, fecha_inicio=@fechaIni, fecha_fin=@fechaFin, estado=@estado WHERE codigo=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", reservaAModificar.Codigo));
                    com.Parameters.Add(new SqlParameter("@codEsp", reservaAModificar.CodigoEspacio));
                    com.Parameters.Add(new SqlParameter("@cantHora", reservaAModificar.CantidadHoras));
                    com.Parameters.Add(new SqlParameter("@fechaIni", reservaAModificar.FechaInicio));
                    com.Parameters.Add(new SqlParameter("@fechaFin", reservaAModificar.FechaFin));
                    com.Parameters.Add(new SqlParameter("@estado", reservaAModificar.Estado));
                    com.ExecuteNonQuery();
                }
                con.Close();
            }
            reservaModificado = Obtener(reservaAModificar.Codigo);
            return reservaModificado;
        }

        public void Eliminar(int codigo)
        {
            string sql = "DELETE FROM TB_RESERVA  WHERE codigo=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    com.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        
        public List<Reserva> ListarTodos()
        {
            Reserva reservaEncontrado = null;
            List<Reserva> reservas = new List<Reserva>();
            string sql = "SELECT * FROM TB_RESERVA";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            reservaEncontrado = new Reserva()
                            {
                                Codigo = (int)resultado["codigo"],
                                CodigoEspacio = (int)resultado["cod_esp"],
                                Dia = (string)resultado["dia"],
                                CantidadHoras = (int)resultado["cant_hora"],
                                FechaInicio = ((DateTime)resultado["fecha_inicio"]).ToString(DATEFORMAT),
                                FechaFin = ((DateTime)resultado["fecha_fin"]).ToString(DATEFORMAT),
                                Estado = (string)resultado["estado"]
                            };
                            reservas.Add(reservaEncontrado);
                        }
                    }
                }
                con.Close();
            }
            return reservas;
        }
    
    }
}