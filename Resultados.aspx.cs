using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace SistemaDeVotaciones2
{
    public partial class Resultados : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadResultados();
            }
        }

        private void LoadResultados()
        {
            DataTable dtResultados = GetResultados();
            gvResultados.DataSource = dtResultados;
            gvResultados.DataBind();
        }

        private DataTable GetResultados()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Partido");
            dt.Columns.Add("NumeroDeVotos", typeof(int));
            dt.Columns.Add("Porcentaje", typeof(double));

            // Cadena de conexión
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SistemaDeVotacionesDB"].ConnectionString;
            string query = @"
                SELECT 
                    c.Nombre, 
                    c.Partido, 
                    COUNT(v.VotoID) AS NumeroDeVotos, 
                    (COUNT(v.VotoID) * 100.0 / (SELECT COUNT(*) FROM Votos)) AS Porcentaje
                FROM Candidatos c
                LEFT JOIN Votos v ON c.CandidatoID = v.CandidatoID
                GROUP BY c.Nombre, c.Partido";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores
                        // Puedes mostrar un mensaje de error en la interfaz de usuario si es necesario
                        // Aquí solo estamos escribiendo en la consola
                        Console.WriteLine("Error al obtener los resultados: " + ex.Message);
                    }
                }
            }

            return dt;
        }
    }
}
