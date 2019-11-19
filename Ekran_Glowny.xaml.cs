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
    /// Logika interakcji dla klasy Ekran_Glowny.xaml
    /// </summary>
    public partial class Ekran_Glowny : Window
    {
        private List<Rekord> list = new List<Rekord>();

        MainWindow logo;
        
        public Ekran_Glowny()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Rekord red = new Rekord();                        ///inicjalizowanie tabelki
            red.data = DateTime.Now;
            red.kwota = 998989;
            red.tytul = "tytutytu";

            list.Add(red);

            this.tab_eg.ItemsSource = null;
            this.tab_eg.ItemsSource = list;
        }

        private void Oplaty_button_Click(object sender, RoutedEventArgs e)
        {
            

        }
        public void ref_ekran_glowny(MainWindow ekran)
        {
            logo = ekran;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
            this.logo.show_again();
        }
    }
    class Rekord
    {
        public double kwota { get; set; }
        public string tytul { get; set; }
        public DateTime data { get; set; }
    }
}
