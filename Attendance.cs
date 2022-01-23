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
        public event PropertyChangedEventHandler PropertyChanged;

        DashboardWindow dashboard;
        public Attendance()
        {

        }

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

        string name;
        public string Name 
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            } 
        }

        string status;
        public string Status
        {
            get =>status;
            set
            {
                status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        }

        string remark=" ";
        public string Remark 
        {
            get => remark;

            set 
            {
                remark = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Remark))); /// use prpopertychangeevent on all property to invoke everychange
            } 
        }

        string subject;
        public string Subject
        { 
            get => subject;
            set
            {
                subject = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subject)));
            }
        }

        int session;
        public int Session
        {
            get => session;
            set
            {
                session = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Session)));
            }
        }

        DateTime date;
        public DateTime Date 
        {
            get => date; 
            set
            {
                date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Date)));
            }
        }
    }
}
