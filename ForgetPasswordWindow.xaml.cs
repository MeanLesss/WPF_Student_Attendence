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

namespace WPF_Student_Attendence
{
    /// <summary>
    /// Interaction logic for ForgetPasswordWindow.xaml
    /// </summary>
    public partial class ForgetPasswordWindow : Window
    {
        Teacher teach = new Teacher();
        ManageTeacher manageTeacher;
        
        public ForgetPasswordWindow()
        {
            InitializeComponent();
            manageTeacher = DataContext as ManageTeacher;
            manageTeacher.LoadData();

            RadioPhoneNumber.IsChecked = true;
            GridNewPassword.Visibility = Visibility.Collapsed;
        }

        private void IconBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void IconBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void RadioPhoneNumber_Checked(object sender, RoutedEventArgs e)
        {
            GridPhoneNumber.Visibility = Visibility.Visible;
            GridQuestion.Visibility = Visibility.Collapsed;
            GridNewPassword.Visibility = Visibility.Collapsed;

        }

        private void RadioSecureQuestion_Checked(object sender, RoutedEventArgs e)
        {
            GridQuestion.Visibility = Visibility.Visible;
            GridPhoneNumber.Visibility = Visibility.Collapsed;
            GridNewPassword.Visibility = Visibility.Collapsed;

        }



        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        private void Check_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = manageTeacher.Teachers.Find(
                t => t.Username == SearchUsernamePhone.Text && t.Phone == SearchPhoneNumber.Text ||
                t.Username == SearchUsernameAnswer.Text && t.Answer == SearchAnswer.Text);
            teach = teacher;

            if (teacher != null)
            {
                GridNewPassword.Visibility = Visibility.Visible;
                GridQuestion.Visibility = Visibility.Collapsed;
                GridPhoneNumber.Visibility = Visibility.Collapsed;
                ButtonCheck.Visibility = Visibility.Collapsed;
                ButtonSave.Visibility = Visibility.Visible;

            }
            else
            {
                ButtonCheck.Visibility = Visibility.Visible;
                ButtonSave.Visibility = Visibility.Collapsed;
                MessageBox.Show("Invalid Username, Phone number or Answer");
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(NewPasswordBox.Password == ConfirmNewPassword.Password)
            {
                manageTeacher.SaveChanges(NewPasswordBox.Password, teach); //////// will change in the future update
                MessageBox.Show("Password save successfully!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("New password doesn't match the  confirmation!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
