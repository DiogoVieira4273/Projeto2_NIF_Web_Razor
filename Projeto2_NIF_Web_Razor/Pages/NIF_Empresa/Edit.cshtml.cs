using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Projeto2_NIF_Web_Razor.Pages.NIF_Empresa
{
    public class EditModel : PageModel
    {
        public CompanyInfo companyInfo = new CompanyInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            int id = int.Parse(Request.Query["id"]);

            try
            {
                String connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=NIFDB";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Select * from NIF_Empresa where id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                companyInfo.ID = reader.GetInt32(0);
                                companyInfo.NIF = reader.GetInt32(1);
                                companyInfo.Name = reader.GetString(2);
                                companyInfo.Address = reader.GetString(3);
                                companyInfo.PC4 = reader.GetInt32(4);
                                companyInfo.PC3 = reader.GetInt32(5);
                                companyInfo.Region = reader.GetString(6);
                                companyInfo.County = reader.GetString(7);
                                companyInfo.Parish = reader.GetString(8);
                                companyInfo.Email = reader.GetString(9);
                                companyInfo.Phone = reader.GetInt32(10);
                                companyInfo.Website = reader.GetString(11);
                                companyInfo.Fax = reader.GetInt32(12);
                                companyInfo.Imagem_URL = reader.GetString(13);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public void OnPost()
        {
            companyInfo.ID = int.Parse(Request.Form["id"]);
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

            if (companyInfo.ID == 0 || companyInfo.NIF == 0 || companyInfo.Name.Length == 0 || companyInfo.Address.Length == 0 || companyInfo.PC4 == 0 || companyInfo.PC3 == 0 || companyInfo.Region.Length == 0 || companyInfo.County.Length == 0 || companyInfo.Parish.Length == 0 || companyInfo.Email.Length == 0 || companyInfo.Phone == 0 || companyInfo.Website.Length == 0 || companyInfo.Fax == 0 || companyInfo.Imagem_URL.Length == 0)
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
                    String sql = "UPDATE NIF_Empresa SET NIF = @NIF,Name = @Name,Address = @Address,PC4 = @PC4,PC3 = @PC3,Region = @Region,County = @County,Parish = @Parish,Email = @Email,Phone = @Phone,Website = @Website,Fax = @Fax,Imagem_URL = @Imagem_URL where ID=@id";
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
                        command.Parameters.AddWithValue("@Website", companyInfo.Website);
                        command.Parameters.AddWithValue("@Fax", companyInfo.Fax);
                        command.Parameters.AddWithValue("@Imagem_URL", companyInfo.Imagem_URL);
                        command.Parameters.AddWithValue("@id", companyInfo.ID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/NIF_Empresa/Index");
        }
    }
}