using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    public class PacientesDAL: CadenaDAL
    {
        public int GuardarPacientes(PacientesCLS oPacientesCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Paciente (Nombre, Apellido, FechaNacimiento, Telefono, Email, Direccion) VALUES (@Nombre, @Apellido, @FechaNacimiento, @Telefono, @Email, @Direccion)", cn))
                    {
                          cmd.CommandType = System.Data.CommandType.Text;
                          cmd.Parameters.AddWithValue("@Nombre", oPacientesCLS.Nombre);
                          cmd.Parameters.AddWithValue("@Apellido", oPacientesCLS.Apellido);
                          cmd.Parameters.AddWithValue("@FechaNacimiento", oPacientesCLS.FechaNacimiento.ToDateTime(new TimeOnly(0, 0))); // Convert DateOnly to DateTime
                          cmd.Parameters.AddWithValue("@Telefono", oPacientesCLS.Telefono);
                          cmd.Parameters.AddWithValue("@Email", oPacientesCLS.Email);
                          cmd.Parameters.AddWithValue("@Direccion", oPacientesCLS.Direccion);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return rpta;
        }

        public List<PacientesCLS> listarPacientes()
        {
            List<PacientesCLS> lista = new List<PacientesCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarPacientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                PacientesCLS pacientes = new PacientesCLS
                                {
                                    id = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    Apellido = dr.GetString(2),
                                    FechaNacimiento = DateOnly.FromDateTime(dr.GetDateTime(3)),
                                    Telefono = dr.GetInt32(4),
                                    Email = dr.GetString(5),
                                    Direccion = dr.GetString(6)
                                };

                                lista.Add(pacientes);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    lista = null;
                    throw;
                }
            }
            return lista;
        }

        public List<PacientesCLS> filtrarPacientes(PacientesCLS obj)
        {
            List<PacientesCLS> lista = new List<PacientesCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarPacientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Añadir parámetro de filtro, por ejemplo, nombre o apellido
                        cmd.Parameters.AddWithValue("@Nombre", (object)obj.Nombre ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Apellido", (object)obj.Apellido ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Telefono", (object)obj.Telefono ?? DBNull.Value);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                PacientesCLS pacientes = new PacientesCLS
                                {
                                    id = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    Apellido = dr.GetString(2),
                                    FechaNacimiento = DateOnly.FromDateTime(dr.GetDateTime(3)),
                                    Telefono = dr.GetInt32(4),
                                    Email = dr.GetString(5),
                                    Direccion = dr.GetString(6)
                                };

                                lista.Add(pacientes);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    lista = null;
                    throw;
                }
            }
            return lista;
        }

    }
}
