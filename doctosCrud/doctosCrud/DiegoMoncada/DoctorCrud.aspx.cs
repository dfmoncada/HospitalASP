using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using doctosCrud.Models;
using Oracle.ManagedDataAccess.Client;

namespace doctosCrud
{
    public partial class DoctorCrud : System.Web.UI.Page
    {
        private CalvinDb db = new CalvinDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            loaddoctors();
        }

        public void loaddoctors()
        {
            try
            {
                List<Doctor> ds = db.Get();
                slc_doctors.Items.Clear();
                slc_doctors_u.Items.Clear();
                for(int i = 1; i < tbl_doctors.Rows.Count; )
                {
                    tbl_doctors.Rows.RemoveAt(i);
                }
                foreach (Doctor d in ds)
                {
                    ListItem li = new ListItem();
                    li.Text = d.Id + ". " + d.Name;
                    li.Value = d.Id + "";
                    slc_doctors.Items.Add(li);
                    slc_doctors_u.Items.Add(li);


                    TableRow tr = new TableRow();
                    TableCell tc = new TableCell();
                    tc.Text = d.Name;
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = d.Specialization;
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = d.Resume;
                    tr.Cells.Add(tc);
                    tr.Cells.Add(new TableCell());
                    tbl_doctors.Rows.Add(tr);

                }
                if (Session["type"] == null)
                {
                    Page.Controls.Remove(create);
                }
                else if(Session["type"].ToString()!="admin")
                {
                    Page.Controls.Remove(create);
                }
            }
            catch (OracleException ex)
            {
                lbl_message.Text = ex.Message;
            }
        }


        protected void btn_create_click(object sender, EventArgs e)
        {
            Doctor d = new Doctor(Convert.ToInt32(txt_id_c.Text),
                txt_name_c.Text,
                txt_special_c.Text,
                txt_resume_c.Text);
            
            try
            {
                db.Add(d);
                lbl_message.Text = db.Message;
            }
            catch (OracleException ex)
            {
                lbl_message.Text = ex.Message;
            }
            loaddoctors();
        }

        protected void btn_update_terms_Click(object sender, EventArgs e)
        {
            Doctor d = new Doctor(Convert.ToInt32(slc_doctors_u.SelectedValue),
                txt_name_u.Text,
                txt_special_u.Text,
                txt_resume_u.Text);

            try
            {
                db.Update(d);
                lbl_message.Text = db.Message;
            }
            catch (OracleException ex)
            {
                lbl_message.Text = ex.Message;
            }
            loaddoctors();
        }

        protected void btn_delete_term_Click(object sender, EventArgs e)
        {
            Doctor d = new Doctor(Convert.ToInt32(slc_doctors.SelectedValue),
                "","","");

            try
            {
                db.Delete(d);
                lbl_message.Text = db.Message;
            }
            catch (OracleException ex)
            {
                lbl_message.Text = ex.Message;
            }
            loaddoctors();
        }
    }
}