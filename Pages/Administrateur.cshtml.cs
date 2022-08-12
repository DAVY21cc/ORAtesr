using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace ORABANK.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public AdministrateurInfo administrateurInfo = new AdministrateurInfo();
        public String errorMessage = "";
        public String errorMessageX = "";
        public String successMessage = "";

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }


        public void OnPost()
        {         

            /*UTILISATEUR*/


            administrateurInfo.Mail = Request.Form["mail"];
            administrateurInfo.Motdepasse = Request.Form["motdepasse"];


            if (
                administrateurInfo.Mail.Length == 0 ||
                administrateurInfo.Motdepasse.Length ==  0 
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
                    String sql = "INSERT INTO  administrateur(Mail,Motdepasse)  Values(@mail,@motdepasse);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@mail", administrateurInfo.Mail);
                        command.Parameters.AddWithValue("@motdepasse", administrateurInfo.Motdepasse);
                        
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
           
            administrateurInfo.Mail = "";
            administrateurInfo.Motdepasse = "";

            successMessage = "Utilisateur enregistrer !";

            Response.Redirect("/Login");


            /*LOGIN*/

        }     
             
    }

    public class AdministrateurInfo
    {
        public String id_administrateur;
        public String Mail;
        public String Motdepasse;

    }
}