using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ORABANK.Pages
{
    public class LoginModel : PageModel
    {
        public LoginInfo loginInfo = new LoginInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
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
                errorMessage = "Veuillez saisir tous les champs !";
                return;
            }

            try
            {
                String connectionString = "Data Source=DESKTOP-NP8FOEQ;Initial Catalog=Oragroup;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO administrateur(Mail,Motdepasse) Values(@mail,@motdepasse);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@mail", loginInfo.Mail);
                        command.Parameters.AddWithValue("@motdepasse", loginInfo.Motdepasse);

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            loginInfo.Mail = "";
            loginInfo.Motdepasse = "";

            successMessage = "Utilisateur enregistrer !";
            Response.Redirect("/Penalite/EspaceAdmin");
        }

        public class LoginInfo
        {
            public String id_administrateur;
            public String Mail;
            public String Motdepasse;

        }
    }
}
