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
    /// Logika interakcji dla klasy Rejestracja.xaml
    /// </summary>
    public partial class Rejestracja : Window
    {
        MainWindow ark;
        Ekran_Glowny rej001;

        public Rejestracja()
        {
            InitializeComponent();
        }
        

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string username = this.username_txt.Text;
            if (username.Length >= 21)
            {
                this.username_txt.Text = username.Substring(0, 20);
                this.username_error.Visibility = Visibility.Visible;

            }
            else
            {
                this.username_error.Visibility = Visibility.Hidden;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string password = this.password_txt.Text;
            if (password.Length >= 21)
            {
                password_txt.Clear();
                this.password_error.Visibility = Visibility.Visible;
            }
            else
            {
                this.password_error.Visibility = Visibility.Hidden;
            }
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            string owo = this.owoc_txt.Text;
            if (owo.Length >= 21)
            {
                this.owoc_txt.Text = owo.Substring(0, 20);
                this.owoc_error.Visibility = Visibility.Visible;
            }
            else
            {
                this.owoc_error.Visibility = Visibility.Hidden;
            }
        }

        private void Telefon_txt_TextInput(object sender, TextCompositionEventArgs e)
        {
            int a = 0;

        }


        private void Button_Click(object sender, RoutedEventArgs e) //powrot
        {
            /*if (ark == null)
            {
                ark = new MainWindow();
                ark.Show();
            }
            else
            {
                ark.Close();
                ark = new MainWindow();
                ark.Show();
           }*/
            this.ark.show_again();

            this.Close();

        }

        
            private void Telefon_txt_TextChanged(object sender, TextChangedEventArgs e)
            {
                string tel = this.telefon_txt.Text;
                if (tel.Length > 9)
                {
                    this.telefon_txt.Text = tel.Substring(0, 9);
                    this.telefon_error.Visibility = Visibility.Visible;
                }
                else
                {
                    this.telefon_error.Visibility = Visibility.Hidden;
                }
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (rej001 == null)
            {
                rej001 = new Ekran_Glowny();
                rej001.Show();
                rej001.ref_ekran_glowny(ark);
            }
            else
            {
                if (rej001 != null)
                    rej001.Close();

                rej001 = new Ekran_Glowny();
                rej001.Show();
                //rej001.ref_ekran_glowny(this);
            }

            this.Close();
            


        }

        public void pass_reference(MainWindow myWindow)
        {
            ark = myWindow;
        }
    }

   

    
}
