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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Rejestracja rej000;
        Ekran_Glowny rej001;

        System.Windows.Threading.DispatcherTimer disp_timer = new System.Windows.Threading.DispatcherTimer();

      
        public MainWindow()
        {
            InitializeComponent();
            disp_timer.Interval = TimeSpan.FromSeconds(2);
            disp_timer.Tick += Disp_timer_Tick;
        }

        private void Disp_timer_Tick(object sender, EventArgs e)
        {
            this.Close();
            //Application.Current.Shutdown();
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void password(object sender, TextChangedEventArgs e)
        {
            string pass = this.password_txt.Text;
            if (pass.Length > 20)
            {
                password_txt.Clear();
                password_error.Visibility = Visibility.Visible;
            }
            else
            {
                login_error.Visibility = Visibility.Hidden;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e) //rejestracja
        {
            if (rej000 == null)
            {
                rej000 = new Rejestracja();
                rej000.Show();
            }
            else
            {
                if(rej000 != null)
                    rej000.Close();

                rej000 = new Rejestracja();
                rej000.Show();
                rej000.Focus();
            }

            this.Visibility = Visibility.Hidden;
            rej000.pass_reference(this);
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //logowanie
        {
            //new Historia_operacji().Show();
            if (rej001 == null)
            {
                rej001 = new Ekran_Glowny();
                rej001.Show();
            }
            else
            {
                if (rej001 != null)
                    rej001.Close();

                rej001 = new Ekran_Glowny();
                rej001.Show();
                //rej001.ref_ekran_glowny(this);
            }

            this.Visibility = Visibility.Hidden;
            rej001.ref_ekran_glowny(this);

        }

        public void start_dips_timer()
        {
            disp_timer.Start();
            if (rej001 != null)
            {
                rej001.Close();
            }

        }

        private void login(object sender, TextChangedEventArgs e)
        {
            string log = this.login_txt.Text;
            if (log.Length > 20)
            {
                login_txt.Text = log.Substring(0, 20);
                login_error.Visibility = Visibility.Visible;
            }
            else
            {
                login_error.Visibility = Visibility.Hidden;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.disp_timer.Start();
        }

        public void show_again()
        {
            this.Visibility = Visibility.Visible;
        }
    }
}
