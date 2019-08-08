using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    public class Prescription
    {        
        private string prescriptionID;
        private Appointment appointment = new Appointment();
        private Medicine medicine = new Medicine();
        private Staff staff = new Staff();
        private Patient patient = new Patient();
        private DateTime endDate = new DateTime();

        public string PrescriptionID
        {
            get
            {
                return prescriptionID;
            }

            set
            {
                prescriptionID = value;
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

        public Medicine Medicine
        {
            get
            {
                return medicine;
            }

            set
            {
                medicine = value;
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

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }
    }

    
}
