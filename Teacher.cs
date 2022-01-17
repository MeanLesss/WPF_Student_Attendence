using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Student_Attendence
{
    public class Teacher
    {
        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;

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
