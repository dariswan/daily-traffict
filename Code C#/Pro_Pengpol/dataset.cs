using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pro_Pengpol
{
    public partial class dataset : Form
    {
        private static Home fhome;
        private static prediksi fprediksi;
        MySqlConnection conn = new MySqlConnection();
        String connString = "server=127.0.0.1;uid=root;pwd=;database=dbjalan;SslMode=none";
        string table = "";
        double[,] data = new double[200, 7];
        string[,] dataKlasifikasi = new string[200, 2];
        double[] x1 = new double[200];
        double[] x2 = new double[200];
        double[] y = new double[200];
        double sx1,sx2,sy,x1_2, x2_2, y_2, x1x2, x1y, x2y;
        double nx1_2, nx2_2, ny_2, nx1x2, nx1y, nx2y;
        double b1, b2, a, determinasi, korelasi, error;


        public dataset()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
		
		//MENGHUBUNGKAN DENGAN DATABASE
        void myConn()
        {
            try
            {
                conn.ConnectionString = connString;
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
		
		//MENAMPILKAN DATABASE
        private void btnTampil_Click(object sender, EventArgs e)
        {
            try
            {
                table = comboBox1.SelectedItem.ToString();
                tampildata();
            }
            catch (Exception)
            {
                MessageBox.Show("Database jalan belum tersedia");
            }



        }
		 //MENGAMBIL DATA DARI DATABASE
        void tampildata()
        {
            try
            {
                myConn();
                String sql = "SELECT * from ponorogo";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                this.dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            fhome = new Home();
            this.Hide();
            fhome.Show();
        }

		//MAIN PROSES 
        private void btnProses_Click(object sender, EventArgs e)
        {
            ambildata();
            ubahKategori();
            hitungX1();
            hitungX2();
            hitungY();
            sigma();
            normalisasi();
            hitungrumus();
            

            MessageBox.Show("Data training selesai diproses menggunakan metode Regresi Linear Berganda !!!");
            nextpage();
        }
		
		///MENGHITUNG RUMUS REGRESI LINEAR BERGANDA
        void hitungrumus()
        {
            b1 = (((nx2_2 * nx1y) - (nx2y * nx1x2)) / ((nx1_2 * nx2_2) - Math.Pow(nx1x2, 2)));
            b2 = (((nx1_2 * nx2y) - (nx1y * nx1x2)) / ((nx1_2 * nx2_2) - Math.Pow(nx1x2, 2)));
            a = ((sy - (b1 * sx1) - (b2 * sx2)) / 200);
            determinasi = (((b1 * nx1y) + (b2 * nx2y)) / ny_2);
            korelasi = Math.Sqrt(determinasi);
            error = Math.Sqrt(((y_2-(a*sy)-(b1*x1y)-(b2*x2y))/200-3));
        }
		
		//NORMALISASI
        void normalisasi()
        {
            nx1_2 = (x1_2 - (Math.Pow(sx1, 2) / 200));
            nx2_2 = (x2_2 - (Math.Pow(sx2, 2) / 200));
            ny_2 = (y_2 - (Math.Pow(sy,2) / 200));
            nx1y = (x1y - (sx1 * sy / 200));
            nx2y = (x2y - (sx2 * sy / 200));
            nx1x2 = (x1x2 - (sx1 * sx2 / 200));
        }
		
		//MENGHITUNG JUMLAH SIGMA SETIAP KOLOM
        void sigma()
        {
            for (int i = 0; i < 200; i++)
            {
                sx1 += x1[i];
                sx2 += x2[i];
                sy += y[i];
                x1_2 += Math.Pow(x1[i], 2);
                x2_2 += Math.Pow(x2[i], 2);
                y_2 += Math.Pow(y[i], 2);
                x1x2 += (x1[i] * x2[i]);
                x1y += (x1[i] * y[i]);
                x2y += (x2[i] * y[i]);
            }
        }
		
		///MENGHITUNG Y
        void hitungY()
        {
            for (int i = 0; i < 200; i++)
            {
                y[i] = data[i, 5];
            }
        }
		
		///MENGHITUNGY2
        void hitungX2()
        {
            for (int i = 0; i < 200; i++)
            {
                x2[i] = data[i,6];
            }
        }
		
		//MENGHITUNGX1
        void hitungX1()
        {
            for (int i = 0; i < 200; i++)
            {
                x1[i] = 0;
                for (int j = 1; j < 5; j++)
                {
                    x1[i] += (data[i, j] / j);
                }
            }
        }
		
		//MENGUBAH NILAI KATEGORI MENJADI NILAI KONTINIU
        void ubahKategori()
        {
            for (int i = 0; i < 200; i++)
            {
                if (dataKlasifikasi[i, 1] == "LU")
                {
                    data[i, 6] = 2;
                }
                else
                    data[i, 6] = 1;
            }
        }
		
        void cetak()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine(y[i]);
            }
        }
		
		//MENGAMBIL DATA DARI DATABASE
        void ambildata()
        {
            for (int i = 0; i < 200; i++)
            {
                myConn();
                String sql = "SELECT id_jalan,k_baik,k_sedang,k_rusak,k_rusakberat,lhr,klasifikasi FROM ponorogo where id_jalan='" + (i + 1) + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {

                    data[i, 0] = double.Parse(dataReader[0].ToString());
                    data[i, 1] = double.Parse(dataReader[1].ToString());
                    data[i, 2] = double.Parse(dataReader[2].ToString());
                    data[i, 3] = double.Parse(dataReader[3].ToString());
                    data[i, 4] = double.Parse(dataReader[4].ToString());
                    data[i, 5] = double.Parse(dataReader[5].ToString());
                    data[i, 6] = 0;
                    dataKlasifikasi[i,0] = dataReader[0].ToString();
                    dataKlasifikasi[i, 1] = dataReader[6].ToString();

                }
                dataReader.Close();
                conn.Close();
            }
        }

        void nextpage()
        {
            fprediksi = new prediksi(a,b1,b2,determinasi,korelasi,error);
            this.Hide();
            fprediksi.Show();
        }

        private void dataset_Load(object sender, EventArgs e)
        {

        }
    }
}
