using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPF_Student_Attendence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Teacher teacher = new Teacher();
        private ManageTeacher manageTeacher = new ManageTeacher();
        private bool correct;
        private SignUpWindow signUpWindow = new SignUpWindow();
        public bool IsLogin { get; set; } = false;


        public MainWindow()
        {
            InitializeComponent();
            Button_eyeSlash.Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            manageTeacher.LoadData();
        }

        private void WrapPanel_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }


        private void MainWrap_LayoutUpdated(object sender, EventArgs e)
        {
            if (Width < 775)
            {
                IconLogIn.Visibility = Visibility.Collapsed;
                LoginInfo.VerticalAlignment = VerticalAlignment.Center;
                LoginInfo.Width = Width;
                
            }
            else
            {
                IconLogIn.Visibility = Visibility.Visible;
                LoginInfo.Width = 473; 
            }
        }

        private void ForgetPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            ForgetPassword.Foreground = new SolidColorBrush(Colors.Blue);

        }


        private void ForgetPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            ForgetPassword.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            signUpWindow.Show();
            this.Close();
        }



        private void Button_eye_Click(object sender, RoutedEventArgs e)
        {
            RevealPass.Text = BoxPassword.Password;
            Button_eyeSlash.Visibility = Visibility.Visible;
            Button_eye.Visibility = Visibility.Collapsed;
            BoxPassword.Visibility = Visibility.Collapsed;
            RevealPass.Visibility = Visibility.Visible;
        }

        private void Button_eyeSlash_Click(object sender, RoutedEventArgs e)
        {
            BoxPassword.Password = RevealPass.Text; 
            Button_eyeSlash.Visibility = Visibility.Collapsed;
            Button_eye.Visibility = Visibility.Visible;
            BoxPassword.Visibility = Visibility.Visible;
            RevealPass.Visibility = Visibility.Collapsed;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("km"); // to translate;
            lbUsername.Content = Resource1.Username; // and have to update the interface
        }

        

        private void IconBlockClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void IconBlockMinimise_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private bool Authentication()
        {
            manageTeacher.LoadData();


            Teacher teacher = manageTeacher.Teachers.Find(
            t => t.Username == BoxUsername.Text &&
            t.Username == BoxPassword.Password);
            correct = true;

            if (BoxUsername.Text == teacher.Username &&
                BoxPassword.Password == teacher.Username)
            {
                correct = true;
            }
            else
            {
                correct = false;
            }

            return correct;

        }

        private void Button_SignIn_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = manageTeacher.Teachers.Find(
               t => t.Username == BoxUsername.Text &&
               t.Password == BoxPassword.Password ||
               t.Username == BoxUsername.Text &&
               t.Password == RevealPass.Text);

            BoxUsername.Clear();
            BoxPassword.Clear();
            RevealPass.Clear();

            if (teacher != null)
            {
                IsLogin = true;
                new DashboardWindow(teacher).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User not found!", "Log in failed");
            }
        }
    }
}
