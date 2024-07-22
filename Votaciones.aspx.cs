using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaDeVotaciones2
{
    public partial class Votaciones : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCandidatos();
            }
        }

        private void CargarCandidatos()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SistemaDeVotosDB"].ConnectionString;
            string query = "SELECT CandidatoID, Nombre FROM Candidatos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        ddlCandidatos.DataSource = reader;
                        ddlCandidatos.DataTextField = "Nombre";
                        ddlCandidatos.DataValueField = "CandidatoID";
                        ddlCandidatos.DataBind();
                        ddlCandidatos.Items.Insert(0, new ListItem("Seleccione un candidato", ""));
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Error al cargar candidatos: " + ex.Message;
                    }
                }
            }
        }

        protected void btnVote_Click(object sender, EventArgs e)
        {
            string candidatoID = ddlCandidatos.SelectedValue;

            if (string.IsNullOrEmpty(candidatoID))
            {
                lblError.Text = "Debe seleccionar un candidato.";
                return;
            }

            try
            {
                RegistrarVoto(int.Parse(candidatoID));
                lblSuccess.Text = "Voto registrado exitosamente.";
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al registrar el voto: " + ex.Message;
            }
        }

        private void RegistrarVoto(int candidatoID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SistemaDeVotosDB"].ConnectionString;
            string query = "INSERT INTO Votos (CandidatoID) VALUES (@CandidatoID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CandidatoID", candidatoID);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        ActualizarResultados(candidatoID);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al registrar el voto: " + ex.Message);
                    }
                }
            }
        }

        private void ActualizarResultados(int candidatoID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SistemaDeVotosDB"].ConnectionString;
            string query = "UPDATE Resultados SET NumeroDeVotos = NumeroDeVotos + 1 WHERE CandidatoID = @CandidatoID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CandidatoID", candidatoID);

                    try
                    {
                        connection.Open();
                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            // Si no se actualizó ningún registro, insertamos un nuevo resultado
                            query = "INSERT INTO Resultados (CandidatoID, NumeroDeVotos) VALUES (@CandidatoID, 1)";
                            using (SqlCommand insertCommand = new SqlCommand(query, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@CandidatoID", candidatoID);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al actualizar los resultados: " + ex.Message);
                    }
                }
            }
        }
    }
}
