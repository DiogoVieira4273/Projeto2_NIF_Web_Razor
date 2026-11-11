using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Projeto2_NIF_Web_Razor.Pages.NIF_Empresa
{
    public class IndexModel : PageModel
    {
        public List<CompanyInfo> listCompanies = new List<CompanyInfo>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=NIFDB";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Select * from NIF_Empresa";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CompanyInfo companyInfo = new CompanyInfo();
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

                                listCompanies.Add(companyInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class CompanyInfo
    {
        public int ID { get; set; }
        public int NIF { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PC4 { get; set; }
        public int PC3 { get; set; }
        public string Region { get; set; }
        public string County { get; set; }
        public string Parish { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Website { get; set; }
        public int Fax { get; set; }
        public string Imagem_URL { get; set; }

    }
}