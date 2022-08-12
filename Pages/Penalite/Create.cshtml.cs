using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ORABANK.Pages.Pénalité
{
    public class CreateModel : PageModel
    {
        public PenaliteInfo penaliteInfo = new PenaliteInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
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


            if(penaliteInfo.filiale.Length == 0 ||
               penaliteInfo.date_penalite.Length == 0 ||
               penaliteInfo.montant_total.Length == 0 ||
               penaliteInfo.montant_cfa.Length == 0 ||
               penaliteInfo.montant_monnaie_local.Length == 0||
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
                String connectionString = "Data Source=DESKTOP-NP8FOEQ;Initial Catalog=Oragroup;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO pénalité(Filiales,Date_pénalité,Montant_total,Montant_cfa,Montant_monnaie_local,Payement,Motif,Loi,Observation,Devise) Values(@filiale,@date,@montant_total,@montant_cfa,@montant_monnaie_local,@payement,@motif,@loi,@observation,@devise );";

                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@filiale", penaliteInfo.filiale);
                        command.Parameters.AddWithValue("@date", penaliteInfo.date_penalite);
                        command.Parameters.AddWithValue("@montant_total", penaliteInfo.montant_total);
                        command.Parameters.AddWithValue("@montant_cfa", penaliteInfo.montant_cfa);
                        command.Parameters.AddWithValue("@montant_monnaie_local", penaliteInfo.montant_monnaie_local);
                        command.Parameters.AddWithValue("@payement", penaliteInfo.payement);
                        command.Parameters.AddWithValue("@motif", penaliteInfo.motif);
                        command.Parameters.AddWithValue("@loi", penaliteInfo.loi);
                        command.Parameters.AddWithValue("@observation", penaliteInfo.observation);
                        command.Parameters.AddWithValue("@devise", penaliteInfo.devise);


                        command.ExecuteNonQuery();
                    }  
                }

            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            penaliteInfo.filiale = "";
            penaliteInfo.date_penalite = "";
            penaliteInfo.montant_total = "";
            penaliteInfo.montant_cfa = "";
            penaliteInfo.montant_monnaie_local = "";
            penaliteInfo.payement = "";
            penaliteInfo.motif = "";
            penaliteInfo.loi = "";
            penaliteInfo.observation = "";
            penaliteInfo.devise = "";

            successMessage = " Ajoute Effectuer  !";

            Response.Redirect("/Penalite/Acceuil");
        }
    }
}
