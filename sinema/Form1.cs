using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinema
{
    public partial class Form1 : Form
    {
        BindingList<Sinema> sinema = new BindingList<Sinema>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Sinema film1 = new Sinema(1, "kıyı ustu",2, "aksiyon", false, new DateTime(2023, 11, 06));
            Sinema film2 = new Sinema(2, "kıyı ustu", 3, "aksiyon", true, new DateTime(2023, 11, 06));


            sinema.Add(film1);
            sinema.Add(film2);
           
            dataGridView1.DataSource = sinema;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string filmAdı = txtFilm.Text;
            int sure=Convert.ToInt32(txtSure.Text);
            string turu= cbTuru.Text;
            bool begendim = cbBegendim.Checked;
            DateTime tarih = DateTime.Now;



            Sinema film = new Sinema(id, filmAdı, sure, turu,  begendim,  tarih);

                  
            sinema.Add(film);

            txtFilm.Clear();
            txtId.Clear();
            txtSure.Clear();
            cbBegendim.Checked = false;



        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
               Sinema sinema = (Sinema)dataGridView1.SelectedRows[0].DataBoundItem;
                sinema.FilmAdi = txtFilm.Text;
                sinema.KayitTarih = dateTimePicker2.Value;
                sinema.Begendi = cbBegendim.Checked;
                sinema.Turu = cbTuru.Text;


                dataGridView1.Refresh();





            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Sinema sinema = (Sinema)dataGridView1.SelectedRows[0].DataBoundItem;

                txtId.Text = sinema.Id.ToString();
                txtFilm.Text =sinema.FilmAdi;
                txtSure.Text = sinema.Sure.ToString();
               cbTuru.Text =sinema.Turu;
               cbBegendim.Checked =sinema.Begendi;
                dateTimePicker2.Value = sinema.KayitTarih;


            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Sinema hasta = (Sinema)dataGridView1.SelectedRows[0].DataBoundItem;

                DialogResult sonuc = MessageBox.Show(hasta.FilmAdi + "silinsin mi?", "kayıt silme", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (sonuc == DialogResult.Yes)
                {
                    sinema.Remove(hasta);
                }
            }
        }
    }
}
