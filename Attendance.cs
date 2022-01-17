using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Student_Attendence
{
    class Attendance
    {
        DashboardWindow dashboard;
        public int No { get; set; } = 0;
        public Image Avatar { get; set; } = Properties.Resources.wine_glass;
        private string _path = "wine_glass.jpg";
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                try { Avatar = Image.FromFile(_path); } catch { }
            }

        }

        public string Name { get; set; }
        public string Status
        {
            get;
            set;

        }/* = "Present";*/

        public string Remark { get; set; } = " ";
        public string Subject { get; set; }
        public int Session { get; set; }
        public DateTime Date { get; set; }
    }
}
