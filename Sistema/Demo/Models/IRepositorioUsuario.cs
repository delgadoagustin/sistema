using Demo.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public interface IRepositorioUsuario
    {
        bool existeUsuario(string usuario, string pass);
        List<Usuario> ListarUsuarios();
    }

    public class SQLiteRepositorioUsuario : IRepositorioUsuario
    {
        public readonly string cadenaConexion;
        
        public SQLiteRepositorioUsuario(string cadena)
        {
            cadenaConexion = cadena;
        }
        // Agregar Registro Usuario
        public bool existeUsuario(string usuario, string pass)
        {
            bool b = false;
            string consultaSQL = "SELECT count() FROM usuarios "
                + "WHERE usuarioNombre = @usuario AND usuarioPass = @pass;";
            try
            {
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {

                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        command.Parameters.AddWithValue("@usuario", usuario);
                        command.Parameters.AddWithValue("@pass", pass);
                        conexion.Open();
                        if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                        {
                            b = true;
                        }
                        conexion.Close();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return b;
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new();
            try
            {
                string consultaSQL = "SELECT * FROM usuarios";
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {

                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        conexion.Open();
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario()
                                {
                                    UsuarioId = Convert.ToInt32(dataReader["usuarioId"]),
                                    UsuarioNombre = dataReader["usuarioNombre"].ToString(),
                                    UsuarioPass = dataReader["usuarioPass"].ToString(),
                                    UsuarioNivel = dataReader["usuarioNivel"].ToString()
                                };
                                lista.Add(usuario);
                            }
                        }
                        conexion.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return lista;
        }
    }
}
