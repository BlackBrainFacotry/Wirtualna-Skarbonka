using System;
using System.Collections.Generic;
using System.Data;
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
        string temat;
        public int user_id { get; set; }
        public int id { get; set; }
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
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                temat = row_selected["tytul"].ToString();
               // MessageBox.Show(temat );
            }
        }

        public void Get_data()
        {
          //  List<rec_cel_grid> list = new List<rec_cel_grid>();

            SqlConnection connection = new SqlConnection(Properties.Settings.Default.constr);
            Cel_grid.ItemsSource = null;
            try
            {
                connection.Open();

                SqlCommand sqlcmd = connection.CreateCommand();
                sqlcmd.CommandText = "select distinct tytul,kwota ,opis  from Dane where id_user=@id and kwota is not null";
                sqlcmd.Parameters.AddWithValue("@id", user_id);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);

                DataTable dt = new DataTable("Dane");
                adapter.Fill(dt);
                Cel_grid.ItemsSource = dt.DefaultView;



                //SqlDataReader rd = sqlcmd.ExecuteReader();
                //while(rd.Read())
                //{
                //    rec_cel_grid nr = new rec_cel_grid();
                //    nr.cel_temat = rd["tytul"].ToString();
                //    string pars = rd["kwota"].ToString();
                //    nr.cel_kwota = float.Parse(pars);
                //    nr.cel_opis = rd["opis"].ToString();

                //    list.Add(nr);

                //}

                //rd.Close();

                connection.Close();
                connection.Dispose();

              //  this.Cel_grid.ItemsSource = null;
              //  this.Cel_grid.ItemsSource = list;

            }
            catch(Exception exc)
            {
                MessageBox.Show("blad : "+ exc);
            }


            
        }

        private void Odśwież_tabele_Click(object sender, RoutedEventArgs e)
        {
            this.Get_data();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection2 = new SqlConnection(Properties.Settings.Default.constr);

            string op, tyt, kwot;
            tyt = tytuł.Text;
            op = opis.Text;
            kwot = kwota.Text;
            float kwot2 = float.Parse(kwot);

            try
            {
                connection2.Open();
                SqlCommand comm = connection2.CreateCommand();
                comm.CommandText = "insert into Dane (tytul, id_user, kwota,opis) VALUES (@a, @id_user,@b,@c)";
                comm.Parameters.AddWithValue("@a", tyt);
                comm.Parameters.AddWithValue("@id_user", user_id);
                comm.Parameters.AddWithValue("@b", kwot2);
                comm.Parameters.AddWithValue("@c", op);

                int recordsAffected = comm.ExecuteNonQuery();
          
                connection2.Close();
                connection2.Dispose();
                this.Get_data();

            }
            catch(Exception ex)
            {
                MessageBox.Show("blad : " + ex);
            }
            
        }

       

        private void Szczegoly_Click(object sender, RoutedEventArgs e)
        {
            
         
            Window win = new szczegoly(user_id,temat);
         
            win.Show();
        }

        private void Opis_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            user_id = ((MainWindow)App.Current.MainWindow).user_id;
            MessageBox.Show(user_id.ToString());
        }

        private void Cel_grid_CurrentCellChanged(object sender, EventArgs e)
        {
            id = Cel_grid.SelectedIndex;
            // MessageBox.Show(id.ToString());
           
        }

        private void Dodaj_kwote_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection2 = new SqlConnection(Properties.Settings.Default.constr);

            string kstr; 
            kstr = dodaj_kwote_txt.Text;
            decimal krk;
            
            try
            {
                
                krk = Convert.ToDecimal(kstr);
             DateTime localDate = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss";
                try
                {
                    connection2.Open();
                    SqlCommand comm = connection2.CreateCommand();
                    comm.CommandText = "insert into Dane (tytul, dod_kwot, id_user, data) VALUES (@a,@b,@c,@d)";
                    comm.Parameters.AddWithValue("@a", temat);
                    comm.Parameters.AddWithValue("@c", user_id);
                    comm.Parameters.AddWithValue("@b", krk);
                   comm.Parameters.AddWithValue("@d", localDate.ToString(format));

                    int recordsAffected = comm.ExecuteNonQuery();

                    connection2.Close();
                    connection2.Dispose();
                    this.Get_data();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("blad : " + ex);
                }
            }
            catch
            {
             
            }
        }
    }

    public class rec_cel_grid
    {
        //public int user_id { get; set; }
        public string cel_temat { get; set; }
        public decimal cel_kwota { get; set; }
        public string cel_opis { get; set; }
    }
}
