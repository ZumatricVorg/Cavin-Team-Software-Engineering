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
        private Staff staff;
        private Patient patient;
        private Appointment appointment;
        private string description;
        private string remarks;

        public string ReportID { get => reportID; set => reportID = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public Appointment Appointment { get => appointment; set => appointment = value; }
        public string Description { get => description; set => description = value; }
        public string Remarks { get => remarks; set => remarks = value; }
        internal Staff Staff { get => staff; set => staff = value; }
    }
}
