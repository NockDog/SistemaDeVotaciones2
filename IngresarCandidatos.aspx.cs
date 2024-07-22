using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace SistemaDeVotaciones2
{
    public partial class IngresarCandidatos : Page
    {
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string partido = txtPartido.Text.Trim();
            string plataforma = txtPlataforma.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(partido))
            {
                lblError.Text = "Nombre y Partido son obligatorios.";
                lblSuccess.Text = ""; // Clear success message if any
                return;
            }

            try
            {
                AddCandidato(nombre, partido, plataforma);
                lblSuccess.Text = "Candidato agregado exitosamente.";
                lblError.Text = ""; // Clear error message if any
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al agregar el candidato: " + ex.Message;
                lblSuccess.Text = ""; // Clear success message if any
            }
        }

        private void AddCandidato(string nombre, string partido, string plataforma)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SistemaDeVotacionesDB"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Cadena de conexión no está configurada.");
            }

            string query = "INSERT INTO Candidatos (Nombre, Partido, Plataforma) VALUES (@Nombre, @Partido, @Plataforma)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Partido", partido);
                    command.Parameters.AddWithValue("@Plataforma", plataforma);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        // Mostrar mensaje de éxito
                        // lblSuccess.Text = "Candidato agregado exitosamente.";
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores
                        // lblError.Text = "Error: " + ex.Message;
                        throw; // Lanza la excepción para depurar
                    }
                }
            }
        }
    }
}
