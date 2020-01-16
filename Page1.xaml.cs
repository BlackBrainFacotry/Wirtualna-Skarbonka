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
    /// Logika interakcji dla klasy Page1.xaml
    /// </summary>
    
     
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Stan_button_Click(object sender, RoutedEventArgs e)
        {

            ((Ekran_Glowny)this.Parent).Content = ((Ekran_Glowny)this.Parent).page2;
           // ((Ekran_Glowny)this.Parent).Content = NavigationService.Navigate(((Ekran_Glowny)this.Parent).page2);

        }

        private void Oplaty_button_Click(object sender, RoutedEventArgs e)
        {
            ((Ekran_Glowny)this.Parent).Content = ((Ekran_Glowny)this.Parent).page3;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void Get_data()
        {
            List<rec_cel_grid> list = new List<rec_cel_grid>();

            SqlConnection connection = new SqlConnection(Properties.Settings.Default.constr);

            try
            {
                connection.Open();

                SqlCommand sqlcmd = connection.CreateCommand();
                sqlcmd.CommandText = "select cel_temat,cel_kwota,cel_opis from projekt where 1=1";

                SqlDataReader rd = sqlcmd.ExecuteReader();
                while(rd.Read())
                {
                    rec_cel_grid nr = new rec_cel_grid();
                    nr.cel_temat = rd["cel_temat"].ToString();
                    string pars = rd["cel_kwota"].ToString();
                    nr.cel_kwota = float.Parse(pars);
                    nr.cel_opis = rd["cel_opis"].ToString();

                    list.Add(nr);

                }

                rd.Close();

                connection.Close();
                connection.Dispose();

                this.Cel_grid.ItemsSource = null;
                this.Cel_grid.ItemsSource = list;

            }
            catch(Exception exc)
            {

            }


            
        }

        private void Odśwież_tabele_Click(object sender, RoutedEventArgs e)
        {
            this.Get_data();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection2 = new SqlConnection(Properties.Settings.Default.constr);

         /*   try
            {
                connection2.Open();
                SqlCommand comm = connection2.CreateCommand();
                comm.CommandText = "insert into projekt (cel_temat,cel_kwota,cel_opis) VALUES (@a,@b,@c)";
                comm.Parameters.AddWithValue("@a", tytul1);
                comm.Parameters.AddWithValue("@b", kwota);
                comm.Parameters.AddWithValue("@c", opis);

                int recordsAffected = comm.ExecuteNonQuery();

                connection2.Close();
                connection2.Dispose();
                this.Get_data();

            }
            catch
            {

            }
            */
        }

        private void Tytuł_TextChanged(object sender, TextChangedEventArgs tytul1)
        {

        }

        private void Kwota_TextChanged(object sender, TextChangedEventArgs kwota1)
        {

        }

        private void Opis_TextChanged(object sender, TextChangedEventArgs opis1)
        {

        }

        private void Tytuł_TextInput(object sender, TextCompositionEventArgs tytul2)
        {
            string tytul = tytul2.ToString();
        }

        private void Kwota_TextInput(object sender, TextCompositionEventArgs kwota2)
        {
            //float kwota = float.Parse(kwota2);
        }

        private void Opis_TextInput(object sender, TextCompositionEventArgs opis2)
        {
            string opis = opis2.ToString();
        }

        private void Szczegoly_Click(object sender, RoutedEventArgs e)
        {
            Window win = new szczegoly();
            win.Show();
        }
    }

    public class rec_cel_grid
    {
        public string cel_temat { get; set; }
        public float cel_kwota { get; set; }
        public string cel_opis { get; set; }
    }
}
