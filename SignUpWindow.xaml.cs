using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private ManageTeacher manageTeacher = new ManageTeacher();

        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            manageTeacher.LoadData();
        }


        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            manageTeacher.Teachers.Add(new Teacher
            {
                Username = TextBox_NewUsername.Text,
                Password = PassBox_Newpassword.Password,
                Phone = PhoneNumber.Text,
                QuestionNo = SecurityQuestion.SelectedIndex,
                Answer = SecurityAnswer.Text

            });
            manageTeacher.SaveData();
            //DialogResult = DialogResult.Value;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void IconBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void IconBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void PhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regg = new Regex(@"\d");
            e.Handled = !regg.IsMatch(e.Text);
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        
    }
}
