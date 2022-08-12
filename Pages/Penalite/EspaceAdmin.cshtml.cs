using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace ORABANK.Pages.Pénalité
{
    public class EspaceAdminModel : PageModel
    {
        public List<PenaliteInfo> listPenalite = new List<PenaliteInfo>();

        public PenaliteInfo penaliteInfo = new PenaliteInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            String id_penalite = Request.Query["id_penalite"];

            try
            {

                String connectionString = "Data Source=DESKTOP-NP8FOEQ;Initial Catalog=Oragroup;Integrated Security=True";
                
                String connectionStringA = "Data Source=DESKTOP-NP8FOEQ;Initial Catalog=Oragroup;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sqlA = "SELECT * FROM pénalité";
                    using (SqlCommand command = new SqlCommand(sqlA, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PenaliteInfo penaliteInfo = new PenaliteInfo();

                                penaliteInfo.id_penalite = reader["id_pénalité"].ToString(); ;
                                penaliteInfo.filiale = reader["Filiales"].ToString();
                                penaliteInfo.date_penalite = reader["Date_pénalité"].ToString();
                                penaliteInfo.montant_total = reader["Montant_total"].ToString();
                                penaliteInfo.montant_cfa = reader["Montant_cfa"].ToString();
                                penaliteInfo.montant_monnaie_local = reader["Montant_monnaie_local"].ToString();
                                penaliteInfo.payement = reader["Payement"].ToString();
                                penaliteInfo.motif = reader["Motif"].ToString();
                                penaliteInfo.loi = reader["Loi"].ToString();
                                penaliteInfo.observation = reader["Observation"].ToString();
                                penaliteInfo.devise = reader["Devise"].ToString();

                                listPenalite.Add(penaliteInfo);
                                Console.WriteLine("--------------" + listPenalite.Count());



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());

            }


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

            successMessage = "Suppression Effectuer !";

            Response.Redirect("/Penalite/Acceuil");
        }
    }

}
