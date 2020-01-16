using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_1
{
    /// <summary>
    /// Logika interakcji dla klasy Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Oplaty_button_Click(object sender, RoutedEventArgs e)
        {
            ((Ekran_Glowny)this.Parent).Content = ((Ekran_Glowny)this.Parent).page1;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Stan_button_Click(object sender, RoutedEventArgs e)
        {
            ((Ekran_Glowny)this.Parent).Content = ((Ekran_Glowny)this.Parent).page2;
        }

        public void Get_data()
        {
            List<rec_nad_grid> list = new List<rec_nad_grid>();

            SqlConnection connection = new SqlConnection(Properties.Settings.Default.constr);

            try
            {
                connection.Open();

                SqlCommand sqlcmd = connection.CreateCommand();
                sqlcmd.CommandText = "select nad_temat,nad_kwota,nad_opis from projekt where 1=1";

                SqlDataReader rd = sqlcmd.ExecuteReader();
                while (rd.Read())
                {
                    rec_nad_grid nr = new rec_nad_grid();
                    nr.nad_temat = rd["nad_temat"].ToString();
                    string pars = rd["nad_kwota"].ToString();
                    nr.nad_kwota = float.Parse(pars);
                    nr.nad_opis = rd["nad_opis"].ToString();

                    list.Add(nr);

                }

                rd.Close();

                connection.Close();
                connection.Dispose();

                this.nad_Grid.ItemsSource = null;
                this.nad_Grid.ItemsSource = list;

            }
            catch (Exception exc)
            {

            }



        }

        private void Nad_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class rec_nad_grid
    {
        public string nad_temat { get; set; }
        public float nad_kwota { get; set; }
        public string nad_opis { get; set; }
    }
}
