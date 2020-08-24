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
    public partial class error : Form
    {
        double a, b1, b2,hasil;
        double[] data1 = new double[7];
        double[] data2 = new double[7];
        double[] data3 = new double[7];
        double[] data4 = new double[7];
        double[] data5 = new double[7];
        double[] data6 = new double[7];
        double[] data7 = new double[7];
        double[] data8 = new double[7];
        double[] data9 = new double[7];
        double[] data10 = new double[7];
        double[] x1 = new double[10];
        double[] x2 = new double[10];
        double[] hasildata = new double[10];
        double mse;
        double[] lhr = new double[10];

        public error(double a, double b1, double b2)
        {
            this.a = a;
            this.b1 = b1;
            this.b2 = b2;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void error_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ambilnilai();
            hitung();
            hitungMSE();
            Hasil.Text = "Hasil Error" + Math.Round((mse), 2).ToString();
        }
		
		//MENGHITUNG JUMLAH MSE
        void hitungMSE()
        {
            for (int i = 0; i < 10; i++)
            {
                mse += Math.Pow((hasildata[i]-lhr[i]),2);
            }
            mse = mse / 10;
        }
		
		//MENGHITUNG SEMUA NILAI 10 DATA TRAINING
        void hitung()
        {
           
            x1[0] = (data1[1] / 1) + (data1[2] / 2) + (data1[3] / 3) + (data1[4] / 4);
            x1[1] = (data2[1] / 1) + (data2[2] / 2) + (data2[3] / 3) + (data2[4] / 4);
            x1[2] = (data3[1] / 1) + (data3[2] / 2) + (data3[3] / 3) + (data3[4] / 4);
            x1[3] = (data4[1] / 1) + (data4[2] / 2) + (data4[3] / 3) + (data4[4] / 4);
            x1[4] = (data5[1] / 1) + (data5[2] / 2) + (data5[3] / 3) + (data5[4] / 4);
            x1[5] = (data6[1] / 1) + (data6[2] / 2) + (data6[3] / 3) + (data6[4] / 4);
            x1[6] = (data7[1] / 1) + (data7[2] / 2) + (data7[3] / 3) + (data7[4] / 4);
            x1[7] = (data8[1] / 1) + (data8[2] / 2) + (data8[3] / 3) + (data8[4] / 4);
            x1[8] = (data9[1] / 1) + (data9[2] / 2) + (data9[3] / 3) + (data9[4] / 4);
            x1[9] = (data10[1] / 1) + (data10[2] / 2) + (data10[3] / 3) + (data10[4] / 4);

            x2[0] = data1[6];
            x2[1] = data2[6];
            x2[2] = data3[6];
            x2[3] = data4[6];
            x2[4] = data5[6];
            x2[5] = data6[6];
            x2[6] = data7[6];
            x2[7] = data8[6];
            x2[8] = data9[6];
            x2[9] = data10[6];

            lhr[0] = data1[5];
            lhr[1] = data2[5];
            lhr[2] = data3[5];
            lhr[3] = data4[5];
            lhr[4] = data5[5];
            lhr[5] = data6[5];
            lhr[6] = data7[5];
            lhr[7] = data8[5];
            lhr[8] = data9[5];
            lhr[9] = data10[5];


            for (int i = 0; i < 10; i++)
            {
                hasildata[i] = a + (x1[i] * b1) + (x2[i] * b2);
            }


        }
		
		//MENGAMBIL DATA DARI 10 DATA PADA FORM
        void ambilnilai()
        {
         
            data1[1] = double.Parse(textBox1_2.Text);
            data1[2] = double.Parse(textBox1_3.Text);
            data1[3] = double.Parse(textBox1_4.Text);
            data1[4] = double.Parse(textBox1_5.Text);
            data1[5] = double.Parse(textBox1_9.Text);
            if (comboBox1_7.SelectedItem.ToString() == "LU")
            {
                data1[6] = 2;
            }
            else if (comboBox1_7.SelectedItem.ToString() == "JJS")
            {
                data1[6] = 1;
            }
            else
                data1[6] = 0;

      
            data2[1] = double.Parse(textBox2_2.Text);
            data2[2] = double.Parse(textBox2_3.Text);
            data2[3] = double.Parse(textBox2_4.Text);
            data2[4] = double.Parse(textBox2_5.Text);
            data2[5] = double.Parse(textBox2_9.Text);
            if (comboBox2_7.SelectedItem.ToString() == "LU")
            {
                data2[6] = 2;
            }
            else if (comboBox2_7.SelectedItem.ToString() == "JJS")
            {
                data2[6] = 1;
            }
            else
                data2[6] = 0;

     
            data3[1] = double.Parse(textBox3_2.Text);
            data3[2] = double.Parse(textBox3_3.Text);
            data3[3] = double.Parse(textBox3_4.Text);
            data3[4] = double.Parse(textBox3_5.Text);
            data3[5] = double.Parse(textBox3_9.Text);
            if (comboBox3_7.SelectedItem.ToString() == "LU")
            {
                data3[6] = 2;
            }
            else if (comboBox3_7.SelectedItem.ToString() == "JJS")
            {
                data3[6] = 1;
            }
            else
                data3[6] = 0;

         
            data4[1] = double.Parse(textBox4_2.Text);
            data4[2] = double.Parse(textBox4_3.Text);
            data4[3] = double.Parse(textBox4_4.Text);
            data4[4] = double.Parse(textBox4_5.Text);
            data4[5] = double.Parse(textBox4_9.Text);
            if (comboBox4_7.SelectedItem.ToString() == "LU")
            {
                data4[6] = 2;
            }
            else if (comboBox4_7.SelectedItem.ToString() == "JJS")
            {
                data4[6] = 1;
            }
            else
                data4[6] = 0;

            
            data5[1] = double.Parse(textBox5_2.Text);
            data5[2] = double.Parse(textBox5_3.Text);
            data5[3] = double.Parse(textBox5_4.Text);
            data5[4] = double.Parse(textBox5_5.Text);
            data5[5] = double.Parse(textBox5_9.Text);
            if (comboBox5_7.SelectedItem.ToString() == "LU")
            {
                data5[6] = 2;
            }
            else if (comboBox5_7.SelectedItem.ToString() == "JJS")
            {
                data5[6] = 1;
            }
            else
                data5[6] = 0;


            data6[1] = double.Parse(textBox6_2.Text);
            data6[2] = double.Parse(textBox6_3.Text);
            data6[3] = double.Parse(textBox6_4.Text);
            data6[4] = double.Parse(textBox6_5.Text);
            data6[5] = double.Parse(textBox6_9.Text);
            if (comboBox6_7.SelectedItem.ToString() == "LU")
            {
                data6[6] = 2;
            }
            else if (comboBox6_7.SelectedItem.ToString() == "JJS")
            {
                data6[6] = 1;
            }
            else
                data6[6] = 0;

        
            data7[1] = double.Parse(textBox7_2.Text);
            data7[2] = double.Parse(textBox7_3.Text);
            data7[3] = double.Parse(textBox7_4.Text);
            data7[4] = double.Parse(textBox7_5.Text);
            data7[5] = double.Parse(textBox7_9.Text);
            if (comboBox7_7.SelectedItem.ToString() == "LU")
            {
                data7[6] = 2;
            }
            else if (comboBox7_7.SelectedItem.ToString() == "JJS")
            {
                data7[6] = 1;
            }
            else
                data7[6] = 0;


            data8[1] = double.Parse(textBox8_2.Text);
            data8[2] = double.Parse(textBox8_3.Text);
            data8[3] = double.Parse(textBox8_4.Text);
            data8[4] = double.Parse(textBox8_5.Text);
            data8[5] = double.Parse(textBox8_9.Text);
            if (comboBox8_7.SelectedItem.ToString() == "LU")
            {
                data8[6] = 2;
            }
            else if (comboBox8_7.SelectedItem.ToString() == "JJS")
            {
                data8[6] = 1;
            }
            else
                data8[6] = 0;

  
            data9[1] = double.Parse(textBox9_2.Text);
            data9[2] = double.Parse(textBox9_3.Text);
            data9[3] = double.Parse(textBox9_4.Text);
            data9[4] = double.Parse(textBox9_5.Text);
            data9[5] = double.Parse(textBox9_9.Text);
            if (comboBox9_7.SelectedItem.ToString() == "LU")
            {
                data9[6] = 2;
            }
            else if (comboBox9_7.SelectedItem.ToString() == "JJS")
            {
                data9[6] = 1;
            }
            else
                data9[6] = 0;

      
            data10[1] = double.Parse(textBox10_2.Text);
            data10[2] = double.Parse(textBox10_3.Text);
            data10[3] = double.Parse(textBox10_4.Text);
            data10[4] = double.Parse(textBox10_5.Text);
            data10[5] = double.Parse(textBox10_9.Text);
            if (comboBox10_7.SelectedItem.ToString() == "LU")
            {
                data10[6] = 2;
            }
            else if (comboBox10_7.SelectedItem.ToString() == "JJS")
            {
                data10[6] = 1;
            }
            else
                data10[6] = 0;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
