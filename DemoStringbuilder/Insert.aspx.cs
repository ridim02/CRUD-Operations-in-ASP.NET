using  System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DemoStringbuilder
{
    public partial class Insert : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (Request.QueryString["editID"] != null)
                {
                    // querystring bata key haru tanne
                    int editID = Convert.ToInt32(Request.QueryString["EditID"]);
                    // LoadRecordForEditing(editID);

                    // hiddenFieldEditID = editID;

                    // textfield ma data dekhaune
                    id.Text = editID.ToString();
                }
        }

        SqlConnection con = new SqlConnection(@"Data Source=RIDIM;Initial Catalog=ridim;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["editID"] != null)
            {
                int editID = Convert.ToInt32(id.Text);
                string editName = name.Text;
                string editAddress = add.Text;
                int editAge = Convert.ToInt32(age.Text);
                int editSalary = Convert.ToInt32(sal.Text);

                // update garne
                using (SqlCommand cmd = new SqlCommand("UpdateData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", editID);
                    cmd.Parameters.AddWithValue("@Name", editName);
                    cmd.Parameters.AddWithValue("@Address", editAddress);
                    cmd.Parameters.AddWithValue("@Age", editAge);
                    cmd.Parameters.AddWithValue("@Salary", editSalary);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                // Redirect back to the View.aspx page
                Response.Redirect("View.aspx");
            }
            else
            {
                int formid = int.Parse(id.Text);
                string formname = name.Text;
                string formadd = add.Text;
                int formage = int.Parse(age.Text);
                int formsal = int.Parse(sal.Text);

                con.Open();
                SqlCommand com = new SqlCommand("exec PutData'" + formid + "','" + formname + "','" + formadd + "','" + formage + "','" + formsal + "'", con);
                com.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted.');", true);

                id.Text = string.Empty;
                name.Text = string.Empty;
                add.Text = string.Empty;
                age.Text = string.Empty;
                sal.Text = string.Empty;


                con.Close();
            }
            Response.Redirect("View.aspx");
        }
    }
}