using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
           
            DBConnect.entobj = new ManagerAppEntities();
        }

       

        private void Login_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                var userobj = DBConnect.entobj.User.FirstOrDefault(x => x.Login == txtUsername.Text && x.Password == txtPassword.Password);
                if (userobj == null)
                {
                    MessageBox.Show("Такой пользователь не найден!",
               "Уведомление",
               MessageBoxButton.OK,
               MessageBoxImage.Information);
                }
                else
                {
                    switch (userobj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, менеджер!" + userobj.Login,
               "Уведомление",
               MessageBoxButton.OK,
               MessageBoxImage.Information);
                            ManWindow1 manWindow1 = new ManWindow1();
                            manWindow1.Show();
                            this.Hide();
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, бухгалтер!" + userobj.Login,
               "Уведомление",
               MessageBoxButton.OK,
               MessageBoxImage.Information);
                            ManWindow1 manWindow = new ManWindow1();
                            manWindow.Show();
                            this.Hide();
                            break;

                    }
                } 
                    
                   
            }
            catch (Exception ex)
            {

            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (DBConnect.entobj.User.Count(x => x.Login == txtUsername.Text) > 0)
            {
                MessageBox.Show("Такой пользователь уже есть!",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                return;
            }
            else
            {
                try
                {
                    User userObj = new User()
                    {
                        Login = txtUsername.Text,
                        Password = txtPassword.Password,
                        IdRole = 2
                    };
                    DBConnect.entobj.User.Add(userObj);
                    DBConnect.entobj.SaveChanges();

                    MessageBox.Show("Пользователь создан!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                catch
                {

                }
            
            }
            }
    }
}
