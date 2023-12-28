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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для DobWindow.xaml
    /// </summary>
    public partial class DobWindow : Window
    {
        public DobWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (DBConnect.entobj.Cars.Count(x => x.Klass == Klass.Text) > 0)
            {
                MessageBox.Show("Такая машина уже есть!",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                return;
            }
            else
            {
                try
                {
                    Cars patientsObj = new Cars()
                    {
                        Klass = Klass.Text,
                        Marka = Marka.Text,
                        Gosn = Gosn.Text,
                        Kolvo = Convert.ToInt32(Kolvo.Text)
                    };
                    DBConnect.entobj.Cars.Add(patientsObj);
                    DBConnect.entobj.SaveChanges();

                    MessageBox.Show("Машина добавлена!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }

                catch (Exception ex)
                {

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManWindow1 mainWindow = new ManWindow1();
            mainWindow.Show();
            this.Close();
        }
    }
}

