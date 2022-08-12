using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ORABANK.Pages.Penalite
{
    public class AdministrateurXModel : PageModel
    {

        private readonly ILogger<PrivacyModel> _logger;
        public AdministrateurInfo administrateurInfo = new AdministrateurInfo();
        public LoginInfo loginInfo = new LoginInfo();
        public String errorMessage = "";
        public String errorMessageX = "";
        public String successMessage = "";

        public void OnGet()
        {
            loginInfo.Mail = Request.Form["mail"];
            loginInfo.Motdepasse = Request.Form["motdepasse"];


            if (
                loginInfo.Mail.Length == 0 ||
                loginInfo.Motdepasse.Length == 0
               )
            {
                errorMessageX = "Veuillez saisir tous les champs ! ";
                return;
            }

            try
            {
                String connectionString = "Data Source=DESKTOP-NP8FOEQ;Initial Catalog=Oragroup;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO administrateur(Mail,Motdepasse) Values(@mail,@motdepasse);";

                    if (loginInfo.Mail == "SELECT * FROM administrateur WHERE mail = @mail ")
                    {
                        if (loginInfo.Motdepasse == "SELECT * FROM administrateur WHERE motdepasse = @motdepasse ")
                        {

                            Response.Redirect("/Penalite/EspaceAdmin");

                        }
                        else
                        {
                            errorMessage = "Mot de passe incorrect !";
                            return;
                        }
                    }
                    else
                    {
                        errorMessage = "Mail incorrect !";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }
        public void onPost()
        {

            loginInfo.Mail = Request.Form["mail"];
            loginInfo.Motdepasse = Request.Form["motdepasse"];


            if (
                loginInfo.Mail.Length == 0 ||
                loginInfo.Motdepasse.Length == 0
               )
            {
                errorMessageX = "Veuillez saisir tous les champs ! ";
                return;
            }

            try
            {
                String connectionString = "Data Source=DESKTOP-NP8FOEQ;Initial Catalog=Oragroup;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO administrateur(Mail,Motdepasse) Values(@mail,@motdepasse);";

                    if (loginInfo.Mail == "SELECT * FROM administrateur WHERE mail = @mail ")
                    {
                        if (loginInfo.Motdepasse == "SELECT * FROM administrateur WHERE motdepasse = @motdepasse ")
                        {

                            Response.Redirect("/Penalite/EspaceAdmin");

                            /* using (SqlCommand command = new SqlCommand(sql, connection))
                             {
                                 command.Parameters.AddWithValue("@mail", loginInfo.Mail);
                                 command.Parameters.AddWithValue("@motdepasse", loginInfo.Motdepasse);

                                 command.ExecuteNonQuery();
                             }*/
                        }
                        else
                        {
                            errorMessage = "Mot de passe incorrect !";
                            return;
                        }
                    }
                    else
                    {
                        errorMessage = "Mail incorrect !";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

        }
    }
    public class LoginInfo
    {
        public String id_administrateur;
        public String Mail;
        public String Motdepasse;
    }
}
