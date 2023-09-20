using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoStringbuilder
{
    public partial class View : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayData();
            }
        }

        string connectionString = @"Data Source=RIDIM;Initial Catalog=ridim;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private void DisplayData()
        {
            // SQL query to retrieve data from the database
            string query = "SELECT * FROM RidimTable WHERE status = '1'";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<table>");
                    sb.AppendLine("<tr><th>ID</th><th>Name</th><th>Address</th><th>Age</th><th>Salary</th><th>Edit</th><th>Delete</th></tr>");

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string name = reader["Name"].ToString();
                        string address = reader["Address"].ToString();
                        int age = Convert.ToInt32(reader["Age"]);
                        int salary = Convert.ToInt32(reader["Salary"]);

                        string editLink = $"<a href='Insert.aspx?editId={id}' class='btn btn-primary btn-sm'>Edit</a>";

                        sb.AppendLine($"<tr>" +
                            $"<td>{id}</td> " +
                            $"<td>{name}</td> " +
                            $"<td>{address}</td> " +
                            $"<td>{age}</td> " +
                            $"<td>{salary}</td> " +
                            $"<td>{editLink}</td>" +
                            $"<td><input type='button' Width='116px' class='btnDelete' class='btn btn-danger btn-sm' value='Delete' data-id=" +id+"></td> "+
                            $"</tr>");
                    }

                    sb.AppendLine("</table>");

                   recordsPanel.Controls.Add(new LiteralControl(sb.ToString()));
                }
            }
        }
        [WebMethod]
        public static string DeleteData(string d_id)
        {
            int id = JsonConvert.DeserializeObject<int>(d_id);
            string connectionString = @"Data Source=RIDIM;Initial Catalog=ridim; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE RidimTable SET status = '0' WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            return "test";
        }
    }
}
