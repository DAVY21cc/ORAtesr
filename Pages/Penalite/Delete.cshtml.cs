using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Windows;

namespace ORABANK.Pages.Pénalité
{
    public class DeleteModel : PageModel
    {

        public PenaliteInfo penaliteInfo = new PenaliteInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {

            try
            {
                String id_penalite = Request.Query["id_penalite"];

                string connectionString = "Data Source=DESKTOP-NP8FOEQ;Initial Catalog=Oragroup;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "DELETE FROM pénalité WHERE id_pénalité = @id_penalite";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_penalite", id_penalite);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            successMessage = "  Suppression Effectuer ";

            Response.Redirect("/Penalite/Acceuil");
        }

        public void OnPost()
        {
            penaliteInfo.filiale = Request.Form["filiale"];
            penaliteInfo.date_penalite = Request.Form["date"];
            penaliteInfo.montant_total = Request.Form["montant_total"];
            penaliteInfo.montant_cfa = Request.Form["montant_cfa"];
            penaliteInfo.montant_monnaie_local = Request.Form["montant_monnaie_local"];
            penaliteInfo.payement = Request.Form["payement"];
            penaliteInfo.motif = Request.Form["motif"];
            penaliteInfo.loi = Request.Form["loi"];
            penaliteInfo.observation = Request.Form["observation"];
            penaliteInfo.devise = Request.Form["devise"];


            if (penaliteInfo.filiale.Length == 0 ||
               penaliteInfo.date_penalite.Length == 0 ||
               penaliteInfo.montant_total.Length == 0 ||
               penaliteInfo.montant_cfa.Length == 0 ||
               penaliteInfo.montant_monnaie_local.Length == 0 ||
               penaliteInfo.payement.Length == 0 ||
               penaliteInfo.motif.Length == 0 ||
               penaliteInfo.loi.Length == 0 ||
               penaliteInfo.observation.Length == 0 ||
               penaliteInfo.devise.Length == 0
               )
            {
                errorMessage = "Veuillez saisir tous les champs !";
                return;
            }
            

            try
            {
                String id_penalite = Request.Query["id_penalite"];

                string connectionString = "Data Source=DESKTOP-NP8FOEQ;Initial Catalog=Oragroup;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "DELETE FROM pénalité WHERE id_pénalité = @id_penalite";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_penalite", id_penalite);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            successMessage = "  Suppression Effectuer ";

            Response.Redirect("/Penalite/Acceuil");
        }
    }
    
}
