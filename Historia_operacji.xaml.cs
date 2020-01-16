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

namespace Projekt_1
{
    /// <summary>
    /// Logika interakcji dla klasy Historia_operacji.xaml
    /// </summary>
    public partial class Historia_operacji : Window
    {


        private List<RecStan> lista = new List<RecStan>();
        Ekran_Glowny scr;
        public Historia_operacji()
        {
           
            InitializeComponent();
        }

        private void Stan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            RecStan nr = new RecStan();
            nr.wartosc = 9876;
            nr.data = DateTime.Now;

            lista.Add(nr);

            this.Stan.ItemsSource = null;
            this.Stan.ItemsSource = lista;
        }

        private void Oplaty_button_Click(object sender, RoutedEventArgs e)
        {
            if (scr == null)
            {
                Ekran_Glowny scr = new Ekran_Glowny();
                scr.Show();
            }
            else
            {
                scr.Close();
                //  Ekran_Glowny scr = new Ekran_Glowny();
                scr.Show();
            }
        }
    }

    class RecStan
    {
        public double wartosc { get; set; }
        public DateTime data { get; set; }

    }
}
