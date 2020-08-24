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
    public partial class Home : Form
    {
        private static dataset fdataset;
        public Home()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
		
		//MENUTUP APLIKASI
        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
		
		//INSTANSIASI DAN MASUK KE FORM DATASET
        private void btnMasuk_Click(object sender, EventArgs e)
        {
            fdataset = new dataset();
            this.Hide();
            fdataset.Show();
        }
    }
}
