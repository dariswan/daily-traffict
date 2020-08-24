using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_Pengpol
{
    public partial class prediksi : Form
    {
        private static dataset fdataset;
        private static hasil fhasil;
        private double x1, x2, b1, b2, a, determinasi, korelasi, error;
        double hasil;

        private void prediksi_Load(object sender, EventArgs e)
        {

        }

        string data1, data2, data3, data4, data5, data6, data7, data8;
		
		//INSTANSIASI DARI NILAI FORM SEBELUMNYA
        public prediksi(double a, double b1, double b2, double determinasi, double korelasi, double error)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.a = a;
            this.b1 = b1;
            this.b2 = b2;
            this.determinasi = determinasi;
            this.korelasi = korelasi;
            this.error = error;

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            fdataset = new dataset();
            this.Hide();
            fdataset.Show();
        }
		
		//MENGAMBIL DATA DARI FORM YANG TELAH DIISI SEBAGAI DATA TRAINING
        private void btnHitung_Click(object sender, EventArgs e)
        {
            ambilnilai();
            hitung();

            data1 = textBox1.Text;
            data2 = textBox2.Text;
             data3 = textBox3.Text;
             data4 = textBox4.Text;
             data5 = textBox5.Text;
             data6 = comboBox1.Text;
             data7 = comboBox2.Text;
             data8 = comboBox3.Text;

            pindah();
        }
		
		//MENGAMBIL NILIAI DAN MENTRANSFORMASI NILAI YANG KATEGORIAL MENJADI KONTINIU
        void ambilnilai()
        {
            x1 = (double.Parse(textBox2.Text)/1) + (double.Parse(textBox3.Text) / 2)+ (double.Parse(textBox4.Text) / 3)+ (double.Parse(textBox5.Text) / 4);
            if (comboBox2.SelectedItem.ToString() == "LU")
            {
                x2 = 2;
            }
            else if (comboBox2.SelectedItem.ToString() == "JJS")
            {
                x2 = 1;
            }
            else
                x2 = 0;
        }
		
		//MENGHITUNG HASIL PREDIKSI REGRESI BERGANDA
        void hitung()
        {
            hasil = a + (b1 * x1) + (b2 * x2);
        }

        
		//PINDAH KE FORM SELANJUTNYA
        void pindah()
        {
            fhasil = new hasil(hasil, data1, data2, data3, data4, data5, data6, data7, data8, determinasi, korelasi, error,a,b1,b2);
            this.Hide();
            fhasil.Show();
        }
    }
}
