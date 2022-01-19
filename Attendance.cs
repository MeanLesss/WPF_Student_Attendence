using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Student_Attendence
{
    public class Attendance:INotifyPropertyChanged
    {
        DashboardWindow dashboard;
        public Attendance()
        {

        }

        public int No { get; set; } = 0;
        public Image Avatar { get; set; } = Properties.Resources.wine_glass;
        private string _path = "wine_glass.jpg";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                try { Avatar = Image.FromFile(_path); } catch { }
            }

        }

        public string Name { get; set; } = "Sokvimean";
        public string Status
        {
            get;
            set;

        }/* = "Present";*/= "Present";
        string remark=" ";
        public string Remark { get=>remark; set {
                remark = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Remark))); /// use prpopertychangeevent on all property to invoke everychange
            } }
        public string Subject { get; set; }
        public int Session { get; set; }
        public DateTime Date { get; set; }
    }
}
