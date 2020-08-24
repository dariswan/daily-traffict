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
    public partial class hasil : Form
    {
        private static Home fhome;
        private static error ferror;
        private double lhr, determinasi, korelasi, error;
        string data1, data2, data3, data4, data5, data6, data7, data8;
        double a, b1, b2;

        private void button1_Click(object sender, EventArgs e)
        {
            ferror = new error(a,b1,b2);
            ferror.Show();
        }
		
		//MENAMPILKAN SELURUH DATA HASIL DATA INPUTAN PADA DATA RUAS BARU
        private void hasil_Load(object sender, EventArgs e)
        {
            label19.Text=Math.Round(lhr,1).ToString();
            label10.Text=data1;
            label11.Text=data2;
            label12.Text=data3;
            label13.Text= data4;
            label14.Text=data5;
            label15.Text=data6 ;
            label16.Text=data7;
            label17.Text=data8 ;
            dt.Text ="Determinasi sebesar"+ Math.Round((determinasi*100),1).ToString()+"% variabel bebas mempengaruhi hasil LHR";
            kr.Text ="Korelasi sebesar "+ Math.Round((korelasi*100),1).ToString()+"% hubungan antara variabel bebas";
            er.Text = "Standart Error Estimate sebesar" +Math.Round(error,2).ToString();
        }
		
		//INSTANSIASI NILAI YANG DIAMBL DARI FORM SEBELUMNYA
        public hasil(double lhr, string data1, string data2, string data3, string data4, string data5, string data6, string data7, string data8,double determinasi, double korelasi, double error, double a, double b1, double b2)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.lhr = lhr;
            this.data1 = data1;
            this.data2 = data2;
            this.data3 = data3;
            this.data4 = data4;
            this.data5 = data5;
            this.data6 = data6;
            this.data7 = data7;
            this.data8 = data8;
            this.determinasi = determinasi;
            this.korelasi = korelasi;
            this.error = error;
            this.a = a;
            this.b1 = b1;
            this.b2 = b2;

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            fhome = new Home();
            this.Hide();
            fhome.Show();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
