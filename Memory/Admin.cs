using Memory;
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

namespace JeuxMemory
{
    public partial class Admin : Form
    {
        static string SqlConnectionString = @"Server=.\SQLExpress;Database=memoryBDD;Trusted_Connection=Yes";
        public Admin()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(SqlConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Joueurs ", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            comboBox2.Items.Clear();
            while (dr.Read())
            {

                comboBox2.Items.Add(dr[1].ToString() + " " + dr[2].ToString());
            }
            dr.Close();
            connection.Close();

        }

        private void BtRetour_Click(object sender, EventArgs e)
        {
            PageIdentification pageIdentification = new PageIdentification();
            pageIdentification.Show();
            Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Joueurs";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Joueur supprimé");
            comboBox2.Text = "";

        }

    }
}