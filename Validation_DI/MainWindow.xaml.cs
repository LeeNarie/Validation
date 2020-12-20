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
using System.Data.SqlClient;
using System.Data;
using ValLib;

namespace Validation_DI
{

    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();

            Datgr.ItemsSource = ValidEntities.GetContext().users.ToList();

        }

        public Boolean Check()
        {
            int k = 0;
            if (Validation_Class.FIO_Check(fio_text.Text))
            {
                fio_text.Background = new SolidColorBrush(Color.FromRgb(182, 255, 179)); //верное фио
                k++;

            }
            else { fio_text.Background = new SolidColorBrush(Color.FromRgb(255, 152, 146)); } //неверное фио

            if (Validation_Class.DR_Check(dr_text.Text))
            {
                dr_text.Background = new SolidColorBrush(Color.FromRgb(182, 255, 179)); //верное др
                k++;

            }
            else { dr_text.Background = new SolidColorBrush(Color.FromRgb(255, 152, 146)); } //неверное др

            if (Validation_Class.PH_Check(phone_text.Text))
            {
                phone_text.Background = new SolidColorBrush(Color.FromRgb(182, 255, 179)); //верный номер
                k++;

            }
            else { phone_text.Background = new SolidColorBrush(Color.FromRgb(255, 152, 146)); } //неверный номер

            if (Validation_Class.EM_Check(mail_text.Text))
            {
                mail_text.Background = new SolidColorBrush(Color.FromRgb(182, 255, 179)); //верный емаил
                k++;

            }
            else { mail_text.Background = new SolidColorBrush(Color.FromRgb(255, 152, 146)); } //неверный емаил

            if (k == 4) return true;
            else return false;
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                correct_or_not.Visibility = Visibility.Hidden;
            }
            else correct_or_not.Visibility = Visibility.Visible;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (Check())
            {

                correct_or_not.Visibility = Visibility.Hidden;

                string _fio = fio_text.Text.ToString();
                string _dr = dr_text.Text.ToString();
                string _phone = phone_text.Text.ToString();
                string _email = mail_text.Text.ToString();

                string ssql = $"INSERT INTO users (fio, dr, phone, email) VALUES ('{_fio}', '{_dr}', '{_phone}', '{_email}')";
                string connectionString = @"Data Source = .\SQLEXPRESS;Initial Catalog=Valid;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand(ssql, conn);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Вставлено объектов: {0}", number);
                conn.Close();
                Datgr.ItemsSource = ValidEntities.GetContext().users.ToList();

            }
            else
            {
                correct_or_not.Visibility = Visibility.Visible;

            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (Check())
            {

                correct_or_not.Visibility = Visibility.Hidden;
                var select = Datgr.SelectedItems.Cast<users>().ToList();

                int _id = select[0].id;
                string _fio = fio_text.Text.ToString();
                string _dr = dr_text.Text.ToString();
                string _phone = phone_text.Text.ToString();
                string _email = mail_text.Text.ToString();


                string ssql = $"UPDATE users SET fio='{_fio}',dr='{_dr}', phone='{_phone}', email='{_email}' WHERE id='{_id}' ";
                string connectionString = @"Data Source = .\SQLEXPRESS;Initial Catalog=Valid;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand command = new SqlCommand(ssql, conn);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Обновлено объектов: {0}", number);
                conn.Close();
                ValidEntities.GetContext().SaveChanges();
                Datgr.ItemsSource = ValidEntities.GetContext().users.ToList();
            }
            else
            {
                correct_or_not.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            var deletes = Datgr.SelectedItems.Cast<users>().ToList();
            ValidEntities.GetContext().users.RemoveRange(deletes);
            ValidEntities.GetContext().SaveChanges();
            Datgr.ItemsSource = ValidEntities.GetContext().users.ToList();
        }
    }
}
