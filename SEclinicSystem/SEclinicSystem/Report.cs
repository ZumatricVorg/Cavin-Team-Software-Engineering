using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    public class Report
    {
        private string reportID;
        private Staff staff = new Staff();
        private Patient patient = new Patient();
        private Appointment appointment = new Appointment();
        private string description;
        private string remarks;

        public string ReportID
        {
            get
            {
                return reportID;
            }

            set
            {
                reportID = value;
            }
        }

        public Staff Staff
        {
            get
            {
                return staff;
            }

            set
            {
                staff = value;
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

        public Appointment Appointment
        {
            get
            {
                return appointment;
            }

            set
            {
                appointment = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Remarks
        {
            get
            {
                return remarks;
            }

            set
            {
                remarks = value;
            }
        }
    }
}
