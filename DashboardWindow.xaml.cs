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
        private ManageAttendance manageAttendance = new ManageAttendance("test");
        public DashboardWindow()
        {
            InitializeComponent();
            /*OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" +
 @"Data Source=D:\IT STEP ACADEMY\Fundamentals of applications development with Window form\Homework\WPF Homework\Project\WPF_Student_Attendence\WPF_Student_Attendence\Student_Attendance.mdb;");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * From Student_Attended", con);
            DataGridView.ItemsSource = cmd.ExecuteReader();*/
        }

        public DashboardWindow(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            manageAttendance = new ManageAttendance(teacher.Username);
            lbUsername.Content = teacher.Username;
            ComboSubject.SelectedIndex = 0;
            ComboSession.SelectedIndex = 0;
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
            ComboSubject.SelectedIndex = 0;
            ComboSession.SelectedItem = 0;
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
           /* manageAttendance.LoadData();
            bindingSource1.Clear();
            DateTime date = new DateTime(dateTimePicker1.Value.Year,
                dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
            var lst = from a in manageAttendance.attendances
                      where a.Date == date *//*(a.Date - date).TotalDays < 1*//* &&
                      a.Subject == comboBox_Subject.SelectedItem.ToString()
                      && a.Session == comboBox_Session.SelectedIndex
                      select a;
            if (lst.Count() == 0)
            {//new Date of attendances
                Attendance a1, a2, a3, a4, a5;
                manageAttendance.attendances.Add(a1 = new Attendance
                {
                    No = 1,
                    Name = "Sokvimean",
                    Date = dateTimePicker1.Value,
                    Session = comboBox_Session.SelectedIndex,
                    Subject = comboBox_Subject.SelectedItem.ToString()
                });
                manageAttendance.attendances.Add(a2 = new Attendance
                {
                    No = 2,
                    Name = "Piseth",
                    Date = dateTimePicker1.Value,
                    Session = comboBox_Session.SelectedIndex,
                    Subject = comboBox_Subject.SelectedItem.ToString()
                });
                manageAttendance.attendances.Add(a3 = new Attendance
                {
                    No = 3,
                    Name = "Thanit",
                    Date = dateTimePicker1.Value,
                    Session = comboBox_Session.SelectedIndex,
                    Subject = comboBox_Subject.SelectedItem.ToString()
                });
                manageAttendance.attendances.Add(a4 = new Attendance
                {
                    No = 4,
                    Name = "Daphea",
                    Date = dateTimePicker1.Value,
                    Session = comboBox_Session.SelectedIndex,
                    Subject = comboBox_Subject.SelectedItem.ToString()
                });
                manageAttendance.attendances.Add(a5 = new Attendance
                {
                    No = 5,
                    Name = "Phanit",
                    Date = dateTimePicker1.Value,
                    Session = comboBox_Session.SelectedIndex,
                    Subject = comboBox_Subject.SelectedItem.ToString()
                });
                bindingSource1.Add(a1);
                bindingSource1.Add(a2);
                bindingSource1.Add(a3);
                bindingSource1.Add(a4);
                bindingSource1.Add(a5);
            }
            else
            {
                int i = 1;
                foreach (var a in lst)
                {
                    a.No = i++;
                    bindingSource1.Add(a);
                }
            }*/
        }
    }
}
