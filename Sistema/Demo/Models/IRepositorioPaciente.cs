using Demo.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public interface IRepositorioPaciente
    {
        void AgregarPaciente(Paciente paciente);
        void BorrarPaciente(int id);
        Paciente PacientePorID(int id);
        List<Paciente> ListarPacientes();
        void ModificarPaciente(Paciente paciente);
    }
    
    public class SQLiteRepositorioPaciente : IRepositorioPaciente
    {
        public readonly string cadenaConexion;

        public SQLiteRepositorioPaciente(string cadena)
        {
            cadenaConexion = cadena;
        }

        public void AgregarPaciente(Paciente paciente)
        {
            string consultaSQL = "INSERT INTO pacientes (" +
                          "pacienteNombre," +
                          "pacienteEmail," +
                          "pacienteTelefono," +
                          "pacienteDni," +
                          "pacienteFechaNac," +
                          "pacienteSexo)" +
                      "VALUES(" +
                          "@nombre," +
                          "@email," +
                          "@telefono," +
                          "@dni," +
                          "@fechaNac," +
                          "@sexo);";
            try
            {
                using(var conexion = new SQLiteConnection(cadenaConexion))
                {
                    using(SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        command.Parameters.AddWithValue("@nombre",paciente.PacienteNombre);
                        command.Parameters.AddWithValue("@email",paciente.PacienteEmail);
                        command.Parameters.AddWithValue("@telefono",paciente.PacienteTelefono);
                        command.Parameters.AddWithValue("@dni",paciente.PacienteDni);
                        command.Parameters.AddWithValue("@fechaNac",paciente.PacienteFechaNac);
                        command.Parameters.AddWithValue("@sexo",paciente.PacienteSexo);
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
        //Completar BorrarPaciente
        public void BorrarPaciente(int id)
        {

        }

        public Paciente PacientePorID(int id)
        {
            Paciente paciente = new();
            try
            {
                string consultaSQL = "SELECT * FROM pacientes WHERE pacienteId = @id";
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {
                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        conexion.Open();
                        command.Parameters.AddWithValue("@id", id);
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                paciente = new Paciente()
                                {
                                    PacienteId = Convert.ToInt32(dataReader["pacienteId"]),
                                    PacienteDni = dataReader["pacienteDni"].ToString(),
                                    PacienteEmail = dataReader["pacienteEmail"].ToString(),
                                    PacienteFechaNac = Convert.ToDateTime(dataReader["pacienteFechaNac"]),
                                    PacienteNombre = dataReader["pacienteNombre"].ToString(),
                                    PacienteSexo = Convert.ToChar(dataReader["pacienteSexo"]),
                                    PacienteTelefono = dataReader["pacienteTelefono"].ToString(),
                                };
                                
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
            return paciente;
        }

        public List<Paciente> ListarPacientes()
        {
            List<Paciente> listado = new();
            try
            {
                string consultaSQL = "SELECT * FROM pacientes";
                using (var conexion = new SQLiteConnection(cadenaConexion))
                {

                    using (SQLiteCommand command = new(consultaSQL, conexion))
                    {
                        conexion.Open();
                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Paciente paciente = new Paciente()
                                {
                                    PacienteId = Convert.ToInt32(dataReader["pacienteId"]),
                                    PacienteDni = dataReader["pacienteDni"].ToString(),
                                    PacienteEmail = dataReader["pacienteEmail"].ToString(),
                                    PacienteFechaNac = Convert.ToDateTime(dataReader["pacienteFechaNac"]),
                                    PacienteNombre = dataReader["pacienteNombre"].ToString(),
                                    PacienteSexo = Convert.ToChar(dataReader["pacienteSexo"]),
                                    PacienteTelefono = dataReader["pacienteTelefono"].ToString(),
                                };
                                listado.Add(paciente);
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
            return listado;
        }

        public void ModificarPaciente(Paciente paciente)
        {
            string consultaSQL = "UPDATE pacientes SET " +
                          "pacienteNombre = @nombre," +
                          "pacienteEmail = @email," +
                          "pacienteTelefono = @telefono," +
                          "pacienteDni = @dni," +
                          "pacienteFechaNac = @fechaNac," +
                          "pacienteSexo = @sexo " +
                      "WHERE pacienteId = @id;";
            using(var conexion = new SQLiteConnection(cadenaConexion))
            {
                using(SQLiteCommand command = new(consultaSQL, conexion))
                {
                    command.Parameters.AddWithValue("@nombre", paciente.PacienteNombre);
                    command.Parameters.AddWithValue("@email", paciente.PacienteEmail);
                    command.Parameters.AddWithValue("@telefono", paciente.PacienteTelefono);
                    command.Parameters.AddWithValue("@dni", paciente.PacienteDni);
                    command.Parameters.AddWithValue("@fechaNac", paciente.PacienteFechaNac);
                    command.Parameters.AddWithValue("@sexo", paciente.PacienteSexo);
                    command.Parameters.AddWithValue("@id", paciente.PacienteId);
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
        }
    }
}
