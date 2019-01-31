using JeuxMemory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class PageIdentification : Form
    {
        public PageIdentification()
        {
            InitializeComponent();
        }

        static string SqlConnectionString = @"Server=.\SQLExpress;Database=memoryBDD;Trusted_Connection=Yes";


        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString);
            connection.Open();
            SqlCommand firstInsert = connection.CreateCommand();
            firstInsert.CommandText = "INSERT INTO Joueurs(Nom_J, Prenom_J, Adresse_J,Sexe_J,Pseudo_J,MdP_J) VALUES ('" + Nom.Text + "','" + Prenom.Text + "','" + Adresse.Text + "','" + Sexe.Text + "','" + Pseudo.Text + "','" + MdP.Text + "')";
            firstInsert.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Autentification ok vous pouvez jouez");
            Nom.Text = "";
            Prenom.Text = "";
            Adresse.Text = "";
            Sexe.Text = "";
            Pseudo.Text = "";
            MdP.Text = "";



        }

        private void Administrateur_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            SqlDataAdapter select = new SqlDataAdapter("Select * From LoginAd where log ='" + textBox1.Text + "' and passowrd ='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            select.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Hide();
                Admin admin = new Admin();
                admin.Show();

            }
            else
            {
                MessageBox.Show("Veuillez entre bon login et mot de passe");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {



            Jeux jeux = new Jeux();
            jeux.Show();
            Hide();

        }
    }

}
