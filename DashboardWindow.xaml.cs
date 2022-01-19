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
using System.Windows.Forms;

namespace WPF_Student_Attendence
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        Teacher teacher;
        ManageAttendance manageAttendance;
        public BindingSource BindingSource { get; set; } = new BindingSource();

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
            //ManageAttendance manageAttendance = new ManageAttendance();
            DG.ItemsSource = manageAttendance.LoadStudents();

        }

        private void DG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
            manageAttendance.SaveData();
        }

        private void DG_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
        }

        private void DG_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            manageAttendance.SaveData();
            lbUsername.Content = DateTime.Now.ToLongTimeString();
        }

        private void DG_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            

        }
    }
}
