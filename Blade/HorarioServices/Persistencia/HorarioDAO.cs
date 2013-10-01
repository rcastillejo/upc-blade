using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Data.SqlClient;
using HorarioServices.Dominio;
using HorarioServices.Persistencia;

namespace HoarioServices.Persistencia
{
    public class HorarioDAO
    {
        public Horario Crear(Horario horarioACrear)
        {
            Horario horarioCreado = null;
            string sql = "INSERT INTO TB_HORARIO VALUES(@cod,@dia,@fecIni,@fecFin)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", horarioACrear.Codigo));
                    com.Parameters.Add(new SqlParameter("@dia", horarioACrear.Dia));
                    com.Parameters.Add(new SqlParameter("@fecIni", horarioACrear.HoraInicio));
                    com.Parameters.Add(new SqlParameter("@fecFin", horarioACrear.HoraFin));
                    com.ExecuteNonQuery();
                }
            }
            horarioCreado = Obtener(horarioACrear.Codigo, horarioACrear.Dia);
            return horarioCreado;
        }
        public Horario Obtener(int codigo, string dia)
        {
            Horario horarioEncontrado = null;
            string sql = "SELECT * FROM TB_HORARIO WHERE cod_esp=@cod AND dia=@dia";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    com.Parameters.Add(new SqlParameter("@dia", dia));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            horarioEncontrado = new Horario()
                            {
                                Codigo = (int)resultado["cod_esp"],
                                Dia = (string)resultado["dia"],
                                HoraInicio = (string)resultado["hora_inicio"],
                                HoraFin = (string)resultado["hora_fin"]
                            };
                        }
                    }
                }
                con.Close();
            }
            return horarioEncontrado;
        }
        public Horario Modificar(Horario horarioAModificar)
        {
            Horario horarioModificado = null;
            string sql = "UPDATE TB_HORARIO SET hora_inicio=@horaIni, hora_fin=@horaFin WHERE cod_esp=@cod AND dia=@dia";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", horarioAModificar.Codigo));
                    com.Parameters.Add(new SqlParameter("@dia", horarioAModificar.Dia));
                    com.Parameters.Add(new SqlParameter("@horaIni", horarioAModificar.HoraInicio));
                    com.Parameters.Add(new SqlParameter("@horaFin", horarioAModificar.HoraFin));
                    com.ExecuteNonQuery();
                }
                con.Close();
            }
            horarioModificado = Obtener(horarioAModificar.Codigo, horarioAModificar.Dia );
            return horarioModificado;
        }
        public void Eliminar(int codigo, string dia)
        {
            string sql = "DELETE FROM TB_HORARIO  WHERE cod_esp=@cod AND dia=@dia";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    com.Parameters.Add(new SqlParameter("@dia", dia));
                    com.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        public List<Horario> ListarTodos(int codigo)
        {
            Horario horarioEncontrado = null;
            List<Horario> horarios = new List<Horario>();
            string sql = "SELECT * FROM TB_HORARIO WHERE cod_esp=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            horarioEncontrado = new Horario()
                            {
                                Codigo = (int)resultado["cod_esp"],
                                Dia = (string)resultado["dia"],
                                HoraInicio = (string)resultado["hora_inicio"],
                                HoraFin = (string)resultado["hora_fin"]
                            };
                            horarios.Add(horarioEncontrado);
                        }
                    }
                }
                con.Close();
            }
            return horarios;
        }
    }
}