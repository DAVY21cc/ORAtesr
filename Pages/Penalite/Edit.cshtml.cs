using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ORABANK.Pages.Pénalité
{
    public class EditModel : PageModel
    {
        public PenaliteInfo penaliteInfo = new PenaliteInfo();
        public String errorMessage = "";
        public String successMessage = "";
         

        public void OnGet()
        {
            String id_penalite = Request.Query["id_penalite"];
            String filiale = Request.Query["filiale"];
            try
            {
                String connectionString = "Data Source=DESKTOP-NP8FOEQ;Initial Catalog=Oragroup;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM pénalité WHERE id_pénalité = @id_penalite ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_penalite", id_penalite);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                penaliteInfo.id_penalite = "" + reader.GetInt32(0);
                                penaliteInfo.filiale = reader.GetString(1);
                                penaliteInfo.date_penalite = reader.GetDateTime(2).ToString();
                                penaliteInfo.montant_total = reader.GetInt32(3).ToString();
                                penaliteInfo.montant_cfa = reader.GetInt32(4).ToString();
                                penaliteInfo.montant_monnaie_local = reader.GetInt32(5).ToString();
                                penaliteInfo.payement = reader.GetBoolean(6).ToString();
                                penaliteInfo.motif = reader.GetString(7);
                                penaliteInfo.loi = reader.GetString(8);
                                penaliteInfo.observation = reader.GetString(9);
                                penaliteInfo.devise = reader.GetString(10);

                            }
                        }
                    }
                }
            }
            catch(Exception ex){
                errorMessage = ex.Message;
            }
        }
        public void onPost()
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
                String connectionString = "Data Source=DESKTOP-NP8FOEQ;Initial Catalog=Oragroup;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE pénalité SET Filiales = @filiale , Date_pénalité = @date , Montant_total = @montant_total , Montant_cfa =  @montant_cfa , Montant_monnaie_local = @montant_monnaie_local, Payement = @payement, Motif = @motif, Loi = @loi , Observation =  @observation , Devise = @devise WHERE id_pénalité = @id_penalite";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_penalite",penaliteInfo.id_penalite);
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
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            successMessage = " Modification Effectuer ! ";

            Response.Redirect("/Penalite/Acceuil");
        }
    }
}
