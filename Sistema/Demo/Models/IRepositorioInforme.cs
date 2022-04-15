using Demo.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public interface IRepositorioInforme
    {
        List<Informe> ListarInformes();
        List<Informe> ListarInformes(string cadena);
        void AgregarInforme(Informe informe);
        Informe ObtenerInformePorID(int id);
        void BorrarInforme(int id);
    }
    public class SQLiteRepositorioInforme : IRepositorioInforme
    {
        public readonly string cadenaConexion;

        public SQLiteRepositorioInforme(string cadena)
        {
            cadenaConexion = cadena;
        }

        public List<Informe> ListarInformes()
        {
            List<Informe> lista = new();
            try
            {
                string consultaSQL = "SELECT * FROM informes;";
                using(var conexion = new SQLiteConnection(cadenaConexion))
                {
                    using(SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        conexion.Open();
                        using(SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Informe informe = new Informe()
                                {
                                    InformeId = Convert.ToInt32(dataReader["informeId"]),
                                    InformePacienteId = Convert.ToInt32(dataReader["informePacienteId"]),
                                    InformeUsuarioId = Convert.ToInt32(dataReader["informeUsuarioId"]),
                                    InformeDetalle = dataReader["InformeDetalle"].ToString()
                                };
                                lista.Add(informe);
                            }
                        }
                        conexion.Close();
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return lista;
        }
        //COMPLETAR ListarInformes(string cadena)
        public List<Informe> ListarInformes(string cadena)
        {
            List<Informe> lista = new();
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }
        
        public void AgregarInforme(Informe informe)
        {
            string consultaSQL = "INSERT INTO informes (" +
                          "informePacienteId," +
                          "informeUsuarioId," +
                          "informeDetalle)" +
                      "VALUES(" +
                          "@pacienteid," +
                          "@usuarioid," +
                          "@detalle);";
            try
            {
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {
                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        command.Parameters.AddWithValue("@pacienteid", informe.InformePacienteId);
                        command.Parameters.AddWithValue("@usuarioid", informe.InformeUsuarioId);
                        command.Parameters.AddWithValue("@detalle", informe.InformeDetalle);
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Informe ObtenerInformePorID(int id)
        {
            Informe informe = null;
            try
            {
                string consultaSQL = "SELECT * FROM informes WHERE informeId = @id;";
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {
                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        conexion.Open();
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                informe = new Informe()
                                {
                                    InformeId = Convert.ToInt32(dataReader["informeId"]),
                                    InformePacienteId = Convert.ToInt32(dataReader["informePacienteId"]),
                                    InformeUsuarioId = Convert.ToInt32(dataReader["informeUsuarioId"]),
                                    InformeDetalle = dataReader["InformeDetalle"].ToString()
                                };
                            }
                        }
                        conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return informe;
        }

        public void BorrarInforme(int id)
        {
            string consultaSQL = "DELETE FROM informes WHERE informeId = @id;";
            try
            {
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {
                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
