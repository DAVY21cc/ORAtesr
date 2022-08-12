using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ORABANK.Pages.Penalite
{
    public class RechercheModel : PageModel
    {
        public List<PenaliteInfo> listPenalite = new List<PenaliteInfo>();

        public void OnGet()
        {

            try
            {
                String Recherche = Request.Form["recherche"];
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
    }

    public class PenaliteInfo
    {
        public String id_penalite;
        public String filiale;
        public String date_penalite;
        public String montant_total;
        public String montant_cfa;
        public String montant_monnaie_local;
        public String payement;
        public String motif;
        public String loi;
        public String observation;
        public String devise;
    }
}
