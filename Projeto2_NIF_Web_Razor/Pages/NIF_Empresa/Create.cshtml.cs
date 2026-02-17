using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Projeto2_NIF_Web_Razor.Pages.NIF_Empresa
{
    public class CreateModel : PageModel
    {
        public CompanyInfo companyInfo = new CompanyInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            companyInfo.NIF = int.Parse(Request.Form["nif"]);
            companyInfo.Name = Request.Form["name"];
            companyInfo.Address = Request.Form["address"];
            companyInfo.PC4 = int.Parse(Request.Form["pc4"]);
            companyInfo.PC3 = int.Parse(Request.Form["pc3"]);
            companyInfo.Region = Request.Form["region"];
            companyInfo.County = Request.Form["county"];
            companyInfo.Parish = Request.Form["parish"];
            companyInfo.Email = Request.Form["email"];
            companyInfo.Phone = int.Parse(Request.Form["phone"]);
            companyInfo.Website = Request.Form["website"];
            companyInfo.Fax = int.Parse(Request.Form["fax"]);
            companyInfo.Imagem_URL = Request.Form["imagem_url"];

            if (companyInfo.NIF == 0 || companyInfo.Name.Length == 0 || companyInfo.Address.Length == 0 || companyInfo.PC4 == 0 || companyInfo.PC3 == 0 || companyInfo.Region.Length == 0 || companyInfo.County.Length == 0 || companyInfo.Parish.Length == 0 || companyInfo.Email.Length == 0 || companyInfo.Phone == 0 || companyInfo.Website.Length == 0 || companyInfo.Fax == 0 || companyInfo.Imagem_URL.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            try
            {
                String connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=NIFDB";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO NIF_Empresa (NIF,Name,Address,PC4,PC3,Region,County,Parish,Email,Phone,Website,Fax,Imagem_URL)VALUES(@NIF,@Name,@Address,@PC4,@PC3,@Region,@County,@Parish,@Email,@Phone,@Website,@Fax,@Imagem_URL)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@NIF", companyInfo.NIF);
                        command.Parameters.AddWithValue("@Name", companyInfo.Name);
                        command.Parameters.AddWithValue("@Address", companyInfo.Address);
                        command.Parameters.AddWithValue("@PC4", companyInfo.PC4);
                        command.Parameters.AddWithValue("@PC3", companyInfo.PC3);
                        command.Parameters.AddWithValue("@Region", companyInfo.Region);
                        command.Parameters.AddWithValue("@County", companyInfo.County);
                        command.Parameters.AddWithValue("@Parish", companyInfo.Parish);
                        command.Parameters.AddWithValue("@Email", companyInfo.Email);
                        command.Parameters.AddWithValue("@Phone", companyInfo.Phone);
                        command.Parameters.AddWithValue("@Wensite", companyInfo.Website);
                        command.Parameters.AddWithValue("@Fax", companyInfo.Fax);
                        command.Parameters.AddWithValue("@Imagem_URL", companyInfo.Imagem_URL);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            companyInfo.NIF = 0; companyInfo.Name = ""; companyInfo.Address = ""; companyInfo.PC4 = 0; companyInfo.PC3 = 0; companyInfo.Region = ""; companyInfo.County = ""; companyInfo.Parish = ""; companyInfo.Email = ""; companyInfo.Phone = 0; companyInfo.Website = ""; companyInfo.Fax = 0; companyInfo.Imagem_URL = "";
            successMessage = "New Company Added Correctly";

            Response.Redirect("/NIF_Empresa/Index");
        }
    }
}