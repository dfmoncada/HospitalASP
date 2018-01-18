using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using doctosCrud.Models;

namespace doctosCrud.DiegoMoncada
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private CalvinDb db = new CalvinDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            display_content();
        }

        public void display_content()
        {
            
            if (Session["username"] != null && form1.Controls.IndexOf(login)!=-1)
            {
                form1.Controls.Add(logout);
                form1.Controls.Remove(login);
            }
            else
            {
                form1.Controls.Remove(logout);
                form1.Controls.Add(login);
            }

        }

        protected void login_click(object sender, EventArgs e)
        {
            User user = new Models.User();
            user.Username = txt_user.Text;
            user.Password = txt_psw.Text;

            string message = null;

            try
            {
                user = db.getUser(user);
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                message = ex.Message;
                user = null;
            }

            lbl_error.Text = "";
            lbl_welcome.Text = "";
            if(user!=null)
            {
                Session["username"] = user.Username;
                Session["id"] = user.Id;
                Session["type"] = user.Type;
                lbl_welcome.Text = "Welcome " + Session["username"] + "!";
            }
            else
            {
                if (message != null)
                    lbl_error.Text = message;
                else
                    lbl_error.Text = "Username or password incorrect.";
            }

            display_content();
        }

        protected void logout_click(object sender, EventArgs e)
        {
            Session.Clear();

            display_content();
        }
    }
}