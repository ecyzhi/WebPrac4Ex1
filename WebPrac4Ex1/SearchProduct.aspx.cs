using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPrac4Ex1
{
    public partial class SearchProduct : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dtr;
        DataSet ds;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ACER\\source\\repos\\WebPrac4Ex1\\WebPrac4Ex1\\App_Data\\Northwind.MDF;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            lblResult.Text = " ";
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT COUNT(P.ProductName) from Categories C, Products P where C.CategoryID = P.CategoryID and CategoryName LIKE @param1", con);
            cmd.Parameters.Add("@param1", DropDownList1.Text);
            //cmd.ExecuteReader();
            int numOfQuery = (int)cmd.ExecuteScalar();
            lblResult.Text = " " + numOfQuery;

            cmd = new SqlCommand("SELECT P.ProductName, P.UnitPrice from Categories C, Products P where C.CategoryID = P.CategoryID and CategoryName LIKE @param1", con);
            cmd.Parameters.Add("@param1", DropDownList1.Text);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();

            con.Close();

        }
    }
}