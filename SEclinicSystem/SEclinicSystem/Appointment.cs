using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    public class Appointment
    {

        private string appointmentID;
        private DateTime date;
        private DateTime time;
        private Patient patient;
        private GeneralPractitioner gp;
        private string status;
        private string remark;
        private string msg;

        public string AppointmentID
        {
            get
            {
                return appointmentID;
            }

            set
            {
                appointmentID = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public Patient Patient
        {
            get
            {
                return patient;
            }

            set
            {
                patient = value;
            }
        }

        internal GeneralPractitioner Gp
        {
            get
            {
                return gp;
            }

            set
            {
                gp = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
            }
        }

        public string Msg
        {
            get
            {
                return msg;
            }

            set
            {
                msg = value;
            }
        }
    }
}
