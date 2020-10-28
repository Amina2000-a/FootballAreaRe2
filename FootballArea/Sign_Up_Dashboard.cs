using FootballArea.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballArea
{
    public partial class Sign_Up_Dashboard : Form
    {
        FootballAreaDBEntities db = new FootballAreaDBEntities();
        public Sign_Up_Dashboard()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string firstname = txtFirstname.Text;
            string lastname = txtLastname.Text;
            string phone = txtPhone.Text;
            string password = txtRepeatPassword.Text;
            string repeatPassword = txtRepeatPassword.Text;
            string[] myArray = new[] { firstname, lastname, phone, password, repeatPassword};
            if (Extensions.IsEmptyString(myArray, string.Empty))
            {
                if (long.TryParse(phone, out long phoneL))
                {
                    if (password.Length > 5)
                    {
                        if (password == repeatPassword)
                        {
                            lblError.Visible = false;

                            Customer cus = new Customer()
                            {
                                Firstname = firstname,
                                Lastname = lastname,
                                Phone = phone,
                                Password = password.HashMe(),
                                
                            };
                            db.Customer.Add(cus);
                            db.SaveChanges();
                            MessageBox.Show(cus.Firstname + " " + cus.Lastname + " added successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            lblError.Text = "Please,Password and Confirm password does not match!";
                            lblError.Visible = true;
                        }
                    }
                    else
                    {
                        lblError.Text = "Please,Password length should be greater 6 charachter!";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    lblError.Text = "Please,Phone number non-numeric charachter!";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Please,Fill all the field!";
                lblError.Visible = true;
            }
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
