using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Projekt_1
{

    /// <summary>
    /// Logika interakcji dla klasy Ekran_Glowny.xaml
    /// </summary>
    public partial class Ekran_Glowny : Window
    {
        private List<Rekord> list = new List<Rekord>();

        MainWindow logo;

        public Page1 page1 = new Page1();
        public Page2 page2 = new Page2();
        public Page3 page3 = new Page3();

        /// <summary>
        
        /// </summary>

        public Ekran_Glowny()
        {
            //Window war = (Ekran_Glowny)Window.;
            InitializeComponent();
            this.Content = page1;
            page1.Get_data();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void Oplaty_button_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection connection = new SqlConnection(Properties.Settings.Default.constr);

            connection.Open();

            SqlCommand sqlCommand = connection.CreateCommand();


        }
        public void ref_ekran_glowny(MainWindow ekran)
        {
            logo = ekran;
        }

        private void Window_Closed(object sender, EventArgs e)
        {


            // logo.Close();
            logo.start_dips_timer();

        }
      
    }
    class Rekord
    {
        public double kwota { get; set; }
        public string tytul { get; set; }
        public DateTime data { get; set; }
    }
}
