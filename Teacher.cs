using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Student_Attendence
{
    public class Teacher: INotifyPropertyChanged
    {
public event PropertyChangedEventHandler PropertyChanged;
        public string Username
        {
            get;
            set;
        }


        string password;
        public string Password
        {

            get => password;
            set
            {
                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(password)));
            }
        }

        public string Phone
        {
            get;
            set;

        } = "";

        public int QuestionNo
        {
            get;
            set;

        } = -1; //Option Question, -1 because of comboBox

        public string Answer
        {
            get;
            set;

        } = "";
    }
}
