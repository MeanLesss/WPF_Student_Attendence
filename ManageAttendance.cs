using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Student_Attendence
{
    public class ManageAttendance
    {
        public ManageAttendance() { }
        public ObservableCollection<Attendance> attendances { get; set; } = new ObservableCollection<Attendance>();
        readonly string filename = "mean_attendance.csv";

        public string TeacherName { get; set; } = "";

        public ManageAttendance(string teacherName)
        {
            TeacherName = teacherName;
            filename = teacherName + "_" + filename;
        }

        private Image LoadImage(string path)
        {
            try
            {
                return Image.FromFile(path);
            }
            catch
            {

                return Properties.Resources.wine_glass;
            }
        }

        public void LoadData() //change this to list and turn some property to test
        {
            var Dir = @"D:\IT STEP ACADEMY\Fundamentals of applications development with Window form\Homework\WPF Homework\Project\WPF_Student_Attendence\bin\Debug\net5.0-windows\Student_list.csv";
            if (!File.Exists(filename)) return;
            var ts = from t in File.ReadAllLines(filename).Skip(1)
                     let x = t.Split(',')
                     select new Attendance
                     {
                         Path = x[0],
                         Name = x[1],
                         Status = x[2],
                         Remark = x[3],
                         /*Subject = x[4],
                         Session = int.Parse(x[5]),
                         Date = DateTime.Parse(x[6])*/
                     };
            attendances.Clear();
            int i = 1;
            foreach (var t in ts)
            {
                t.No = i++;
                attendances.Add(t);
            }
        }

        //public List<Attendance> ListAttendance { get; set; } = LoadAttendances();

        public ObservableCollection<Attendance> LoadStudents()  //////////////// edit Atteendance.cs properties //////////////
        {
            var Dir = @"D:\IT STEP ACADEMY\Fundamentals of applications development with Window form\Homework\WPF Homework\Project\WPF_Student_Attendence\bin\Debug\net5.0-windows\Student_list.csv";
            var list = new List<Attendance>();
            if (!File.Exists(Dir)) ;
            var ts = from t in File.ReadAllLines(Dir).Skip(1)
                     let x = t.Split(',')
                     select new Attendance
                     {
                         Path = x[0],
                         Name = x[1],
                         Status = x[2],
                         Remark = x[3],
                         /*Subject = x[4],
                         Session = int.Parse(x[5]),
                         Date = DateTime.Parse(x[6])*/
                     };
            list.Clear();
            int i = 1;
            attendances.Clear();
            foreach (var t in ts)
            {
                t.No = i++;
                list.Add(t);
                attendances.Add(t);
            }
            return attendances; 
        }

        public void SaveData() //////// no change 
        {
            using (var fs = new FileStream(filename, FileMode.Create|FileMode.Append))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Avatar,Name,Status,Remark,Subject,Session,Date");
                    foreach (var t in attendances)
                    {
                        sw.WriteLine($"{t.Path},{t.Name},{t.Status},"
                            + $"{t.Remark},{t.Subject},{t.Session},{t.Date.ToShortDateString()}");
                    }
                }
            }
        }
    }
}

