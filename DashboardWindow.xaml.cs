using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
using System.Configuration;

namespace WPF_Student_Attendence
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        Teacher teacher;
        ManageAttendance manageAttendance;
        ManageTeacher manageTeacher = new ManageTeacher();

        public DashboardWindow()
        {
            InitializeComponent();
           /* OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" +
 @"Data Source=D:\IT STEP ACADEMY\Fundamentals of applications development with Window form\Homework\WPF Homework\Project\WPF_Student_Attendence\Student_Attendance.mdb;");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * From Student_Attended", con);
            DataGridView.ItemsSource = cmd.ExecuteReader();*/
        }

        public DashboardWindow(Teacher teacher)
        {
            //var u = DataContext as Class1;
            InitializeComponent();
            this.teacher = teacher;
            manageAttendance = DataContext as ManageAttendance;
            lbUsername.Content = teacher.Username;

            ComboSubject.SelectedIndex = 0;
            ComboSession.SelectedIndex = 0;
            ResetPasswordPanel.Visibility = Visibility.Collapsed;
            AttandancePanel.Visibility = Visibility.Collapsed;
        }

        private void IconBlockClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void IconBlockMinimise_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            manageTeacher.LoadData();
            ComboSubject.SelectedIndex = 0;
            ComboSession.SelectedItem = 0;
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxHistory.IsChecked == true)
            {
                DG.ItemsSource = manageAttendance.LoadHistory();
            }
            else 
            {
                DG.ItemsSource = manageAttendance.LoadStudents();
            }
        }


        private void DG_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            manageAttendance.SaveData();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Attendance_Click(object sender, RoutedEventArgs e)
        {
            Button_Attendance.Background = Brushes.Gray;
            Button_EditProfile.Background = Brushes.LightGray;
            AttandancePanel.Visibility = Visibility.Visible;
            ResetPasswordPanel.Visibility = Visibility.Collapsed;

        }

        private void Button_EditProfile_Click(object sender, RoutedEventArgs e)
        {
            manageTeacher.LoadData();
            Button_EditProfile.Background = Brushes.Gray;
            Button_Attendance.Background = Brushes.LightGray;
            ResetPasswordPanel.Visibility = Visibility.Visible;
            AttandancePanel.Visibility = Visibility.Collapsed;
        }

        private void SubmitChange_Click(object sender, RoutedEventArgs e)
        {

            if (NewPassword.Password != ConfirmNewPassword.Password)
            {
                MessageBox.Show("Incorrect old password or Confirm password doesn't match!");
                OldPassword.Clear();
                NewPassword.Clear();
                ConfirmNewPassword.Clear();
            }
            else if (teacher.Password != OldPassword.Password)
            {
                MessageBox.Show("Incorrect old password!");
                OldPassword.Clear();
                NewPassword.Clear();
                ConfirmNewPassword.Clear();
            }
            else
            {
                manageTeacher.SaveChanges(teacher.Username, OldPassword.Password, NewPassword.Password);
                teacher.Password = NewPassword.Password;
                OldPassword.Clear();
                NewPassword.Clear();
                ConfirmNewPassword.Clear();
                MessageBox.Show("Password Changed successfully!");
                ResetPasswordPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        /////I should add the save button/////

    }
}
