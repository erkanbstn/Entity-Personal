using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_DBPersonel_Deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DBPersonelEntityEntities db = new DBPersonelEntityEntities();
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void listele()
        {
            var x = from b in db.TblPersonel select new { b.ID, b.Ad, b.Soyad, b.Maaş };
            dataGridView1.DataSource = x.ToList();
               
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TblPersonel tb = new TblPersonel();
            tb.Ad = textBox2.Text;
            tb.Soyad = textBox3.Text;
            tb.Maaş = Convert.ToInt16(textBox4.Text);
            db.TblPersonel.Add(tb);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
            listele();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(textBox1.Text);
            var x = db.TblPersonel.Find(id);
            db.TblPersonel.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Silindi");
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        
        int id = Convert.ToInt16(textBox1.Text);
        var x = db.TblPersonel.Find(id);
        x.Ad = textBox2.Text;
           x.Soyad = textBox3.Text;
            x.Maaş = Convert.ToInt16(textBox4.Text);
            db.SaveChanges();
            MessageBox.Show("Güncellendi");
            listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
