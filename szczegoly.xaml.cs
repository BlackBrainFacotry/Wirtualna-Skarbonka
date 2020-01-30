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
    /// Logika interakcji dla klasy szczegoly.xaml
    /// </summary>
    public partial class szczegoly : Window
    {
          int user_idd = 0;
        string temat;


        public szczegoly(int a, string b )
        {
            InitializeComponent();
            user_idd = a;
                temat = b;
            Okna_szczegoly();
            Get_data();



        }

       //public void GetUserID(int a)
       // {
       //     user_idd = a;
       // }

        public void Get_data()
        {
            List<rec_cel_grid> list = new List<rec_cel_grid>();
           // string user_idd = a.user_id.ToString();
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.constr);
            Cel_grid.ItemsSource = null;
            try
            {
                connection.Open();

                SqlCommand sqlcmd = connection.CreateCommand();
                sqlcmd.CommandText = "select tytul,dod_kwot ,data  from Dane where id_user=@id and data is not null and tytul=@ty ";
                sqlcmd.Parameters.AddWithValue("@id", user_idd);
                sqlcmd.Parameters.AddWithValue("@ty", temat);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable("Dane");
                adapter.Fill(dt);
                Cel_grid.ItemsSource = dt.DefaultView;

                //SqlDataReader rd = sqlcmd.ExecuteReader();
                //while(rd.Read())
                //{
                //   rec_cel_grid nr = new rec_cel_grid();
                //    nr.cel_temat = rd["tytul"].ToString();
                //    string pars = rd["dod_kwot"].ToString();
                //    nr.cel_kwota = float.Parse(pars);
                //    nr.cel_opis = rd["data"].ToString();

                //    list.Add(nr);

                //}

                //rd.Close();


                connection.Close();
                connection.Dispose();

               // this.Cel_grid.ItemsSource = null;
               //this.Cel_grid.ItemsSource = list;


            }
            catch (Exception exc)
            {
                MessageBox.Show("blad : " + exc);
            }



        }

        public void Okna_szczegoly()
        {

            decimal JAKASZMIENNA;
            decimal saldo=0;
            string a="";
            List<rec_cel_grid> list = new List<rec_cel_grid>();
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.constr);
            try
            {
                connection.Open();

                SqlCommand sqlcmd = connection.CreateCommand();
                sqlcmd.CommandText = "select  dod_kwot from Dane where id_user=@id and tytul=@ty ";
                sqlcmd.Parameters.AddWithValue("@id", user_idd);
                sqlcmd.Parameters.AddWithValue("@ty", temat);
                SqlDataReader rd = sqlcmd.ExecuteReader();
           
                    while (rd.Read())
               {
                   decimal s = Convert.ToDecimal(rd["dod_kwot"]);

                    saldo += s;
               }

                rd.Close();
                textbox1.Text = saldo.ToString();
            }
            catch
            {

            }
        }
    }
}
