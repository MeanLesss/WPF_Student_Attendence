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
        public DashboardWindow()
        {
            InitializeComponent();
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" +
 @"Data Source=D:\IT STEP ACADEMY\Fundamentals of applications development with Window form\Homework\WPF Homework\Project\WPF_Student_Attendence\WPF_Student_Attendence\Student_Attendance.mdb;");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * From Student_Attended", con);
            DataGridView.ItemsSource = cmd.ExecuteReader();
        }
        private void LoadData()
        {
            
        }
        

        private void IconBlockClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void IconBlockMinimise_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
